using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Spawns food when you press shift 
 * Helps me figure out where to position the game objects for quick development
 */
public class Helper : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject collectiblePrefab;
    [SerializeField] private GameObject[] koi;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            foreach (var k in koi)
            {
                Instantiate(collectiblePrefab, k.transform.position, k.transform.rotation);
            }
        }
        
    }
}
