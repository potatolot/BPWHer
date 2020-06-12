using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{

    private bool playerEntered = false;
    private GameObject enteredObject;

    private void OnTriggerExit(Collider other)
    {       
        playerEntered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        enteredObject = other.gameObject;
        playerEntered = true;
    }

    public void Update()
    {
        // When E is pressed player holds the clipboard
        if(playerEntered && Input.GetKeyDown(KeyCode.E))
        {
            enteredObject.GetComponent<Player>().holdsClipBoard = true;
            this.gameObject.SetActive(false);
        }
    }
}
