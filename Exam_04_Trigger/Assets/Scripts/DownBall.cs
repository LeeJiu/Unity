using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBall : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            GameObject hitObject = coll.gameObject;

            Rigidbody myBody = this.transform.FindChild("Ball").GetComponent<Rigidbody>();
            myBody.useGravity = true;
        }
    }
}
