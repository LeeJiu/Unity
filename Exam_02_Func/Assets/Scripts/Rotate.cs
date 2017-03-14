using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotSpeed = 90.0f;      //초당 90도 회전
    public bool IsRotateSelf = false;   //셀프 회전

    void Update()
    {
        Vector3 rot = new Vector3(0, this.rotSpeed, 0) * Time.deltaTime;

        this.transform.Rotate(rot, (IsRotateSelf)? Space.Self : Space.World);
    }
}
