using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ButtonHandler : MonoBehaviour
{
    //Holds the right answer
    [SerializeField] private int rightToggle = 0;
    //List of toggle buttons in the world
    private List<Toggle> toggleList;

    private void Start()
    {
        
        toggleList = GetComponentsInChildren<Toggle>().ToList();
    }

    public void Update()
    {
        CheckIfRight();
    }

    public bool CheckIfRight()
    {
        if (toggleList[rightToggle].isOn)
        {
            print("thisworks");
            return true;
          
        }
        else
            return false;
    }


}
