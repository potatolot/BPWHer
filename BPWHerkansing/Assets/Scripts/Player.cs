using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [HideInInspector] public bool holdsClipBoard = false;
    [SerializeField] private Canvas clipboardCanvas;

    //player movement to shut off when in clipboard mode
    [SerializeField] private PlayerCamera cameraMovement;
    [SerializeField] private PlayerMovement playerMovement;

    void Update()
    {
        if (clipboardCanvas.enabled && holdsClipBoard && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


            cameraMovement.enabled = true;
            playerMovement.enabled = true;
            clipboardCanvas.enabled = false;
        }

        // opens clipboard
        else if (!clipboardCanvas.enabled && holdsClipBoard && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            cameraMovement.enabled = false;
            playerMovement.enabled = false;
            clipboardCanvas.enabled = true;
        }

       
       
    }
}
