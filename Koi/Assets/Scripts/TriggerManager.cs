using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    private KoiProperties _koiProperties;
    private GameObject[] _collectibles;
    private SpriteRenderer _sun;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _koiProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<KoiProperties>();
        _collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        _sun = GameObject.Find("Sun").GetComponent<SpriteRenderer>();
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
            _sun.color = new Color(sunColor.r, sunColor.g, sunColor.b, sunColor.a + 0.1f);
        }

        // if it's an obstacle, reset to the beginning of the level 
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _koiProperties.gameObject.transform.position = new Vector3(0, 0, 0);
            foreach (var collectible in _collectibles)
            {
                collectible.gameObject.SetActive(true);
            }
        }
        
    }
}
