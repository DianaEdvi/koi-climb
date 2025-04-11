using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    private Koi _koi;
    private GameObject[] _collectibles;
    private SpriteRenderer _sun;
    private Events _events;
    
    // Start is called before the first frame update
    void Start()
    {
        _koi = GameObject.FindGameObjectWithTag("Player").GetComponent<Koi>();
        _collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        _sun = GameObject.Find("Sun").GetComponent<SpriteRenderer>();
        _events = GameObject.Find("Game").GetComponent<Events>();
    }
    
    /**
     * Handles collisions 
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the object is a collectible, consume it and increase the sun alpha channel
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            var sunColor = _sun.color;
            _sun.color = new Color(sunColor.r, sunColor.g, sunColor.b, sunColor.a + 0.5f);
            if (_sun.color.a >= 1 && _events != null && _events.onActivateDragon != null)
            {
                Debug.Log("it is");
                _events.onActivateDragon?.Invoke();
            }
        }

        // if it's an obstacle, reset to the beginning of the level 
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _koi.gameObject.transform.position = new Vector3(0, 0, 0);
            foreach (var collectible in _collectibles)
            {
                collectible.gameObject.SetActive(true);
            }
        }
    }



}
