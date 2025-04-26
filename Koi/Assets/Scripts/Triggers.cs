using System.Collections;
using UnityEngine;

/**
 * Deals with the collisions and calling the appropriate methods 
 */
public class Triggers : MonoBehaviour
{
    private Events _events;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Game"))
        {
            _events = GameObject.Find("Game").GetComponent<Events>();
        }
    }
    
    /**
     * Handles collisions 
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the object is a collectible, consume it and increase the sun alpha channel
        if (other.gameObject.CompareTag("Collectible"))
        {
            // you might need to change it in the future to have other as a param
            if (_events != null && _events.onHit != null)
            {
                _events.onHit?.Invoke(other.gameObject.tag); 
            }
            var aud = other.GetComponent<AudioSource>();
                aud.Play();
                
                var sr = other.GetComponent<SpriteRenderer>();
                var color = sr.color;
                color.a = 0f; // 0 = fully transparent
                sr.color = color;

                var col = other.GetComponent<Collider2D>();
                col.enabled = false;


        }

        // if it's an obstacle, reset to the beginning of the level 
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.GetComponent<AudioSource>().Play();
            if (gameObject.CompareTag("Fireball"))
            {
                // other.gameObject.SetActive(false);
            }
            else if (_events != null && _events.onHit != null)
            {
                _events.onHit?.Invoke(other.gameObject.tag);
            }
        }

        // End the level and reset the player to the beginning 
        if (other.gameObject.CompareTag("EndOfLevel"))
        {
            _events.onEndLevel?.Invoke();
            var koi = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            koi.RespawnPoint = new Vector3(0, 0, 0);
            _events.onRespawnPlayer?.Invoke(koi.RespawnPoint);
            Debug.Log("level ended");
        }
    }

    IEnumerator Wait(GameObject other)
    {
        yield return new WaitForSeconds(0.5f);
        other.gameObject.SetActive(false);

    }



}
