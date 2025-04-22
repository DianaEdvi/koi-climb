using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles all the inputs 
 */
public class Inputs : MonoBehaviour
{
    private Player _player;
    private ExplodeTheSun _explodeTheSun;
    private Events _events;
    // [SerializeField] private GameObject dragon;
    private Spawner _spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _events = GameObject.Find("Game").GetComponent<Events>();
        _explodeTheSun = GameObject.Find("Game").GetComponent<ExplodeTheSun>();
        // _spawner = dragon.GetComponentInChildren<Spawner>();

    }

    // Update is called once per frame
    void Update()
    {
        // This is kind of ass and needs to be reworked. i want controller support as well

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pressed esc");
            _events.onPause?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _player.SpinSpeed = Mathf.Abs(_player.SpinSpeed);
            _player.IsFlipped = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _player.SpinSpeed = Mathf.Abs(_player.SpinSpeed) * -1;
            _player.IsFlipped = true;
        } 
        
        if (Input.GetKey(KeyCode.A))
        {
            _player.Direction = -1;
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _player.Direction = 1;
            return;
        }
        _player.Direction = 0;

        // Space is for the dragon stuff 
        if (Input.GetKeyDown(KeyCode.Space)) // i think this needs to be changed to false right after the space in order to allow for future space presses for fireballs
        {
            // // first check if dragon is already active before firing
            // if (dragon.activeSelf)
            // {
            //     _spawner.Launch = true;
            //     // Debug.Log("shoot fireballs");
            // }
            
            // activate dragon
            if (_explodeTheSun.ReadyToExplode)
            {
                if (_events != null && _events.onDragonTime != null)
                {
                  _events.onDragonTime?.Invoke();   
                }
            }
        }
    }

}
