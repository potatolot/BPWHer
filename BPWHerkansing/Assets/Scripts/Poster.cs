using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : MonoBehaviour
{
    //The canvas that is linked to the poster
    [SerializeField] private Canvas posterCanvas;

    private void OnTriggerEnter(Collider other)
    {
        //enable poster when player is in the collisionbox
        posterCanvas.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //disable poster when player is in the collisionbox
        posterCanvas.enabled = false;
    }
}
