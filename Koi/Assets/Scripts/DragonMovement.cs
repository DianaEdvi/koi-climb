using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    private Transform _position; // the koi's position
    private Vector3 _leftOrigin; // the point to circle around
    private Vector3 _rightOrigin; // the point to circle around
    private Vector3 _currentOrigin; // the point to circle around
    private float _angle; // the current angle around the circle 
    [SerializeField] private float startAngle; // the start angle
    private KoiProperties _koiProperties; // general properties for both koi 
    
    // Start is called before the first frame update
    void Start()
    {
        // Set variables 
        _position = transform;
        _leftOrigin = new Vector3(-2,0,0);
        _rightOrigin = new Vector3(2,0,0);
        _currentOrigin = _leftOrigin;
        _angle += startAngle;
        _koiProperties = GetComponentInParent<KoiProperties>();
    }

    private void FixedUpdate()
    {
        // Perform rotation
        _angle += _koiProperties.SpinSpeed;
        _position.localPosition = new Vector3(_currentOrigin.x + _koiProperties.Radius * Mathf.Cos(_angle), _currentOrigin.y + _koiProperties.Radius * Mathf.Sin(_angle), 0);

        if (_currentOrigin == _leftOrigin && _angle - (2 * Mathf.PI) < 0.1 && _angle - (2 * Mathf.PI) > 0)
        {
            SwapOrigin();
        }
        else if (_currentOrigin == _rightOrigin && Mathf.Abs(_angle) - Mathf.PI < 0.1 &&
                 Mathf.Abs(_angle) - Mathf.PI > 0)
        {
            SwapOrigin();
        }
        
        // // Move both koi upwards 
        // // Also Move koi left and right depending on input 
        var koiPositions = _koiProperties.transform.position;
        _koiProperties.transform.position = new Vector3(koiPositions.x + _koiProperties.Direction * _koiProperties.SideSpeed, koiPositions.y + _koiProperties.RiseSpeed, koiPositions.z);
        
    }

    private void SwapOrigin()
    {
        if (_currentOrigin == _leftOrigin)
        {
            _currentOrigin = _rightOrigin;
            _koiProperties.SpinSpeed = Mathf.Abs(_koiProperties.SpinSpeed) * -1;
            _angle = 0 + Mathf.PI;
        }
        else if (_currentOrigin == _rightOrigin)
        {
            _currentOrigin = _leftOrigin;
            _koiProperties.SpinSpeed = Mathf.Abs(_koiProperties.SpinSpeed);
            _angle = 0;
        }
    }
    
}
