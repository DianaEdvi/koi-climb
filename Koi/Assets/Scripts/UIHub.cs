using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ReactivateUI()
    {
        canvas.gameObject.SetActive(true);
    }
}
