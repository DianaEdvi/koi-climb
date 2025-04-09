using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private KoiProperties _koiProperties; // general properties for both koi 
    
    // Start is called before the first frame update
    void Start()
    {
        // Set variables 
        _position = transform;
        _origin = new Vector3(0,0,0);
        _angle += startAngle;
        _koiProperties = GetComponentInParent<KoiProperties>();
    }

    private void FixedUpdate()
    {
        // Perform rotation
        _angle += _koiProperties.SpinSpeed;
        _position.localPosition = new Vector3(_origin.x + _koiProperties.Radius * Mathf.Cos(_angle), _origin.y + _koiProperties.Radius * Mathf.Sin(_angle), 0);
        
        // Move both koi upwards 
        // Also Move koi left and right depending on input 
        var koiPositions = _koiProperties.transform.position;
        _koiProperties.transform.position = new Vector3(koiPositions.x + _koiProperties.Direction * _koiProperties.SideSpeed, koiPositions.y + _koiProperties.RiseSpeed, koiPositions.z);
        
    }
}
