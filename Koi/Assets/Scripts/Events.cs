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
    public UnityEvent onActivateSun;
    public UnityEvent onDragonTime;
    public UnityEvent<string> onHit;
    public UnityEvent onEndLevel;
    public UnityEvent onStartLevel;
    public UnityEvent<Vector3> onRespawnPlayer;
    public UnityEvent<string> onChangeScene;
    public UnityEvent onPause;
        
        // Start is called before the first frame update
    void Start()
    {
        // Create events if not null
        onActivateSun ??= new UnityEvent();
        onHit ??= new UnityEvent<string>();
        onDragonTime ??= new UnityEvent();
        onEndLevel ??= new UnityEvent();
        onRespawnPlayer ??= new UnityEvent<Vector3>();
        onChangeScene ??= new UnityEvent<string>();
        onPause ??= new UnityEvent();
    }

}
