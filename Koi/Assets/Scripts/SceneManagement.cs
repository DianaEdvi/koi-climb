using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private Events _events;
    // Start is called before the first frame update
    void Start()
    {
        _events = GameObject.Find("Game").GetComponent<Events>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //
        // var scene = SceneManager.GetSceneByName(sceneName);
        // Debug.Log(scene.name);
        // if (scene.IsValid())
        // {
        //     Debug.Log("VAR");
        //     SceneManager.LoadScene(scene.name);
        // }
    }

    public void NextLevel()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        var newLevel = int.Parse("" + sceneName[5]);
        newLevel++;
        SceneManager.LoadScene(sceneName[new Range(0, 5)] + "" + newLevel);
        
    }
}
