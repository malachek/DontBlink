using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using FMOD.Studio;


public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Range(0, 1)]

    public float masterVolume = 1;
    [Range(0, 1)]

    public float musicVolume = 1;
    [Range(0, 1)]

    public float ambianceVolume = 1;
    [Range(0, 1)]

    public float SFXVolume = 1;

    private Bus masterBus;

    private Bus musicBus;

    private Bus ambianceBus;

    private Bus sfxBus;


    private List<EventInstance> eventInstances;

    private List<StudioEventEmitter> eventEmitters;

    private EventInstance ambianceEventInstance;

    private EventInstance Act1MusicEventInstance;

    private EventInstance Act2MusicEventInstance;

    private EventInstance Act3MusicEventInstance;
    public static AudioManager instance { get; private set; }




    private void Start()
    {
      //  InitializeAmbience(FMODEvents.instance.backgroundAmbiance);
       // InitializeMusic(FMODEvents.instance.Act1Music);
       // InitializeAmbience(FMODEvents.instance.Act2Music);
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Greyboxing") //Conner'sFrickingSuperAwesomeScene
        {
            //InitializeAmbience(FMODEvents.instance.backgroundAmbiance);
            InitializeMusic(FMODEvents.instance.Act1Music);
           // InitializeMusic2(FMODEvents.instance.Act2Music);
           // InitializeMusic3(FMODEvents.instance.Act3Music);
        }
    }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene");
        }
        instance = this;
        eventInstances = new List<EventInstance>();
        eventEmitters = new List<StudioEventEmitter>();

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        ambianceBus = RuntimeManager.GetBus("bus:/Ambiance");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
    }

    
    private void Update()
    {
        {
            masterBus.setVolume(masterVolume);
            musicBus.setVolume(musicVolume);
            ambianceBus.setVolume(ambianceVolume);
            sfxBus.setVolume(SFXVolume);
        }
    }

    private void InitializeAmbience(EventReference ambianceEventReference)
    {
        ambianceEventInstance = CreateInstance(ambianceEventReference);
        ambianceEventInstance.start();
    }

    private void InitializeMusic(EventReference Act1MusicEventReverence)
    {
        Act1MusicEventInstance = CreateInstance(Act1MusicEventReverence);
        Act1MusicEventInstance.start();
    }

    private void InitializeMusic2(EventReference Act2MusicEventReverence)
    {
        Act2MusicEventInstance = CreateInstance(Act2MusicEventReverence);
        Act2MusicEventInstance.start();
    }

    private void InitializeMusic3(EventReference Act3MusicEventReverence)
    {
        Act3MusicEventInstance = CreateInstance(Act3MusicEventReverence);
        Act3MusicEventInstance.start();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    public StudioEventEmitter InitializeEventEmitter(EventReference eventReference, GameObject emitterGameObject)
    {
        StudioEventEmitter emitter = emitterGameObject.GetComponent<StudioEventEmitter>();
        emitter.EventReference = eventReference;
        eventEmitters.Add(emitter);
        return emitter;
    }

    private void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
        //stop all the event emitters, bc if not, it could hang around for future scene changes
        foreach (StudioEventEmitter emitter in eventEmitters)
        {
            emitter.Stop();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
    public void StartAct1Music()
    {
        InitializeMusic(FMODEvents.instance.Act1Music);
    }

    public void StartAct2Music()
    {
        InitializeMusic(FMODEvents.instance.Act2Music);
    }

    public void StartAct3Music()
    {
        InitializeMusic(FMODEvents.instance.Act3Music);
    }

    public void StopAct1Music()
    {
            Act1MusicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Act1MusicEventInstance.release();
        
    }

    public void StopAct2Music()
    {
        Act2MusicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Act2MusicEventInstance.release();

    }

    public void StopAct3Music()
    {
        Act3MusicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Act3MusicEventInstance.release();

    }

}
