using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] private int numberOfLevels = 5;
    private static Levels _instance;
    private GameObject[] _parents;
    private Events _events;
    [SerializeField] private int[] values;

    public int[] Values => values;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += UpdateAssistLevels;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= UpdateAssistLevels;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onAssistChanged.AddListener(TrackAssistLevel);
        _events.onPause.AddListener(PauseLevelAssist);
    }

    /**
     * Update the values tracker for the assist levels
     */
    private void TrackAssistLevel(AssistLevel assistLevel)
    {
        for (var i = 0; i < numberOfLevels; i++)
        {
            var num = i + 1;
            var lvlName = "Level" + num;

            if (SceneManager.GetActiveScene().name == "LevelSelect")
            {
                if (assistLevel.gameObject.transform.parent.gameObject.name == lvlName)
                {
                    values[i] = _parents[i].GetComponentInChildren<AssistLevel>().Counter;
                }
            }
            else if (SceneManager.GetActiveScene().name == lvlName)
            {
                values[i] = assistLevel.GetComponentInChildren<AssistLevel>().Counter;
            }
            
        }
    }

    /**
     * Search for the level objects every time the scene is loaded in 
     */
    private void UpdateAssistLevels(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            // initialize values if it doesn't exist 
            if (values.Length != numberOfLevels)
            {
                values = new int[numberOfLevels];
            }
            _parents = new GameObject[numberOfLevels];

            // Find level objects 
            for (var i = 0; i < numberOfLevels; i++)
            {
                var num = i + 1;
                var objName = "Level" + num;

                var levelObject = GameObject.Find(objName);
                if (levelObject != null)
                {
                    // Check if _parents is initialized
                    if (_parents == null)
                    {
                        Debug.LogError("_parents array is null!");
                        return;
                    }
                    // set the level objects and assign their current values
                    _parents[i] = levelObject;
                    Debug.Log(_parents[i].gameObject.name);
                    _parents[i].GetComponentInChildren<AssistLevel>().Counter = values[i];

                }
            }
        }
    }
    

    /**
     * Special case for when the buttons are on the pause panel
     */
    private void PauseLevelAssist()
    {
        // Check which scene you are in 
        for (var i = 0; i < numberOfLevels; i++)
        {
            var num = i + 1;
            var lvlName = "Level" + num;

            if (SceneManager.GetActiveScene().name == lvlName)
            {
                var obj = GameObject.FindGameObjectWithTag("PauseAssist");
                if (obj != null)
                {
                    obj.GetComponent<AssistLevel>().Counter = values[i];
                }
            }
        }
    }
}
