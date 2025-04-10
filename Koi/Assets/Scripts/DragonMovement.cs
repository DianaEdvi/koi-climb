using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    private float _angle; // the current angle around the circle 
    private KoiProperties _koiProperties; // general properties for both koi 
    
    // Start is called before the first frame update
    void Start()
    {
        // Set variables 
        _koiProperties = GetComponentInParent<KoiProperties>();
    }

    private void FixedUpdate()
    {
        // Perform rotation
        _angle += _koiProperties.SpinSpeed;

        var rotation = transform.rotation;
        transform.rotation = Quaternion.Euler(0, 0, _angle * Mathf.Rad2Deg);
        
        // Move both koi upwards 
        // Also Move koi left and right depending on input 
        var koiPositions = _koiProperties.transform.position;
        _koiProperties.transform.position = new Vector3(koiPositions.x + _koiProperties.Direction * _koiProperties.SideSpeed, koiPositions.y + _koiProperties.RiseSpeed, koiPositions.z);
        
    }

    
}
