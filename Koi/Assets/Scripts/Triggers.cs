using UnityEngine;

public class Triggers : MonoBehaviour
{
    private Events _events;
    
    // Start is called before the first frame update
    void Start()
    {
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
            // you might need to change it in the future to have other as a param
            if (_events != null && _events.onHit != null)
            {
                _events.onHit?.Invoke(other.gameObject.tag); 
            }
            other.gameObject.SetActive(false);
        }

        // if it's an obstacle, reset to the beginning of the level 
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (gameObject.CompareTag("Fireball"))
            {
                Debug.Log("cllision");
                other.gameObject.SetActive(false);
            }
            else if (_events != null && _events.onHit != null)
            {
                _events.onHit?.Invoke(other.gameObject.tag);
            }
            
            

          
        }
    }



}
