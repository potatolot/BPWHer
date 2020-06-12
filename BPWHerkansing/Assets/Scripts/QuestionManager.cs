using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    //Canvas with questions
    [SerializeField] private Canvas questions;

    //A list with the answer Audio
    [SerializeField] private List<AudioClip> answers = new List<AudioClip>();

    //Checks whether the patient is answering
    private bool isAnswering = false;
    //Holds the current answer index
    private int currentAnswer = 0;
    //Checks whether the player entered the collisionbox
    private bool playerEntered = false;
    


    void Update()
    {
        //If the player is entering it plays the clip
        if (isAnswering)
        {
            questions.enabled = false;

            GetComponent<AudioSource>().PlayOneShot(answers[currentAnswer]);
            isAnswering = false;
        }
        else if (!isAnswering  && playerEntered)
        {
           
            for (int i = 1; i < 7; i++)
            {
                if(Input.inputString == i.ToString())
                {
                    isAnswering = true;
                    currentAnswer = i - 1;
                }
            }
        }

        if(!GetComponent<AudioSource>().isPlaying && playerEntered)
        {
            questions.enabled = true;
        }
    }
  

    //enables canvas and lets know the player entered the collision box
    private void OnTriggerEnter(Collider other)
    {
        questions.enabled = true;
        playerEntered = true;
    }


    //Resets everyting to false
    private void OnTriggerExit(Collider other)
    {
        isAnswering = false;
        playerEntered = false;
        questions.enabled = false;
    }

}
