using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIHub : MonoBehaviour
{
    private Events _events;
    [SerializeField] private Canvas canvas;
    // [SerializeField] private Color[] assistColors;
    // private Button _button;
    // private Image _image;
    // private int _counter;
    // private string _text;
    // private Checkpoints _checkpoints;


    void Start()
    {
        GameObject gameObj = GameObject.Find("Game");
        if (gameObj != null)
        {
            _events = gameObj.GetComponent<Events>();
            _events.onEndLevel.AddListener(ReactivateUI);
        }
        // _button = GameObject.Find("Assist level button").GetComponent<Button>();
        // _image = GameObject.Find("Assist level button").GetComponent<Image>();
        // GameObject ckpt = GameObject.Find("Checkpoints");
        // if (ckpt != null)
        // {
        //     _checkpoints = ckpt.GetComponent<Checkpoints>();
        // }

        // assistColors = new Color[4];
        // assistColors[0] = new Color(1f, 200f / 255f, 200f / 255f);
        // assistColors[1] = new Color(250f / 255f, 150f / 255f, 150f / 255f);
        // assistColors[2] = new Color(245f / 255f, 100f / 255f, 100f / 255f);
        // assistColors[3] = new Color(240f / 255f, 50f / 255f, 50f / 255f);
    }

    private void ReactivateUI()
    {
        canvas.gameObject.SetActive(true);
    }

    // public void SetAssistLevel()
    // {
    //     _counter++;
    //
    //     if (_counter == 4)
    //     {
    //         _counter = 0;
    //     }
    //
    //     if (_image != null)
    //     {
    //         for (var i = 0; i < assistColors.Length; i++)
    //         {
    //             if (i == _counter)
    //             {
    //                _image.color = assistColors[i];
    //                _text = "" + i;
    //                _button.GetComponentInChildren<TMP_Text>().text = _text;
    //                if (_checkpoints != null)
    //                {
    //                    _checkpoints.NumberOfCheckpoints = i;
    //                }
    //             }
    //         }
    //         
    //     }
    // }
}