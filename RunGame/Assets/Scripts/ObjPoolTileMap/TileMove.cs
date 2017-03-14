using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMove : MonoBehaviour
{
    public float fMoveSpeed = 5.0f;

    void Update ()
    {
        this.transform.Translate(0, 0, -fMoveSpeed * Time.deltaTime);

        if(this.transform.position.z < -3.8f)
        {
            this.gameObject.SetActive(false);
        }
	}
}
