using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    // Update is called once per frame
    void LateUpdate()
    {
        // Checks the axis values of the input
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        //Play footstep sound if player is mooving
        if (Input.GetButton("Vertical") && !GetComponent<AudioSource>().isPlaying ||
            Input.GetButton("Horizontal") && !GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();

        //If player is not moving Stop the audio
        else if(!Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))
            GetComponent<AudioSource>().Stop();

        // Add movement
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
         movement = Vector3.ClampMagnitude(movement, speed);

         movement *= Time.deltaTime;
         movement = transform.TransformDirection(movement);
         GetComponent<CharacterController>().Move(movement);
        
    }
}
