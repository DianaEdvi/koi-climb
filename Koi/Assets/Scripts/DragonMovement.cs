using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    private float _angle; // the current angle around the circle 
    private Koi _koi; // general properties for both koi 
    
    // Start is called before the first frame update
    void Start()
    {
        // Set variables 
        _koi = GetComponentInParent<Koi>();
    }

    private void FixedUpdate()
    {
        // Perform rotation
        _angle += _koi.SpinSpeed;

        var rotation = transform.rotation;
        transform.rotation = Quaternion.Euler(0, 0, _angle * Mathf.Rad2Deg);
        
        // Move both koi upwards 
        // Also Move koi left and right depending on input 
        var koiPositions = _koi.transform.position;
        _koi.transform.position = new Vector3(koiPositions.x + _koi.Direction * _koi.SideSpeed, koiPositions.y + _koi.RiseSpeed, koiPositions.z);
        
    }

    private void Fireballs()
    {
           
        
    }
}
