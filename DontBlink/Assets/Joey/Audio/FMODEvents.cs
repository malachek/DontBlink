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

    [field: Header("Mom_1")]
    [field: SerializeField] public EventReference Mom_1 { get; private set; }

    [field: Header("Mom_2")]
    [field: SerializeField] public EventReference Mom_2 { get; private set; }

    [field: Header("Mom_3")]
    [field: SerializeField] public EventReference Mom_3 { get; private set; }

    [field: Header("Mom_4")]
    [field: SerializeField] public EventReference Mom_4 { get; private set; }

    [field: Header("Mom_5")]
    [field: SerializeField] public EventReference Mom_5 { get; private set; }

    [field: Header("Mom_6")]
    [field: SerializeField] public EventReference Mom_6 { get; private set; }

    [field: Header("Mom_7")]
    [field: SerializeField] public EventReference Mom_7 { get; private set; }

    [field: Header("Mom_8")]
    [field: SerializeField] public EventReference Mom_8 { get; private set; }

    [field: Header("Mom_9")]
    [field: SerializeField] public EventReference Mom_9 { get; private set; }

    [field: Header("Mom_10")]
    [field: SerializeField] public EventReference Mom_10 { get; private set; }

    [field: Header("Mom_11")]
    [field: SerializeField] public EventReference Mom_11 { get; private set; }

    [field: Header("Mom_12")]
    [field: SerializeField] public EventReference Mom_12 { get; private set; }

    [field: Header("Mom_13")]
    [field: SerializeField] public EventReference Mom_13 { get; private set; }

    [field: Header("Mom_14")]
    [field: SerializeField] public EventReference Mom_14 { get; private set; }

    [field: Header("Mom_15")]
    [field: SerializeField] public EventReference Mom_15 { get; private set; }

    [field: Header("Mom_16")]
    [field: SerializeField] public EventReference Mom_16 { get; private set; }


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
