using Oculus.Platform;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Act1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] Canvas PlayQuitCanvas;
    public void Play()
    {
        PlayQuitCanvas.enabled = false;
        BedPrompt();
    }

    public void Quit()
    {
        UnityEngine.Application.Quit();
    }


    [SerializeField] LookAtDuration bedLookAt;
    private void BedPrompt()
    {
        bedLookAt.gameObject.SetActive(true);
        bedLookAt.onLookedAtDuration += BedLookedAt;
    }

    [SerializeField] GameObject bed;
    private void BedLookedAt()
    {
        bedLookAt.onLookedAtDuration -= BedLookedAt;
        bedLookAt.gameObject.SetActive(false);
        bed.SetActive(true);
        Invoke("DeskPrompt", 5f);
    }

    [SerializeField] LookAtDuration deskLookAt;
    private void DeskPrompt()
    {
        deskLookAt.gameObject.SetActive(true);
        deskLookAt.onLookedAtDuration += BedLookedAt;
    }
    [SerializeField] GameObject desk;
    private void DeskLookedAt()
    {
        deskLookAt.onLookedAtDuration -= BedLookedAt;
        deskLookAt.gameObject.SetActive(false);
        desk.SetActive(true);
        Invoke("ShelfPrompt", 4f);
    }
    [SerializeField] LookAtDuration shelfLookAt;
    private void ShelfPrompt()
    {
        shelfLookAt.gameObject.SetActive(true);
        shelfLookAt.onLookedAtDuration += ShelfLookedAt;
    }
    [SerializeField] GameObject shelf;
    private void ShelfLookedAt()
    {
        shelfLookAt.onLookedAtDuration -= ShelfLookedAt;
        shelfLookAt.gameObject.SetActive(false);
        shelf.SetActive(true);
        Invoke("NightstandPrompt", 3f);
    }
    [SerializeField] LookAtDuration nightstandLookAt;
    private void NightstandPrompt()
    {
        nightstandLookAt.gameObject.SetActive(true);
        nightstandLookAt.onLookedAtDuration += NightstandLookedAt;
    }
    [SerializeField] GameObject nightstand;
    private void NightstandLookedAt()
    {
        nightstandLookAt.onLookedAtDuration -= NightstandLookedAt;
        nightstandLookAt.gameObject.SetActive(false);
        nightstand.SetActive(true);
        Invoke("BeanbagPrompt", 2f);
    }
    [SerializeField] LookAtDuration beanbagLookAt;
    private void BeanbagPrompt()
    {
        beanbagLookAt.gameObject.SetActive(true);
        beanbagLookAt.onLookedAtDuration += BeanbagLookedAt;
    }
    [SerializeField] GameObject beanbag;
    private void BeanbagLookedAt()
    {
        beanbagLookAt.onLookedAtDuration -= BeanbagLookedAt;
        beanbagLookAt.gameObject.SetActive(false);
        beanbag.SetActive(true);
        Invoke("PaperCrayonPrompt", 1f);
    }
    [SerializeField] LookAtDuration paperCrayonLookAt;
    private void PaperCrayonPrompt()
    {
        paperCrayonLookAt.gameObject.SetActive(true);
        paperCrayonLookAt.onLookedAtDuration += PaperCrayonLookedAt;
    }
    [SerializeField] ToggleObjectStationary paper;
    [SerializeField] GameObject crayon;
    // ^ change crayon to pickup
    private void PaperCrayonLookedAt()
    {
        paperCrayonLookAt.onLookedAtDuration -= PaperCrayonLookedAt;
        paperCrayonLookAt.gameObject.SetActive(false);
        paper.gameObject.SetActive(true);
        Invoke("SetCrayonActive", .2f);
    }
    private void SetCrayonActive()
    {
        crayon.SetActive(true);
    }


    // wait for player to pick up crayon

    public void PickUpCrayon()
    {
        paper.TogglePermanent();
        Invoke("SpawnBaseball", 3f);
    }

    [SerializeField] XRGrabInteractable baseball;
    public void SpawnBaseball()
    {
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
        paper.transform.position = paperHideLocation.position;
        crayon.transform.position = crayonHideLocation.position;
        Invoke("GuitarPrompt", 2f);
    }
    [SerializeField] LookAtDuration guitar;
    private void GuitarPrompt()
    {
        guitar.gameObject.SetActive(true);
        guitar.onLookedAtDuration += GuitarLookedAt;
    }
    [SerializeField] GameObject guitarObject;
    private void GuitarLookedAt()
    {
        guitar.onLookedAtDuration -= GuitarLookedAt;
        guitar.gameObject.SetActive(false);
        guitarObject.SetActive(true);
        Invoke("PianoLookedAtPrompt", 1f);
    }
    [SerializeField] LookAtDuration piano;
    private void PianoLookedAtPrompt()
    {
        piano.gameObject.SetActive(true);
        piano.onLookedAtDuration += PianoLookedAt;
    }
    [SerializeField] GameObject pianoObject;
    private void PianoLookedAt()
    {
        piano.onLookedAtDuration -= PianoLookedAt;
        piano.gameObject.SetActive(false);
        pianoObject.SetActive(true);
        Invoke("SpawnTrophies", 3f);
    }
    [SerializeField] GameObject trophy1;
    [SerializeField] GameObject trophy2;
    [SerializeField] GameObject trophy3;
    private void SpawnTrophies()
    {
        trophy1.SetActive(true);
        Invoke("SpawnSecondTrophy", .6f);
    }
    private void SpawnSecondTrophy()
    {
        trophy2.SetActive(true);
        Invoke("SpawnThirdTrophy", .5f);
    }
    private void SpawnThirdTrophy()
    {
        trophy3.SetActive(true);
        Invoke("SpawnRadio", .4f);
    }
    [SerializeField] GameObject radio;
    private void SpawnRadio()
    {
        radio.SetActive(true);
        Invoke("SpawnSheetMusic", 4f);
    }
    [SerializeField] GameObject sheetMusicPiano;
    [SerializeField] GameObject sheetMusicDesk;
    [SerializeField] GameObject sheetMusicBed;
    [SerializeField] GameObject sheetMusicFloor;
    [SerializeField] GameObject sheetMusicShelf;
    private void SpawnSheetMusic()
    {
        sheetMusicPiano.SetActive(true);
        Invoke("SpawnSheetMusicDesk", 1f);
    }
    private void SpawnSheetMusicDesk()
    {
        sheetMusicDesk.SetActive(true);
        Invoke("SpawnSheetMusicBed", .8f);
    }
    private void SpawnSheetMusicBed()
    {
        sheetMusicBed.SetActive(true);
        Invoke("SpawnSheetMusicFloor", .6f);
    }
    private void SpawnSheetMusicFloor()
    {
        sheetMusicFloor.SetActive(true);
        Invoke("SpawnSheetMusicShelf", .4f);
    }
    private void SpawnSheetMusicShelf()
    {
        sheetMusicShelf.SetActive(true);
    }
}
