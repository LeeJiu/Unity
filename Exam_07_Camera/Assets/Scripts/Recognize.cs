using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recognize : MonoBehaviour
{
    public Transform target;

    public float distance = 10.0f;

	void Update ()
    {
        float distToTarget = Vector3.Distance(this.transform.position, target.position);

        if(distToTarget <= distance)
        {
            Vector3 dirToTarget = target.position - this.transform.position;
            this.transform.forward = Vector3.Slerp(this.transform.forward, dirToTarget.normalized, Time.deltaTime);
        }
	}
}
