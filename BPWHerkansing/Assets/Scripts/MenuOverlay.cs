using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOverlay : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private PlayerMovement PlayerMovement;
    [SerializeField] private PlayerCamera PlayerCamera;

    public void Update()
    {
        // If Escape is pressed, enable the menu screen
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponentInChildren<Canvas>().enabled = true;
            SetPlayer(false);
            // Set cursor so player can move it
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Enable or disable the player
    private void SetPlayer(bool enabled)
    {
        Player.enabled = enabled;
        PlayerMovement.enabled = enabled;
        PlayerCamera.enabled = enabled;
    }

    // Continue with the game
    public void Continue()
    {
        GetComponentInChildren<Canvas>().enabled = false;
        SetPlayer(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    // Exit the game
    public void Exit()
    {
        Application.Quit();
    }
}
