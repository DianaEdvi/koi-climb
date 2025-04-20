using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] private int numberOfLevels = 5;
    private static Levels _instance;
    [SerializeField] private GameObject[] _parents;
    private Events _events;
    [SerializeField] private int[] values;
    private bool paused;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += UpdateAssistLevels;
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
     * 
     */
    private void TrackAssistLevel(AssistLevel assistLevel)
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            for (var i = 0; i < numberOfLevels; i++)
            {
                var num = i + 1;
                if (assistLevel.gameObject.transform.parent.gameObject.name == "Level" + num)
                {
                    values[i] = _parents[i].GetComponentInChildren<AssistLevel>().Counter;
                }
            }
        }
        else
        {
            for (var i = 0; i < numberOfLevels; i++)
            {
                var num = i + 1;
                if (SceneManager.GetActiveScene().name == "Level" + num)
                {
                    values[i] = assistLevel.GetComponentInChildren<AssistLevel>().Counter;
                }
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
                GameObject.FindGameObjectWithTag("PauseAssist").GetComponent<AssistLevel>().Counter = values[i];
            }
        }
    }
}
