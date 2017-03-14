using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {

    public GameObject[] targets;    //움직이는 녀석들 배열로 받기
    public float[] moveSpeeds;      //각각의 이동값

	void Update ()
    {
        //Vector3 moveVec = new Vector3(0, 0, 0);
        Vector3 moveVec = Vector3.zero;

        if(Input.GetKey(KeyCode.UpArrow))
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

        for(int i = 0; i < this.targets.Length; ++i)
        {
            Vector3 move = moveVec * Time.deltaTime * this.moveSpeeds[i];

            this.targets[i].transform.Translate(move);      //개별 이동 적용
        }
    }
}
