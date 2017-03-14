using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    public GameObject gTarget;

	void Update ()
    {
        Vector3 vecDir = gTarget.transform.position - this.transform.position;
        vecDir = Vector3.Normalize(vecDir);

        if(Vector3.Distance(gTarget.transform.position, this.transform.position) < 50.0f)
        {
            this.transform.rotation = Quaternion.LookRotation(vecDir, Vector3.up);
        }
	}
}
