using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

/**
 * Moves the koi fish 
 */
public class Movement : MonoBehaviour
{

    private Transform _position; // the koi's position
    private Vector3 _origin; // the point to circle around
    private float _angle; // the current angle around the circle 
    [SerializeField] private float startAngle; // the start angle
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 startRotation;
    private Player _player; // general properties for both koi 
    [SerializeField] private string creatureType;
    private bool _movePlayer;
    private Events _events;
    private string _sceneName;
    private float _startRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            _movePlayer = true;
        }
        else
        {
            _movePlayer = false;
        }
        // Set variables 
        _position = transform;
        _origin = new Vector3(0,0,0);
        _angle += startAngle;
        _player = GetComponentInParent<Player>();
        GameObject gameObj = GameObject.Find("Game");
        if (gameObj != null)
        {
            _events = gameObj.GetComponent<Events>();
            _events.onEndLevel.AddListener((() => _movePlayer = false));
            _events.onRespawnPlayer.AddListener(ResetPosition);
            _events.onPause.AddListener(() => _movePlayer = !_movePlayer);
        }

        _sceneName = SceneManager.GetActiveScene().name;
        _startRadius = _player.Radius;
    }

    private void Update()
    {
        LevelRequirements(_sceneName);
    }

    private void FixedUpdate()
    {
        if (!_movePlayer)
        {
            return;
        }
        
        // Increase angle according to speed
        _angle += _player.SpinSpeed;
        
        MovementSpecifics(creatureType);

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            return;
        }
        // Move both koi upwards and move koi left and right depending on input 
        var koiPositions = _player.transform.position;
        _player.transform.position = new Vector3(koiPositions.x + _player.Direction * _player.SideSpeed, koiPositions.y + _player.RiseSpeed, koiPositions.z);
    }

    // Applies specific movements that are unique to each creature 
    // ReSharper disable Unity.PerformanceAnalysis
    private void MovementSpecifics(string creature)
    {
        switch (creature)
        {
            case "Koi":
           
                _position.localPosition = new Vector3(_origin.x + _player.Radius * Mathf.Cos(_angle), _origin.y + _player.Radius * Mathf.Sin(_angle), 0);
        
                // Apply spin on Z rotation to stay aligned with the circle 
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + _player.SpinSpeed * Mathf.Rad2Deg);
                break;
            case "Dragon":
                // Spin the dragon
                var rotation = transform.rotation;
                transform.rotation = Quaternion.Euler(0, 0, _angle * Mathf.Rad2Deg);
                break;
            default:
                Debug.LogError("Misspelled creature type");
                return;
        }
    }

    /**
     * Returns koi fish to base positions when respawn
     */
    private void ResetPosition(Vector3 wtv)
    {
        transform.rotation = Quaternion.Euler(startRotation);
        transform.localPosition = startPosition;
        _angle = startAngle;
    }

    private void LevelRequirements(string sceneName)
    {
        switch (sceneName)
        {
            case "Level1":
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    _movePlayer = true;
                }
                break;
            case "Level2":
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    _movePlayer = true;
                }
                break;
            case "Level3":
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) 
                    || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    _movePlayer = true;
                }
                break;
            case "Level4":
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    _movePlayer = true;
                }
                break;
                default:
                    return;
                
            
        }
    }
}
