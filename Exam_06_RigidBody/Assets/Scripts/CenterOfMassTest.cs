using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CenterOfMassTest : MonoBehaviour
{
    public Transform center;

    private void Awake()
    {
        this.GetComponent<Rigidbody>().centerOfMass =
            center.localPosition;
    }
}
