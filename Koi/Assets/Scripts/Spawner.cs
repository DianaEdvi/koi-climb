using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * For spawning fireballs 
 */
public class Spawner : MonoBehaviour {
        
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _spawner;
    private GameObject[] _spawns;
    [SerializeField] private float fireSpeed = 1;
    private bool _launch;
    
    // Start is called before the first frame update
    void Start()
    {
        _spawner = gameObject;
        var childCount = _spawner.transform.childCount;
        _spawns = new GameObject[childCount];

        /**
         * Store all spawners
         */
        for (var i = 0; i < childCount; i++)
        {
            _spawns[i] = _spawner.transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        // Spawn all the fireballs. Launch is there for a reason and i dont remember why 
        if (_launch)
        {
            foreach (var spawn in _spawns)
            {
                Instantiate(fireballPrefab, spawn.transform.position, spawn.transform.rotation);
            }

            _launch = false;
        }

    }

    public float FireSpeed
    {
        get => fireSpeed;
        set => fireSpeed = value;
    }

    public bool Launch
    {
        get => _launch;
        set => _launch = value;
    }
}