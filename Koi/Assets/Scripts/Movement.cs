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
    [SerializeField] private float startRotation; // the start angle
    private Koi _koi; // general properties for both koi 
    private int _rotation = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set variables 
        _position = transform;
        _origin = new Vector3(0,0,0);
        _angle += startAngle;
        _koi = GetComponentInParent<Koi>();
    }

    private void FixedUpdate()
    {
        // Perform rotation
        _angle += _koi.SpinSpeed;
        _position.localPosition = new Vector3(_origin.x + _koi.Radius * Mathf.Cos(_angle), _origin.y + _koi.Radius * Mathf.Sin(_angle), 0);
        
        // Apply spin on Z rotation to stay in the circle 
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + _koi.SpinSpeed * Mathf.Rad2Deg);
        
        // Move both koi upwards and move koi left and right depending on input 
        var koiPositions = _koi.transform.position;
        _koi.transform.position = new Vector3(koiPositions.x + _koi.Direction * _koi.SideSpeed, koiPositions.y + _koi.RiseSpeed, koiPositions.z);
        
    }
}
