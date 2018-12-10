using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using InputTracking = UnityEngine.XR.InputTracking;
using Node = UnityEngine.XR.XRNode;

public class LocalPlayerController : NetworkBehaviour
{

    public GameObject ovrCamRig;
    public Transform leftHand;
    public Transform rightHand;
    public Camera leftEye;
    public Camera rightEye;
    public float speed = 3;
    public Animator anim;

    Vector3 pos;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            Destroy(ovrCamRig);
        }
        else
        {
            //Take care of camera transporting when players join.
            if (leftEye.tag != "MainCamera")
            {
                leftEye.tag = "MainCamera";
                leftEye.enabled = true;
            }
            if (rightEye.tag != "MainCamera")
            {
                rightEye.tag = "MainCamera";
                rightEye.enabled = true;
            }

            //handle animations
            if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x != 0 || OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y != 0)
            {
                //Set animatio to running over the server
                GetComponent<LocalAnimationControl>().CmdUpdateAnim("run");
                anim.SetBool("Idle", false);
            }
            else
            {
                //Set animation to nothing over the server.
                GetComponent<LocalAnimationControl>().CmdUpdateAnim("idle");
                anim.SetBool("Idle", true);
            }

            //Take care of hand position tracking
            leftHand.localRotation = InputTracking.GetLocalRotation(Node.LeftHand);
            leftHand.localPosition = InputTracking.GetLocalPosition(Node.LeftHand);
            rightHand.localRotation = InputTracking.GetLocalRotation(Node.RightHand);
            rightHand.localPosition = InputTracking.GetLocalPosition(Node.RightHand);

            //Handle position and rotation of player.
            Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            if (primaryAxis.y > 0f)
            {
                pos += (primaryAxis.y * transform.forward * Time.deltaTime * speed);
            }
            if (primaryAxis.y < 0f)
            {
                pos += (Mathf.Abs(primaryAxis.y) * -transform.forward * Time.deltaTime * speed);
            }
            if (primaryAxis.x > 0f)
            {
                pos += (primaryAxis.x * transform.right * Time.deltaTime * speed);
            }
            if (primaryAxis.x < 0f)
            {
                pos += (Mathf.Abs(primaryAxis.x) * -transform.right * Time.deltaTime * speed);
            }

            transform.position = pos;

            Vector3 euler = transform.rotation.eulerAngles;
            Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            euler.y += secondaryAxis.x;
            transform.rotation = Quaternion.Euler(euler);
            //Maybe set local rotation too?
            transform.localRotation = Quaternion.Euler(euler);
        }
    }
}