using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rot = 0.0f;

    void Update()
    {
        Vector3 moveVec = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVec.z += 1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVec.z -= 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVec.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVec.x += 1.0f;
        }

        //초당 이동량 적용전 노말라이즈
        moveVec = moveVec.normalized;

        Vector3 move = moveVec * Time.deltaTime * this.moveSpeed;

        this.transform.Translate(move);


        //회전
        if(Input.GetKey(KeyCode.Q))
        {
            rot -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rot += Time.deltaTime;
        }

        this.transform.Rotate(0, rot, 0, Space.Self);
    }
}
