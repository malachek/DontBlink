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
