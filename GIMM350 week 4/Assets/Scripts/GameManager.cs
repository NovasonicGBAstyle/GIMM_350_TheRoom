using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int locks = 1;

    public AudioClip winSound;

    private bool sceneLoaded = false;

    // Use this for initialization
    void Start () {
        //We need to setup the locks with listeners, but the
        //scene needs to finish loading first so we'll give it a bit.
        Invoke("setupLocks", 2f);

    }
	
	// Update is called once per frame
	void Update () {

    }

    /// <summary>
    /// We are going to setup all the locks in the scene and add listeners for them.
    /// </summary>
    public void setupLocks()
    {
        //So, now that the game has started, we'll go ahead and add listeners for all the locks.  At least
        //I'm fairly certain that this will work.  I'm a bit unclear with the game manager running in the
        //non game part.  I should really create a scene that isn't the game.
        GameObject[] locks = GameObject.FindGameObjectsWithTag("Lock");
        //Debug.Log("We found this many locks: " + locks.Length);
        foreach (GameObject goLock in locks)
        {
            goLock.GetComponent<Lock>().LockUnlocked.AddListener(unlockALock);
        }


        setupWinCamera();
    }

    public void unlockALock()
    {
        //Debug.Log("A lock has been unlocked according to the game manager listener!");
        locks--;
        if(locks < 1)
        {
            Debug.Log("You have escaped the room!");
            gameOver();
        }
    }

    public void setupWinCamera()
    {
        //GameObject myGO = new GameObject();
        //myGO.name = "TestCanvas";
        //myGO.AddComponent<Canvas>();

        //Canvas myCanvas = myCanvas = myGO.GetComponent<Canvas>();

        //myCanvas.renderer.camera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();

        //GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>().transform.parent = GameObject.Find("CenterEyeAnchor").GetComponent<GameObject>().transform;
        

        //myCanvas.worldCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        Debug.Log("Maybe we setup a camera?");
    }

    public void gameOver()
    {
        GetComponent<AudioSource>().PlayOneShot(winSound);
        Invoke("quitGame", 5f);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}