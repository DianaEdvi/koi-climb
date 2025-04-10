using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles all the inputs 
 */
public class InputManager : MonoBehaviour
{
    private KoiProperties _koiProperties;
    // Start is called before the first frame update
    void Start()
    {
        _koiProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<KoiProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is kind of ass and needs to be reworked. i want controller support as well
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _koiProperties.SpinSpeed = Mathf.Abs(_koiProperties.SpinSpeed);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _koiProperties.SpinSpeed = Mathf.Abs(_koiProperties.SpinSpeed) * -1;
        } 
        
        if (Input.GetKey(KeyCode.A))
        {
            _koiProperties.Direction = -1;
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _koiProperties.Direction = 1;
            return;
        }
        _koiProperties.Direction = 0;
    }
}
