using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationTrigger : MonoBehaviour
{
    // When triggered load the animation scene
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
