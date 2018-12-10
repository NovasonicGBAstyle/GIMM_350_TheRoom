using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractions : MonoBehaviour {

    public OVRGrabbable selfGrabbable;

	// Use this for initialization
	void Start () {
        selfGrabbable = GetComponent<OVRGrabbable>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision detected by key");
        if (collision.gameObject.tag == "Lock")
        {
            //Debug.Log("I have been used on a lock!");

            //Need to force a release so that this will stop the grabber from being destroyed.
            forceRelease();

            GetComponent<ParticleSystem>().Play();
            Invoke("Die", 4f);

        }
    }

    void Die()
    {
        Destroy(this.gameObject);

    }

    /// <summary>
    /// Basically, this is just going to check and see if this is being held and release it if necessary.
    /// </summary>
    private void forceRelease()
    {
        
        if (selfGrabbable.isGrabbed)
        {
            OVRGrabber grabber = selfGrabbable.grabbedBy;
            grabber.ForceRelease(selfGrabbable);
        }
        
    }
}
