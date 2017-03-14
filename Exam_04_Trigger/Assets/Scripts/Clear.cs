using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            GameObject hitObject = coll.gameObject;

            Rigidbody rigid = hitObject.GetComponent<Rigidbody>();
            rigid.useGravity = false;

            print("Clear!");
        }
    }
}
