using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    void Awake()
    {
        Rigidbody myBody = this.GetComponent<Rigidbody>();
        myBody.useGravity = false;
        myBody.isKinematic = true;
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "Player")
        {
            StartCoroutine(CoDownPlatform());
        }
    }

    IEnumerator CoDownPlatform()
    {
        yield return new WaitForSeconds(1.0f);
        Rigidbody myBody = this.GetComponent<Rigidbody>();
        myBody.useGravity = true;
        myBody.isKinematic = false;
    }
}
