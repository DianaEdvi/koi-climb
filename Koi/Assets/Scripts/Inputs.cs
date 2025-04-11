using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles all the inputs 
 */
public class Inputs : MonoBehaviour
{
    private Koi _koi;
    // Start is called before the first frame update
    void Start()
    {
        _koi = GameObject.FindGameObjectWithTag("Player").GetComponent<Koi>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is kind of ass and needs to be reworked. i want controller support as well
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _koi.SpinSpeed = Mathf.Abs(_koi.SpinSpeed);
            _koi.IsFlipped = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _koi.SpinSpeed = Mathf.Abs(_koi.SpinSpeed) * -1;
            _koi.IsFlipped = true;
        } 
        
        if (Input.GetKey(KeyCode.A))
        {
            _koi.Direction = -1;
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _koi.Direction = 1;
            return;
        }
        _koi.Direction = 0;
    }
}
