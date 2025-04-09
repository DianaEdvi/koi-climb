using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{

    private Transform _position;
    private Vector3 _origin;
    private float _angle;
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private float startAngle;
    [SerializeField] private float radius = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        _position = transform;
        _origin = new Vector3(0,0,0);
        _angle += startAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            speed *= -1;
        }

    }

    private void FixedUpdate()
    {
        _angle += speed;
        _position.position = new Vector3(_origin.x + radius * Mathf.Cos(_angle), _origin.y + radius * Mathf.Sin(_angle), 0);
    }
}
