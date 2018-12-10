using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Really quickly, this is going to wait for an interaction with a key.  It will then destroy the key, and hopefully we'll be done.
/// </summary>
public class Lock : MonoBehaviour {

    // We are going to have an event that will trigger when this is unlocked.  Yay!
    public UnityEvent LockUnlocked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision detected by lock");
        if (collision.gameObject.tag == "Key")
        {
            //Debug.Log("Key used to unlock me!");
            unlockLock();
        }
    }

    private void unlockLock()
    {
        //This was unlocked.  Change the color to unlocked color, and disable the box collider so this can't be used anymore.
        gameObject.GetComponent<BoxCollider>().enabled = false;

        GetComponent<Renderer>().material.SetColor("_Color", Color.green);


        //Blast off our event that was listened to.
        LockUnlocked.Invoke();

        //Remove listeners.  No one cares because we already heard you once.
        LockUnlocked.RemoveAllListeners();
    }
}
