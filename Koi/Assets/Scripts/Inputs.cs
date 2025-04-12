using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles all the inputs 
 */
public class Inputs : MonoBehaviour
{
    private Koi _koi;
    private ExplodeTheSun _explodeTheSun;
    private Events _events;
    
    // Start is called before the first frame update
    void Start()
    {
        _koi = GameObject.FindGameObjectWithTag("Player").GetComponent<Koi>();
        _events = GameObject.Find("Game").GetComponent<Events>();
        _explodeTheSun = GameObject.Find("Game").GetComponent<ExplodeTheSun>();

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

        // Space is for the dragon stuff 
        if (Input.GetKeyDown(KeyCode.Space) && _explodeTheSun.ReadyToExplode) // i think this needs to be changed to false right after the space in order to allow for future space presses for fireballs
        {
            if (_events != null && _events.onDragonTime != null)
            {
              _events.onDragonTime?.Invoke();   
            }
        }

    }

}
