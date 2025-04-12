using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitObjects : MonoBehaviour
{
    private Events _events;
    private SpriteRenderer _sun;
    private GameObject[] _collectibles;
    private Koi _koi;
    
    // Start is called before the first frame update
    void Start()
    {
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onHit.AddListener(Hit);
        _sun = GameObject.Find("Sun").GetComponent<SpriteRenderer>();
        _collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        _koi = GameObject.FindGameObjectWithTag("Player").GetComponent<Koi>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Hit(string type)
    {
        switch (type)
        {
            case "Collectible":
                //increase alpha
                var sunColor = _sun.color;
                _sun.color = new Color(sunColor.r, sunColor.g, sunColor.b, sunColor.a + 0.5f);
                if (_sun.color.a >= 1 && _events != null && _events.onActivateDragon != null)
                {
                    _events.onActivateDragon?.Invoke();
                }
                break;
            case "Obstacle":
                //return to front
                _koi.gameObject.transform.position = new Vector3(0, 0, 0);
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
