using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AssistLevel : MonoBehaviour
{
    [SerializeField] private Color[] assistColors;
    private Button _button;
    private Image _image;
    private int _counter;
    private string _text;
    private Checkpoints _checkpoints;
    [SerializeField] private int level;

    public int Level => level;

    public int Counter
    {
        get => _counter;
        set => _counter = value;
    }

    void Start()
    {
        // Debug.Log("counter: " + Counter);
        // Debug.Log("counter: " + _counter);
        _button = gameObject.GetComponent<Button>();
        _image = gameObject.GetComponent<Image>();
        
        GameObject ckpt = GameObject.Find("Checkpoints");
        if (ckpt != null)
        {
            _checkpoints = ckpt.GetComponent<Checkpoints>();
        }

        assistColors = new Color[4];
        assistColors[0] = new Color(1f, 200f / 255f, 200f / 255f);
        assistColors[1] = new Color(250f / 255f, 150f / 255f, 150f / 255f);
        assistColors[2] = new Color(245f / 255f, 100f / 255f, 100f / 255f);
        assistColors[3] = new Color(240f / 255f, 50f / 255f, 50f / 255f);
        
        _button.onClick.AddListener(SetAssistLevel);
        UpdateButtonUI();
    }
    
    public void SetAssistLevel()
    {
        _counter++;

        if (_counter == 4)
        {
            _counter = 0;
        }

        if (_image != null)
        {
            for (var i = 0; i < assistColors.Length; i++)
            {
                if (i == _counter)
                {
                    UpdateButtonUI();
                    var events = GameObject.Find("Game").GetComponent<Events>();
                    events.onAssistChanged?.Invoke(this);
                    if (_checkpoints != null)
                    {
                        _checkpoints.NumberOfCheckpoints = i;
                    }
                }
            }
            
        }
    }

    private void UpdateButtonUI()
    {
        _image.color = assistColors[_counter];
        _text = "" + _counter;
        _button.GetComponentInChildren<TMP_Text>().text = _text;
    }
}
