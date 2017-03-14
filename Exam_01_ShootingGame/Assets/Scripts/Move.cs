using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 0.0f;

	void Update ()
    {
        float moveDelta = moveSpeed * Time.deltaTime;

        Vector3 moveVec = Vector3.zero;
        moveVec.z += moveDelta;
        this.transform.Translate(moveVec, Space.Self);
	}
}
