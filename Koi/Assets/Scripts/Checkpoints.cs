using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{
    private GameObject[] _checkPoints;
    private Player _player;
    private Events _events;
    private bool _swapCheckPoint;
    private GameObject _currentCheckPoint;
    private int _numberOfCheckpoints;
    private GameObject _respawnMarker;
    private Levels _levels;
    
    // Start is called before the first frame update
    void Start()
    {
        var childCount = transform.childCount;
        _checkPoints = new GameObject[childCount];

        for (var i = 0; i < childCount; i++)
        {
            _checkPoints[i] = transform.GetChild(i).gameObject;
        }
        _checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        // _numberOfCheckpoints = _checkPoints.Length;
        
        System.Array.Reverse(_checkPoints);
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _events = GameObject.Find("Game").GetComponent<Events>();
        
        GameObject rspwn = GameObject.Find("Respawn marker");
        if (rspwn != null)
        {
            _respawnMarker = rspwn;
        }

        var lvl = GameObject.Find("Levels");
        if (lvl != null)
        {
            _levels = lvl.GetComponent<Levels>();
            var lvlNum = int.Parse(SceneManager.GetActiveScene().name.Substring(5));
            _numberOfCheckpoints = _levels.Values[lvlNum - 1];
            _events.onAssistChanged.AddListener((AssistLevel assLevel) => _numberOfCheckpoints = _levels.Values[lvlNum - 1]);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < _numberOfCheckpoints; i++)
        {
            if (_player.gameObject.transform.position.y > _checkPoints[i].transform.position.y && _checkPoints[i] != _currentCheckPoint)
            {
                _swapCheckPoint = true;
                _currentCheckPoint = _checkPoints[i];
            } 
        }

        if (_swapCheckPoint)
        {
            Debug.Log("cpl " + _checkPoints.Length);
            Debug.Log("nbr " + _numberOfCheckpoints);
            if (_currentCheckPoint.transform.position.y > _checkPoints[_numberOfCheckpoints].transform.position.y)
            {
                _currentCheckPoint.transform.position = _checkPoints[_numberOfCheckpoints].transform.position;
            }
            _player.RespawnPoint = new Vector3(0, _currentCheckPoint.transform.position.y, 0);
            _respawnMarker.transform.position = new Vector3(0, _currentCheckPoint.transform.position.y + 10.5f, 0);

            _swapCheckPoint = false;
        }
    }

    public int NumberOfCheckpoints
    {
        get => _numberOfCheckpoints;
        set => _numberOfCheckpoints = value;
    }
}
