using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public float moveSpeed = 2.5f;

	void Update ()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            this.transform.Translate(new Vector3(0, 0, this.moveSpeed * Time.deltaTime), Space.Self);
        }
	}
}
