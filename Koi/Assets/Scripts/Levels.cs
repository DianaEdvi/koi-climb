using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    private static Levels _instance;
    [SerializeField] private GameObject[] parents;
    private AssistLevel[] _assistLevels;
    private Events _events;

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
        _assistLevels = new AssistLevel[parents.Length];

        for (var i = 0; i < parents.Length; i++)
        {
            _assistLevels[i] = parents[i].GetComponentInChildren<AssistLevel>();
        }

    }

    private void TrackAssistLevel(AssistLevel assistLevel)
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            for (var i = 1; i < _assistLevels.Length - 1; i++)
            {
                if (assistLevel.Level == _assistLevels[i].Level)
                {
                    _assistLevels[i].Counter = assistLevel.Counter;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
