using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalAnimationControl : NetworkBehaviour {

    public Animator anim;
    public GameObject[] animationBodyParts;
    public Material invisible;

    [SyncVar(hook = "OnAnimationStateChange")]
    public string animState = "idle";

    void OnAnimationStateChange(string animString)
    {
        if (isLocalPlayer) return;
        else
        {
            UpdateAnimation(animString);
        }
    }

    void UpdateAnimation(string animString)
    {
        if (animState == animString) return;
        animState = animString;

        if(animState == "idle")
        {
            anim.SetBool("Idle", true);
        }

        if(animState == "run")
        {
            anim.SetBool("Idle", false);
        }
    }

    [Command]
    public void CmdUpdateAnim(string animString)
    {
        UpdateAnimation(animString);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Idle",true);

        if (isLocalPlayer)
        {
            foreach(GameObject g in animationBodyParts)
            {
                SkinnedMeshRenderer[] m = g.GetComponentsInChildren<SkinnedMeshRenderer>();
                Renderer[] r = g.GetComponentsInChildren<Renderer>();
                foreach (SkinnedMeshRenderer matRend in m)
                {
                    matRend.material = invisible;
                }
                foreach(Renderer rend in r)
                {
                    rend.material = invisible;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
