using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float fMoveSpeed = 20.0f;
    public float fRotSpeed = 90.0f;

	void FixedUpdate()
    { 
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * fMoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * fMoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up * -fRotSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * fRotSpeed * Time.deltaTime);
        }
    }
}
