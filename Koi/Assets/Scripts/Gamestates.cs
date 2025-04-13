using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestates : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 RespawnPoint
    {
        get => respawnPoint;
        set => respawnPoint = value;
    }
}
