using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuckingPause : MonoBehaviour
{
    private Gamestates _gamestates;
    // Start is called before the first frame update
    void Start()
    {
        _gamestates = GameObject.Find("Game").GetComponent<Gamestates>();
        GetComponent<Button>().onClick.AddListener(_gamestates.InvokePause);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
