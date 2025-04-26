using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIHub : MonoBehaviour
{
    private Events _events;
    [SerializeField] private GameObject endPanel;

    private TMP_Text _text;

    private void Awake()
    {
        endPanel = GameObject.FindGameObjectWithTag("EndPanel");
    }

    void Start()
    {
        GameObject gameObj = GameObject.Find("Game");
        if (gameObj != null)
        {
            _events = gameObj.GetComponent<Events>();
            if (_events != null)
            { 
                _events.onEndLevel.AddListener(ReactivateUI);
            }
        }
    }

    private void ReactivateUI()
    {
        endPanel.gameObject.SetActive(true);
    }
}