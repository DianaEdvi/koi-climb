using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * A useless class that I will deal with in the future
 */
public class Gamestates : MonoBehaviour
{
    private static Gamestates _instance;
    [SerializeField] private Events _events;

    private Button _pauseButton;
    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        pausePanel = GameObject.Find("PausePanel");

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        _events = GetComponent<Events>();
        if (_events == null)
        {
            Debug.LogError("Events script not found!");
            return;
        }

        // Delay binding the pause handler until we know the panel exists
        _events.onPause.AddListener(Pause);

        FindPauseObjects(); // sets pausePanel

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    
    public void InvokeStart()
    {
        _events.onStartLevel?.Invoke();
    }

    public void InvokePause()
    {
        _events.onPause?.Invoke();
    }

    private void FindPauseObjects()
    {
        var pauseObjs = GameObject.FindGameObjectsWithTag("Pause");

        foreach (var obj in pauseObjs)
        {
            if (obj.name == "PauseButton")
            {
                _pauseButton = obj.GetComponent<Button>();
            }
            else if (obj.name == "PausePanel")
            {
                pausePanel = obj;
            }
            else
            {
                Debug.LogError("Mislabelled pause objects");
            }
        }
    }

    private void Pause()
    {
        Debug.Log("invoked");
        if (pausePanel != null)
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
        }
    }
    
}
