using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public GameObject exitDoor; //attach the exit door in the inspector


    public GameObject endScreen; //just make a panel with text that says "You Won!", unactivate it, and attach it here in the inspector


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Win()
    {
        //TODO put the conditions for the win, IE. the player unlocking all of the locks


        exitDoor.SetActive(false);
    }

    //You need to attach a box collider to the empty gameobject this script is attached to, position it outside the open door, and check istrigger

    public void OnTriggerEnter(Collider other)
    {
        print("END");
        endScreen.SetActive(true);
    }


}