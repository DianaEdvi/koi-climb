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
    private float _direction;
    private bool isFlipped = false;
    [SerializeField] private Vector3 respawnPoint;
    private GameObject _respawnMarker;
    private Events _events;

    private void Start()
    {
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onRespawnPlayer.AddListener(RespawnPlayer);
        _respawnMarker = GameObject.Find("Respawn marker");
    }

    private void Update()
    {
        _respawnMarker.transform.position = respawnPoint;
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

    private void RespawnPlayer(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
        respawnPoint = spawnPoint;
        _respawnMarker.transform.position = spawnPoint;
    }
}
