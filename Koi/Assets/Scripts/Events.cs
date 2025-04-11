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
    public UnityEvent<string> onHit;
        
        // Start is called before the first frame update
    void Start()
    {
        // Create events if not null
        onActivateDragon ??= new UnityEvent();
        onHit ??= new UnityEvent<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
