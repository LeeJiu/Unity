using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHammer : MonoBehaviour
{
    private float rotSpeed = 90.0f;

	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 0, this.rotSpeed * Time.deltaTime));
	}
}
