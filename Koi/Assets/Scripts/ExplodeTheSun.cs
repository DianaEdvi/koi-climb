using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeTheSun : MonoBehaviour
{
    private SpriteRenderer _sun;
    private Events _events;


    // Start is called before the first frame update
    void Start()
    {
        _sun = GameObject.Find("Sun").GetComponent<SpriteRenderer>();
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onActivateDragon.AddListener(ChangeSunColor);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void ChangeSunColor()
    {
        _sun.color = new Color(0, _sun.color.g, _sun.color.b, _sun.color.a);
        Debug.Log("VAR");
        // add audio and shit here 
    }
}
