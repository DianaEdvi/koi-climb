using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitObjects : MonoBehaviour
{
    private Events _events;
    private SpriteRenderer _sun;
    private GameObject[] _collectibles;
    private Player _player;
    private Gamestates _gamestates;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find objects
        _events = GameObject.Find("Game").GetComponent<Events>();
        _gamestates = GameObject.Find("Game").GetComponent<Gamestates>();
        if (GameObject.Find("Sun"))
        {
            _sun = GameObject.Find("Sun").GetComponent<SpriteRenderer>();
        }
        _collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        // Add listeners
        _events.onHit.AddListener(Hit);
    }

    /**
     * Handles the logic when a triggerable object (collectibles, obstacles) are interacted with 
     */
    private void Hit(string type)
    {
        switch (type)
        {
            case "Collectible":
                //increase alpha and activate the sun
                if (_sun == null) return;
                var sunColor = _sun.color;
                _sun.color = new Color(sunColor.r, sunColor.g, sunColor.b, sunColor.a + 0.5f);
                if (_sun.color.a >= 1 && _events != null && _events.onActivateSun != null)
                {
                    _events.onActivateSun?.Invoke();
                }
                break;
            case "Obstacle":
                //return to front
                _events.onRespawnPlayer?.Invoke(_player.RespawnPoint);
                Debug.Log(_player.RespawnPoint);
                // _koi.gameObject.transform.position = _gamestates.RespawnPoint;
                foreach (var collectible in _collectibles)
                {
                    collectible.gameObject.SetActive(true);
                }
                break;
            default:
                return;
        }
    }

   
}
