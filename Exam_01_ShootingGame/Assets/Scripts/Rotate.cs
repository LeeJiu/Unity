using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Range(0, 180.0f)]  //범위지정(Make SliderBar)
    public float rotSpeed = 90.0f;      //초당 90도 회전

    void Update()
    {
        Vector3 rot = new Vector3(0, 0, this.rotSpeed) * Time.deltaTime;

        //오일러 회전량으로 Transform 회전시켜주는 함수
        this.transform.Rotate(rot, Space.Self);
    }
}
