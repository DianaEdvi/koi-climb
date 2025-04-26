using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShrimpTracker : MonoBehaviour
{
    [SerializeField] private ShrimpCounter[] _shrimpCounters;
    private GameObject[] _shrimps;

    private Events _events;
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += CountShrimp;
        SceneManager.sceneLoaded += FindText;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= CountShrimp;
        SceneManager.sceneLoaded -= FindText;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onHit.AddListener(CountShrimp);
        _events.onRespawnPlayer.AddListener(ResetCounter);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CountShrimp(Scene scene, LoadSceneMode loadSceneMode)
    {
        _shrimps = GameObject.FindGameObjectsWithTag("Collectible");

        foreach (var shrimpCounter in _shrimpCounters)
        {
            if (shrimpCounter.LevelName == SceneManager.GetActiveScene().name)
            {
                shrimpCounter.TotalShrimp = _shrimps.Length;
            }
        }
    }

    private void CountShrimp(string type)
    {
        if (type == "Collectible")
        {
            foreach (var shrimpCounter in _shrimpCounters)
            {
                if (shrimpCounter.LevelName == SceneManager.GetActiveScene().name)
                {
                    shrimpCounter.CurrentCaught++;
                }
            }
        }
    }

    private void ResetCounter(Vector3 wtv)
    {
        foreach (var shrimpCounter in _shrimpCounters)
        {
            if (shrimpCounter.LevelName == SceneManager.GetActiveScene().name)
            {
                if (shrimpCounter.CurrentCaught > shrimpCounter.HighScore)
                {
                    shrimpCounter.HighScore = shrimpCounter.CurrentCaught;
                }
                shrimpCounter.CurrentCaught = 0;
            }
        }
    }

    private void FindText(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            var texts = GameObject.FindGameObjectsWithTag("ShrimpText");

            foreach (var shrimpCounter in _shrimpCounters)
            {
                foreach (var txt in texts)
                {
                    if (txt.gameObject.transform.parent.gameObject.name == shrimpCounter.LevelName)
                    {
                        shrimpCounter.Text = txt.GetComponent<TMP_Text>();

                        shrimpCounter.Text.text = shrimpCounter.HighScore + "/" + shrimpCounter.TotalShrimp;
                    }
                }
            }
        }
        
    }
}
