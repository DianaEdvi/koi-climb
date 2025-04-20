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
    }

    private void TrackAssistLevel(AssistLevel assistLevel)
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            for (var i = 0; i < _parents.Length; i++)
            {
                var num = i + 1;
                if (assistLevel.gameObject.transform.parent.gameObject.name == "Level" + num)
                {
                    values[i] = _parents[i].GetComponentInChildren<AssistLevel>().Counter;
                }
            }
        }
    }

    private void UpdateAssistLevels(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            if (values.Length != numberOfLevels)
            {
                Debug.Log("null");
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
                    _parents[i] = levelObject;
                    _parents[i].GetComponentInChildren<AssistLevel>().Counter = values[i];

                }
            }
            
            // populate the values 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
