using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ExplodeTheSun : MonoBehaviour
{
    private SpriteRenderer _sun;
    private Events _events;
    [SerializeField] private GameObject koi;
    [SerializeField] private GameObject dragon;


    // Start is called before the first frame update
    void Start()
    {
        _sun = GameObject.Find("Sun").GetComponent<SpriteRenderer>();
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onActivateDragon.AddListener(ChangeSunColor);
        _events.onActivateDragon.AddListener(StartDragonTimer);

        if (koi == null || dragon == null)
        {
            Debug.LogError("One or more of your creatures are not assigned in the inspector");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void ChangeSunColor()
    {
        _sun.color = new Color(0, _sun.color.g, _sun.color.b, _sun.color.a);
        // add audio and shit here 
    }
    
    /**
     * Change the active status of the creatures 
     */
    private void SwapCreatures()
    {
        // Gonna have to code in waiting for the sun to explode 
        dragon.gameObject.SetActive(!dragon.gameObject.activeSelf);
        koi.gameObject.SetActive(!koi.gameObject.activeSelf);

    }

    private void StartDragonTimer()
    {
        SwapCreatures();
        StartCoroutine(DragonTimer());
    }

    IEnumerator DragonTimer()
    {
        yield return new WaitForSeconds(3);
        SwapCreatures();
        _sun.color = new Color(_sun.color.r,_sun.color.g,_sun.color.b,0);

    }
}
