using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * Sets movement properties for the player  
 */
public class Player : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.05f;
    [SerializeField] private float spinSpeed = 0.05f;
    [SerializeField] private float directionSpeed = 0.05f;
    [SerializeField] private float radius = 2;
    [SerializeField] private float doubleSpeed = 0.1f;
    [SerializeField] private float doubleSpinSpeed = 0.06f;
    [SerializeField] private float doubleRadius = 0.1f;
    private float _direction;
    private bool isFlipped = false;
    [SerializeField] private Vector3 respawnPoint;
    private GameObject _respawnMarker;
    private Events _events;
    private bool _expanding = false;
    private void Start()
    {
        GameObject gameObj = GameObject.Find("Game");
        if (gameObj != null)
        {
            _events = gameObj.GetComponent<Events>();
            _events.onRespawnPlayer.AddListener(RespawnPlayer);
            
        }
        
        GameObject rspwn = GameObject.Find("Respawn marker");
        if (rspwn != null)
        {
            _respawnMarker = rspwn;
        }
    }

    public float RiseSpeed
    {
        get => riseSpeed;
        set => riseSpeed = value;
    }
    public float SpinSpeed
    {
        get => spinSpeed;
        set => spinSpeed = value;
    }

    public float Radius
    {
        get => radius;
        set => radius = value;
    }

    public float Direction
    {
        get => _direction;
        set => _direction = value;
    }

    public float SideSpeed
    {
        get => directionSpeed;
        set => directionSpeed = value;
    }

    public bool IsFlipped
    {
        get => isFlipped;
        set => isFlipped = value;
    }
    
    public Vector3 RespawnPoint
    {
        get => respawnPoint;
        set => respawnPoint = value;
    }

    public float DoubleSpeed
    {
        get => doubleSpeed;
        set => doubleSpeed = value;
    }

    public float DoubleSpinSpeed
    {
        get => doubleSpinSpeed;
        set => doubleSpinSpeed = value;
    }

    public float DoubleRadius
    {
        get => doubleRadius;
        set => doubleRadius = value;
    }

    public bool Expanding
    {
        get => _expanding;
        set => _expanding = value;
    }

    /**
     * Resets the position of the parent player object to the most recent spawnpoint  
     */
    private void RespawnPlayer(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
        respawnPoint = spawnPoint;
        _respawnMarker.transform.position = new Vector3(0, spawnPoint.y + 10.5f, 0);
    }
}
