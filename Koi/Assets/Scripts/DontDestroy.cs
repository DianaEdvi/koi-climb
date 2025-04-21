using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        // Check if a duplicate of this object already exists (based on name and tag if you want)
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        foreach (GameObject obj in objs)
        {
            if (obj != gameObject && obj.name == gameObject.name)
            {
                Destroy(gameObject); // Prevent duplicates if necessary
                return;
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}