using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * Binds the player to the confines of the background 
 */
public class BoundToBackground : MonoBehaviour
{

    private GameObject _koi; 
    [SerializeField] private Collider2D bounds;
    [SerializeField] private Collider2D koiCollider; 
    private float _koiColliderRadius; 
    
    // Start is called before the first frame update
    void Start()
    {
        _koi = gameObject;
        _koiColliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        // bind the bounds to the outer collider, accounting for the radius of the collider 
        var xBound = Mathf.Clamp(koiCollider.transform.position.x, bounds.bounds.min.x + _koiColliderRadius, bounds.bounds.max.x - _koiColliderRadius);
        var yBound = Mathf.Clamp(koiCollider.transform.position.y, bounds.bounds.min.y + _koiColliderRadius, bounds.bounds.max.y - _koiColliderRadius);

        _koi.transform.position = new Vector3(xBound, yBound, _koi.transform.position.z);
    }
}
