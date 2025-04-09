using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * Sets general properties for the koi fish and handles user input 
 */
public class KoiProperties : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.05f;
    [SerializeField] private float spinSpeed = 0.05f;
    [SerializeField] private float sideSpeed = 0.05f;
    [SerializeField] private float radius = 2;
    private float _direction;
    
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
        get => sideSpeed;
        set => sideSpeed = value;
    }


    // Update is called once per frame
    void Update()
    {
        // This is kind of ass and needs to be reworked. i want controller support as well
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SpinSpeed = Mathf.Abs(SpinSpeed);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SpinSpeed = Mathf.Abs(SpinSpeed) * -1;
        } 
        
        if (Input.GetKey(KeyCode.A))
        {
            _direction = -1;
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction = 1;
            return;
        }
        _direction = 0;
    }
}
