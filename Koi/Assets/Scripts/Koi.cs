using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * Sets movement properties for the player  
 */
public class Koi : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.05f;
    [SerializeField] private float spinSpeed = 0.05f;
    [SerializeField] private float directionSpeed = 0.05f;
    [SerializeField] private float radius = 2;
    private float _direction;
    private bool isFlipped = false;
    
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
}
