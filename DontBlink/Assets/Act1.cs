
using Oculus.Platform;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Act1 : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToDisableOnStart;
    private void Awake()
    {
        DisableEverything();

    }
    private void DisableEverything()
    {
        for (int i = 0; i < objectsToDisableOnStart.Length; i++)
        {
            objectsToDisableOnStart[i].SetActive(false);
        }
    }
    [SerializeField] Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera.farClipPlane = 1f;
        PlayQuitCanvas.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField] Canvas PlayQuitCanvas;
    public void Play()
    {
        PlayQuitCanvas.gameObject.SetActive(false);
        AudioManager.instance.StartAct1Music();
        StartCoroutine(IncreaseClippingView());
        BedPrompt();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Click, this.transform.position);
    }

    public void Quit()
    {
        UnityEngine.Application.Quit();
    }


    [SerializeField] Spawner bedLookAt;
    private void BedPrompt()
    {
        
        bedLookAt.gameObject.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Hover, this.transform.position);
        bedLookAt.activated.AddListener(BedLookedAt);
    }

    [SerializeField] GameObject bed;
    private void BedLookedAt()
    {
        bedLookAt.activated.RemoveListener(BedLookedAt);
        bedLookAt.gameObject.SetActive(false);
       

        bed.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Notification, this.transform.position);
        //AudioManager.instance.StopAct1Music();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Mom_1, this.transform.position);

        Debug.Log("trying to Start music");
        Invoke("DeskPrompt", 5f);
    }
    private IEnumerator IncreaseClippingView()
    {
        float targetFarClip = 20f;
        float duration = 2f; // duration of the transition in seconds
        float elapsed = 0f;
        float initialFarClip = camera.farClipPlane;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            camera.farClipPlane = Mathf.Lerp(initialFarClip, targetFarClip, elapsed / duration);
            yield return null;
        }
        camera.farClipPlane = targetFarClip; // ensure it reaches the target value
    }

    [SerializeField] Spawner deskLookAt;
    private void DeskPrompt()
    {
        deskLookAt.gameObject.SetActive(true);
        deskLookAt.activated.AddListener(DeskLookedAt);
    }
    [SerializeField] GameObject desk;
    private void DeskLookedAt()
    {
        deskLookAt.activated.RemoveListener(DeskLookedAt);
        deskLookAt.gameObject.SetActive(false);
        desk.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Notification, this.transform.position);
        Invoke("ShelfPrompt", 4f);
    }
    [SerializeField] Spawner shelfLookAt;
    private void ShelfPrompt()
    {
        shelfLookAt.gameObject.SetActive(true);
        shelfLookAt.activated.AddListener(ShelfLookedAt);

    }
    [SerializeField] GameObject shelf;
    private void ShelfLookedAt()
    {
        shelfLookAt.activated.RemoveListener(ShelfLookedAt);
        shelfLookAt.gameObject.SetActive(false);
        shelf.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Notification, this.transform.position);
        Invoke("NightstandPrompt", 3f);
    }
    [SerializeField] Spawner nightstandLookAt;
    private void NightstandPrompt()
    {
        nightstandLookAt.gameObject.SetActive(true);
        nightstandLookAt.activated.AddListener(NightstandLookedAt);
    }
    [SerializeField] GameObject nightstand;
    private void NightstandLookedAt()
    {
        nightstandLookAt.activated.RemoveListener(NightstandLookedAt);
        nightstandLookAt.gameObject.SetActive(false);
        nightstand.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Notification, this.transform.position);
        Invoke("BeanbagPrompt", 2f);
    }
    [SerializeField] Spawner beanbagLookAt;
    private void BeanbagPrompt()
    {
        beanbagLookAt.gameObject.SetActive(true);
        beanbagLookAt.activated.AddListener(BeanbagLookedAt);
    }
    [SerializeField] GameObject beanbag;
    private void BeanbagLookedAt()
    {
        beanbagLookAt.activated.RemoveListener(BeanbagLookedAt);
        beanbagLookAt.gameObject.SetActive(false);
        beanbag.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.BeanBag, this.transform.position);
        Invoke("PaperCrayonPrompt", 1f);
    }
    [SerializeField] Spawner paperCrayonLookAt;
    private void PaperCrayonPrompt()
    {
        paperCrayonLookAt.gameObject.SetActive(true);
        paperCrayonLookAt.activated.AddListener(PaperCrayonLookedAt);
    }
    [SerializeField] ToggleObjectStationary paper;
    [SerializeField] XRGrabInteractable crayon;
    [SerializeField] GameObject drawingStuff;
    // ^ change crayon to pickup
    private void PaperCrayonLookedAt()
    {
        paperCrayonLookAt.activated.RemoveListener(PaperCrayonLookedAt);
        paperCrayonLookAt.gameObject.SetActive(false);
        paper.gameObject.SetActive(true);
        Invoke("SetCrayonActive", .2f);
    }
    private void SetCrayonActive()
    {
        crayon.gameObject.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Notification, this.transform.position);
    }


    // wait for player to pick up crayon

    public void PickUpCrayon()
    {
        paper.TogglePermanent();
        drawingStuff.SetActive(true);
        Invoke("BaseballPrompt", 3f);
    }
    [SerializeField] Spawner baseballLookAt;
    private void BaseballPrompt()
    {
        baseballLookAt.gameObject.SetActive(true);
        baseballLookAt.activated.AddListener(BaseballLookedAt);
    }
    [SerializeField] XRGrabInteractable baseball;
    public void BaseballLookedAt()
    {
        baseballLookAt.activated.RemoveListener(BaseballLookedAt);
        baseballLookAt.gameObject.SetActive(false);
        baseball.gameObject.SetActive(true);
    }

    // wait until throw basketball

    public void ThrowBaseball()
    {
        Invoke("MovePaperCrayon", 1f);
    }
    [SerializeField] Transform paperHideLocation;
    [SerializeField] Transform crayonHideLocation;
    public void MovePaperCrayon()
    {
        Invoke("GuitarPrompt", 1f);
    }
    [SerializeField] Spawner guitar;
    private void GuitarPrompt()
    {
        guitar.gameObject.SetActive(true);
        guitar.activated.AddListener(GuitarLookedAt);
    }
    [SerializeField] GameObject guitarObject;
    private void GuitarLookedAt()
    {
        guitar.activated.RemoveListener(GuitarLookedAt);
        guitar.gameObject.SetActive(false);
        guitarObject.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Guitar, this.transform.position);
        Invoke("PianoLookedAtPrompt", 1f);
    }
    [SerializeField] Spawner piano;
    private void PianoLookedAtPrompt()
    {
        piano.gameObject.SetActive(true);
        piano.activated.AddListener(PianoLookedAt);
    }
    [SerializeField] GameObject pianoObject;
    private void PianoLookedAt()
    {
        piano.activated.RemoveListener(PianoLookedAt);
        piano.gameObject.SetActive(false);
        pianoObject.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Piano, this.transform.position);
        Invoke("SheetMusicPianoPrompt", 2f);
    }
    [SerializeField] Spawner sheetMusicPianoSpawner;
    private void SheetMusicPianoPrompt()
    {
        sheetMusicPianoSpawner.gameObject.SetActive(true);
        sheetMusicPianoSpawner.activated.AddListener(SheetMusicPianoLookedAt);
    }
    [SerializeField] GameObject sheetMusicPiano;
    private void SheetMusicPianoLookedAt()
    {
        sheetMusicPianoSpawner.activated.RemoveListener(SheetMusicPianoLookedAt);
        sheetMusicPianoSpawner.gameObject.SetActive(false);
        Invoke("SheetMusicDeskPrompt", 2f);
    }

    [SerializeField] Spawner sheetMusicDeskSpawner;
    private void SheetMusicDeskPrompt()
    {
        sheetMusicDeskSpawner.gameObject.SetActive(true);
        sheetMusicDeskSpawner.activated.AddListener(SheetMusicDeskLookedAt);
    }
    [SerializeField] GameObject sheetMusicDesk;
    private void SheetMusicDeskLookedAt()
    {
        sheetMusicDeskSpawner.activated.RemoveListener(SheetMusicDeskLookedAt);
        sheetMusicDeskSpawner.gameObject.SetActive(false);
        sheetMusicDesk.SetActive(true);
        Invoke("Trophy1Prompt", 1.5f);
    }
    [SerializeField] Spawner trophy1Spawner;
    private void Trophy1Prompt()
    {
        trophy1Spawner.gameObject.SetActive(true);
        trophy1Spawner.activated.AddListener(Trophy1LookedAt);
    }
    [SerializeField] GameObject trophy1;
    private void Trophy1LookedAt()
    {
        trophy1Spawner.activated.RemoveListener(Trophy1LookedAt);
        trophy1Spawner.gameObject.SetActive(false);
        trophy1.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Achievement, this.transform.position);
        Invoke("SheetMusicBedPrompt", 2f);
    }
    [SerializeField] Spawner sheetMusicBedSpawner;
    private void SheetMusicBedPrompt()
    {
        sheetMusicBedSpawner.gameObject.SetActive(true);
        sheetMusicBedSpawner.activated.AddListener(SheetMusicBedLookedAt);
    }
    [SerializeField] GameObject sheetMusicBed;
    private void SheetMusicBedLookedAt()
    {
        sheetMusicBedSpawner.activated.RemoveListener(SheetMusicBedLookedAt);
        sheetMusicBedSpawner.gameObject.SetActive(false);
        sheetMusicBed.SetActive(true);
        Invoke("SheetMusicNightStandPrompt", 1.2f);
    }
    [SerializeField] Spawner sheetMusicNightstandSpawner;
    private void SheetMusicNightStandPrompt()
    {
        sheetMusicNightstandSpawner.gameObject.SetActive(true);
        sheetMusicNightstandSpawner.activated.AddListener(SheetMusicNightStandLookedAt);
    }
    [SerializeField] GameObject sheetMusicNightstand;
    private void SheetMusicNightStandLookedAt()
    {
        sheetMusicNightstandSpawner.activated.RemoveListener(SheetMusicNightStandLookedAt);
        sheetMusicNightstandSpawner.gameObject.SetActive(false);
        sheetMusicNightstand.SetActive(true);
        Invoke("Trophy2Prompt", 1.2f);
    }

    [SerializeField] Spawner trophy2Spawner;
    private void Trophy2Prompt()
    {
        trophy2Spawner.gameObject.SetActive(true);
        trophy2Spawner.activated.AddListener(Trophy2LookedAt);
    }
    [SerializeField] GameObject trophy2;
    private void Trophy2LookedAt()
    {
        trophy2Spawner.activated.RemoveListener(Trophy2LookedAt);
        trophy2Spawner.gameObject.SetActive(false);
        trophy2.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Piano2, this.transform.position);
        Invoke("SheetMusicFloorPrompt", 1.5f);
    }
    [SerializeField] Spawner sheetMusicFloorSpawner;
    private void SheetMusicFloorPrompt()
    {
        sheetMusicFloorSpawner.gameObject.SetActive(true);
        sheetMusicFloorSpawner.activated.AddListener(SheetMusicFloorLookedAt);
    }
    [SerializeField] GameObject sheetMusicFloor;
    private void SheetMusicFloorLookedAt()
    {
        sheetMusicFloorSpawner.activated.RemoveListener(SheetMusicFloorLookedAt);
        sheetMusicFloorSpawner.gameObject.SetActive(false);
        sheetMusicFloor.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Piano3, this.transform.position);
        Invoke("SheetMusicShelfPrompt", 1.2f);
    }
    [SerializeField] Spawner sheetMusicShelfSpawner;
    private void SheetMusicShelfPrompt()
    {
        sheetMusicShelfSpawner.gameObject.SetActive(true);
        sheetMusicShelfSpawner.activated.AddListener(SheetMusicShelfLookedAt);
    }
    [SerializeField] GameObject sheetMusicShelf;
    private void SheetMusicShelfLookedAt()
    {
        sheetMusicShelfSpawner.activated.RemoveListener(SheetMusicShelfLookedAt);
        sheetMusicShelfSpawner.gameObject.SetActive(false);
        sheetMusicShelf.SetActive(true);
        Invoke("Trophy3Prompt", 0.5f);
    }
    [SerializeField] Spawner trophy3Spawner;
    private void Trophy3Prompt()
    {
        trophy3Spawner.gameObject.SetActive(true);
        trophy3Spawner.activated.AddListener(Trophy3LookedAt);
    }
    [SerializeField] GameObject trophy3;
    private void Trophy3LookedAt()
    {
        trophy3Spawner.activated.RemoveListener(Trophy3LookedAt);
        trophy3Spawner.gameObject.SetActive(false);
        trophy3.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Piano4, this.transform.position);
        Invoke("RadioPrompt", 2f);
    }
    [SerializeField] Spawner radioSpawner;
    private void RadioPrompt()
    {
        radioSpawner.gameObject.SetActive(true);
        radioSpawner.activated.AddListener(RadioLookedAt);
    }
    [SerializeField] GameObject radio;
    private void RadioLookedAt()
    {
        radioSpawner.activated.RemoveListener(RadioLookedAt);
        radioSpawner.gameObject.SetActive(false);
        radio.SetActive(true);
        // PLAY MOMS DRAWING VOICE LINE
        //Invoke("PCPrompt", 5f);
    }
    [SerializeField] Spawner pcSpawner;
    private void PCPrompt()
    {
        pcSpawner.gameObject.SetActive(true);
        pcSpawner.activated.AddListener(PCLookedAt);
    }   
    [SerializeField] GameObject pc;
    private void PCLookedAt()
    {
        pcSpawner.activated.RemoveListener(PCLookedAt);
        pcSpawner.gameObject.SetActive(false);
        pc.SetActive(true);
        
    }



}