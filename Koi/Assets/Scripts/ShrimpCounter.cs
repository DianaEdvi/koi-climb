using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ShrimpCounter
{

    [SerializeField] private string levelName;
    [SerializeField] private TMP_Text text;
    [SerializeField] private int totalShrimp;
    [SerializeField] private int currentCaught;
    [SerializeField] private int highScore;


    public string LevelName
    {
        get => levelName;
        set => levelName = value;
    }

    public TMP_Text Text
    {
        get => text;
        set => text = value;
    }

    public int TotalShrimp
    {
        get => totalShrimp;
        set => totalShrimp = value;
    }

    public int CurrentCaught
    {
        get => currentCaught;
        set => currentCaught = value;
    }

    public int HighScore
    {
        get => highScore;
        set => highScore = value;
    }
}
