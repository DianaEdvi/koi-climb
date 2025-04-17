using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private GameObject[] _checkPoints;
    private Player _player;
    private Events _events;
    private bool _swapCheckPoint;
    private GameObject _currentCheckPoint;
    // Start is called before the first frame update
    void Start()
    {
        
        var childCount = transform.childCount;
        _checkPoints = new GameObject[childCount];

        for (var i = 0; i < childCount; i++)
        {
            Debug.Log("higher");
            _checkPoints[i] = transform.GetChild(i).gameObject;
        }
        
        _checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _events = GameObject.Find("Game").GetComponent<Events>();

        foreach (var VARIABLE in _checkPoints)
        {
            Debug.Log(VARIABLE.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = _checkPoints.Length - 1; i >= 0; i--)
        {
            if (_player.gameObject.transform.position.y > _checkPoints[i].transform.position.y && _checkPoints[i] != _currentCheckPoint)
            {
                Debug.Log("VAR");
                _swapCheckPoint = true;
                _currentCheckPoint = _checkPoints[i];
            } 
        }

        if (_swapCheckPoint)
        {
            _player.RespawnPoint = new Vector3(0, _currentCheckPoint.transform.position.y, 0);
            _swapCheckPoint = false;
        }
    }
}
