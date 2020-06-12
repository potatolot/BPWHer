using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum AnimationState
{
    Walking, 
    Idle
}

public class Professor : MonoBehaviour
{
    //State of the animation
    private AnimationState anim_State;

    //Postion the professor should go in the animation
    [SerializeField] private Transform anim_Pos;

    //The professors animator
    [SerializeField] private Animator anim;

    [SerializeField] private Canvas handinCanvas;
    private bool playerEntered;

    [SerializeField] private List<ButtonHandler> clipboardAnswers;

    private int rightAnswers = 0;

    public void WalkToAnimPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, anim_Pos.position, 0.3f);

        anim.SetBool("isWalking", true);

        if (transform.position == anim_Pos.position)
        {
            anim.SetBool("isWalking", false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        WalkToAnimPoint();      
        
        if(Input.GetKeyDown(KeyCode.Q) && playerEntered)
        {
            //print(clipboardAnswers[0].CheckIfRight());

            foreach(ButtonHandler button in clipboardAnswers)
            {
                print(button.CheckIfRight());
                if (!button.CheckIfRight())
                    SceneManager.LoadScene(2);
                else if (button.CheckIfRight())
                    rightAnswers++;
            }

            if(rightAnswers == 3)
                SceneManager.LoadScene(3);
        }

    }

    IEnumerable animationSequence()
    {
        yield return new WaitForSeconds(4);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerEntered = true;
        handinCanvas.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerEntered = false;
        handinCanvas.enabled = false;
    }
}
