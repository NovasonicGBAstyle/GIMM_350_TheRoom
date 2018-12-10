using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEyAnim : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Die()
    {
        Destroy(this.gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Lock")
        {
 GetComponent<ParticleSystem>().Play();
        Invoke("Die", 1f);
        }
       
    }


}