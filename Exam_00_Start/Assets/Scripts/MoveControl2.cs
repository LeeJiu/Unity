using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//클래스를 인스펙터 창에 노출시키려면
//다음 코드를 클래스 위에 적어야 한다.
[System.Serializable]

public class TargetInfo
{
    public GameObject target;
    public float moveSpeed;
}

public class MoveControl2 : MonoBehaviour
{
    public TargetInfo[] targetInfos;

    void Update()
    {
        //Vector3 moveVec = new Vector3(0, 0, 0);
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

        for (int i = 0; i < this.targetInfos.Length; ++i)
        {
            Vector3 move = moveVec * Time.deltaTime * this.targetInfos[i].moveSpeed;

            this.targetInfos[i].target.transform.Translate(move);      //개별 이동 적용
        }
    }
}
