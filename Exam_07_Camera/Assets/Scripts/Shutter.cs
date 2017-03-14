using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class Shutter : MonoBehaviour
{
    public Transform shutterTrans;

    private Vector3 shutterUp;
    private Vector3 shutterDown;
    private bool isOpen;

    private void Awake()
    {
        shutterDown = this.shutterTrans.position;
        shutterUp = this.shutterTrans.position;
        shutterUp.y += 3.0f;
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            isOpen = !isOpen;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (isOpen == true)
            {
                this.shutterTrans.position = Vector3.Lerp(this.shutterTrans.position, this.shutterUp, Time.deltaTime);
            }
            else
            {
                this.shutterTrans.position = Vector3.Lerp(this.shutterTrans.position, this.shutterDown, Time.deltaTime);
            }
        }
    }
}
