using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{

    private Spawner _spawner;

    private void Start()
    {
        _spawner = GameObject.Find("Spawners").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += transform.up * (_spawner.FireSpeed * Time.fixedDeltaTime);
    }
}
