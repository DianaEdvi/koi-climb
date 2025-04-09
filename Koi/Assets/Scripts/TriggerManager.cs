using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    private KoiProperties _koiProperties;
    private GameObject[] _collectibles;
    
    // Start is called before the first frame update
    void Start()
    {
        _koiProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<KoiProperties>();
        _collectibles = GameObject.FindGameObjectsWithTag("Collectible");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
        }

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
