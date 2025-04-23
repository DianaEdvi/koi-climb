using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Handles all the inputs 
 */
public class Inputs : MonoBehaviour
{
    private Player _player;
    private Events _events;
    private Spawner _spawner;
    private float _riseSpeed;
    private float _spinSpeed;
    private float _radius;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _events = GameObject.Find("Game").GetComponent<Events>();
        _riseSpeed = _player.RiseSpeed;
        _spinSpeed = _player.SpinSpeed;
        _radius = _player.Radius;
    }

    // Update is called once per frame
    void Update()
    {

        // Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _events.onPause?.Invoke();
        }
        
        var direction = 0;

        // Direction
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
        }
        
        _player.Direction = direction;
        
        // Double speed 
        if (Input.GetKey(KeyCode.W))
        {
            _player.RiseSpeed = _player.DoubleSpeed;
            _player.SpinSpeed = _player.IsFlipped ? _player.DoubleSpinSpeed * -1 : _player.DoubleSpinSpeed;
        }
        else
        {
            _player.RiseSpeed = _riseSpeed;
            _player.SpinSpeed = _player.IsFlipped ? _spinSpeed * -1 : _spinSpeed;
        }
        
        if (SceneManager.GetActiveScene().name == "Level1") return;
        
        // Spin
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
        
        // if (SceneManager.GetActiveScene().name != "Level4" || SceneManager.GetActiveScene().name != "Level5") return;
        
        // Expand
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            _player.Radius = Mathf.Lerp(_player.Radius, _player.DoubleRadius, 0.05f);
            _player.Expanding = true;
        }
        else
        {
            _player.Radius = Mathf.Lerp(_player.Radius, _radius, 0.05f);
            _player.Expanding = false;
        }
        

    }

}
