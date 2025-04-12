using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/**
 * Science compels us to explode the sun.
 * Actually, it handles the sun and creature swapping logic 
 */
public class ExplodeTheSun : MonoBehaviour
{
    private SpriteRenderer _sun;
    private Events _events;
    [SerializeField] private GameObject koi;
    [SerializeField] private GameObject dragon;
    private bool _readyToExplode;

    public bool ReadyToExplode => _readyToExplode;
    
    // Start is called before the first frame update
    void Start()
    {
        _sun = GameObject.Find("Sun").GetComponent<SpriteRenderer>();
        _events = GameObject.Find("Game").GetComponent<Events>();
        _events.onActivateSun.AddListener(ChangeSunColor);
        _events.onDragonTime.AddListener(StartDragonTimer);
        // _events.onActivateDragon.AddListener(StartDragonTimer);

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
        _readyToExplode = true;
        // add audio and shit here 
    }
    
    /**
     * Toggle the active status of the creatures 
     */
    private void SwapCreatures()
    {
        // Gonna have to code in waiting for the sun to explode 
        dragon.gameObject.SetActive(!dragon.gameObject.activeSelf);
        koi.gameObject.SetActive(!koi.gameObject.activeSelf);

    }

    /**
     * i dont think you can add a coroutine to an event so thats why this is here 
     */
    private void StartDragonTimer()
    {
        SwapCreatures();
        StartCoroutine(DragonTimer());
    }

    /**
     * Counts down the amount of time the dragon state will be active 
     */
    IEnumerator DragonTimer()
    {
        yield return new WaitForSeconds(3);
        SwapCreatures();
        _sun.color = new Color(_sun.color.r,_sun.color.g,_sun.color.b,0);
        _readyToExplode = false;

    }
}
