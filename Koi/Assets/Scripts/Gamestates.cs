using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * A useless class that I will deal with in the future
 */
public class Gamestates : MonoBehaviour
{
    [SerializeField] private Events _events;

    private Button _pauseButton;
    private GameObject _pausePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onPause.AddListener(Pause);
        FindPauseObjects();
    }
    
    public void InvokeStart()
    {
        _events.onStartLevel?.Invoke();
    }

    private void FindPauseObjects()
    {
        var pauseObjs = GameObject.FindGameObjectsWithTag("Pause");

        foreach (var obj in pauseObjs)
        {
            if (obj.name == "PauseButton")
            {
                _pauseButton = obj.GetComponent<Button>();
                _pauseButton.onClick.AddListener(() =>
                {
                    _events.onPause?.Invoke();
                });
            }
            else if (obj.name == "PausePanel")
            {
                _pausePanel = obj;
            }
            else
            {
                Debug.LogError("Mislabelled pause objects");
            }
        }
    }

    private void Pause()
    {
        _pausePanel.SetActive(!_pausePanel.activeSelf);
    }
    
}
