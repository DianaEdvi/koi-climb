using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

/**
 * Container for all my events 
 */
public class Events : MonoBehaviour
{ 
    public UnityEvent onActivateDragon;
    // create one for collectibles 
    // create one for destructibles 
        
        // Start is called before the first frame update
    void Start()
    {
        if (onActivateDragon == null)
        {
            onActivateDragon = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
