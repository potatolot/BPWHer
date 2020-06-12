using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script executes the cutscene sequence

public class SceneSequence : MonoBehaviour
{
    //Main cam
    [SerializeField]
    private GameObject MainCam;

    //Cam 1
    [SerializeField]
    private GameObject DoorCam;

    //Cam 2
    [SerializeField]
    private GameObject DoorFloorCam;

    //Cam 3
    [SerializeField]
    private GameObject PrisonerCam;

    //Cam 4
    [SerializeField]
    private GameObject BubbleCam;

    //Animation for left door
    [SerializeField]
    private Animator doorLeftAnimation;

    //Animation for right door
    [SerializeField]
    private Animator doorRightAnimation;

    //AudioQueues
    [SerializeField]
    private List<AudioClip> Text;

    private void Start()
    {
        StartCutScene();
    }

    //Starts the cut scene by enabling the first camera
    void StartCutScene()
    {
           MainCam.SetActive(false);
           DoorCam.SetActive(true);
           //Starts the cutscene sequence
           StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(4);
        DoorFloorCam.SetActive(true);
        DoorCam.SetActive(false);
        OpenDoors();

        yield return new WaitForSeconds(2);
        DoorFloorCam.SetActive(false);
        BubbleCam.SetActive(true);

        yield return new WaitForSeconds(8);
        BubbleCam.SetActive(false);
        DoorCam.SetActive(true);
        PlayAudioSource(0);                                 //I hope you are ready

        yield return new WaitForSeconds(2);
        PlayAudioSource(1);                                 //Don’t be nervous, I am sure you’ll do fine

        yield return new WaitForSeconds(4);
        PlayAudioSource(2);                                 //The goal of this test is to connect each individual to a certain experiment

        yield return new WaitForSeconds(5);
        PlayAudioSource(3);                                 //You can take as long as you want so don’t be afraid to use that time

        yield return new WaitForSeconds(4);
        PrisonerCam.SetActive(true);
        DoorFloorCam.SetActive(false);
        PlayAudioSource(4);                                 //There are 3 individuals in total 

        yield return new WaitForSeconds(3);
        PlayAudioSource(5);                                 //You can ask them questions about their experiences

        yield return new WaitForSeconds(4);
        PrisonerCam.SetActive(false);
        DoorCam.SetActive(true);
        PlayAudioSource(6);                                 //Good luck, you can begin by grabbing the clipboard that is on the table

        yield return new WaitForSeconds(4);
        DoorCam.SetActive(false);
        MainCam.SetActive(true);
        CloseDoors();

    }

    public void OpenDoors()
    {
        //Open both doors
        doorLeftAnimation.SetBool("Open", true);
        doorRightAnimation.SetBool("Open", true);      
    }

    public void CloseDoors()
    {
        //Close both doors
        doorLeftAnimation.SetBool("Open", false);
        doorLeftAnimation.SetBool("Closing", true);

        doorRightAnimation.SetBool("Open", false);
        doorRightAnimation.SetBool("Closing", true);
    }

    public void PlayAudioSource(int audioIndex)
    {
        GetComponent<AudioSource>().clip = Text[audioIndex];
        GetComponent<AudioSource>().Play();
    }
}
