using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class FMODEvents : MonoBehaviour
{

    [field: Header("Radio SFX")]
    [field: SerializeField] public EventReference RadioPlayer { get; private set; }

    [field: Header("backgroundAmbiance")]
    [field: SerializeField] public EventReference backgroundAmbiance { get; private set; }

    [field: Header("Act1Music")]
    [field: SerializeField] public EventReference Act1Music { get; private set; }

    [field: Header("Act2Music")]
    [field: SerializeField] public EventReference Act2Music { get; private set; }

    [field: Header("Act3Music")]
    [field: SerializeField] public EventReference Act3Music { get; private set; }


    [field: Header("Notification")]
    [field: SerializeField] public EventReference Notification { get; private set; }

    [field: Header("Hover")]
    [field: SerializeField] public EventReference Hover { get; private set; }

    [field: Header("BeanBag")]
    [field: SerializeField] public EventReference BeanBag { get; private set; }

    [field: Header("Click")]
    [field: SerializeField] public EventReference Click { get; private set; }

    [field: Header("Guitar")]
    [field: SerializeField] public EventReference Guitar { get; private set; }

    [field: Header("Piano")]
    [field: SerializeField] public EventReference Piano { get; private set; }

    [field: Header("Achievement")]
    [field: SerializeField] public EventReference Achievement { get; private set; }

    [field: Header("Piano2")]
    [field: SerializeField] public EventReference Piano2 { get; private set; }

    [field: Header("Piano3")]
    [field: SerializeField] public EventReference Piano3 { get; private set; }

    [field: Header("Piano4")]
    [field: SerializeField] public EventReference Piano4 { get; private set; }


    //Example for future one shot referrences
    //AudioManager.instance.PlayOneShot(FMODEvents.instance.sonarPing, this.transform.position);
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events scripts in the scene");
        }
        instance = this;
    }

    public void HoverPlay()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Hover, this.transform.position);


    }

    
}
