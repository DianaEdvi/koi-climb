using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    private KoiProperties _koiProperties;
    
    // Start is called before the first frame update
    void Start()
    {
        _koiProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<KoiProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Obsticle"))
        {
            _koiProperties.gameObject.transform.position = new Vector3(0, 0, 0);
        }
        
    }
}
