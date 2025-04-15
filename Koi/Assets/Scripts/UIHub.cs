using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * For managing UI
 */
public class UIHub : MonoBehaviour
{
    private Events _events;
    [SerializeField] private Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onEndLevel.AddListener(ReactivateUI);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReactivateUI()
    {
        canvas.gameObject.SetActive(true);
    }
}
