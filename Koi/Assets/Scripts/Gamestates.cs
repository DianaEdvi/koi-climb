using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A useless class that I will deal with in the future
 */
public class Gamestates : MonoBehaviour
{
    [SerializeField] private Events _events;
    // Start is called before the first frame update
    void Start()
    {
        _events = GameObject.Find("Game").GetComponent<Events>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    public void InvokeStart()
    {
        _events.onStartLevel?.Invoke();
    }
    
}
