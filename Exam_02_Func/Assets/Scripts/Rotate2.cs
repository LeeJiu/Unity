using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    public float rotSpeed = 90.0f;      //초당 90도 회전
    public bool IsRotateSelf = false;   //셀프 회전

    private Vector3 rot = Vector3.zero;
    private bool isMove;

    private Vector3 moveVec = Vector3.zero;
    public float moveSpeed = 3.0f;

    void Awake()
    {
        isMove = false;
        rot = new Vector3(0, this.rotSpeed, 0) * Time.deltaTime;
        StartCoroutine(CoMoveLogic());
    }

    void Update()
    {
        if (isMove == false)
        { 
            this.transform.Rotate(rot, (IsRotateSelf) ? Space.Self : Space.World);
        }
        else
        {
            this.transform.Translate(this.moveVec * Time.deltaTime * this.moveSpeed);
        }
    }

    IEnumerator CoMoveLogic()
    {
        yield return new WaitForSeconds(5.0f);
        rot = new Vector3(0, -this.rotSpeed, 0) * Time.deltaTime;

        yield return new WaitForSeconds(5.0f);
        isMove = true;
        this.moveVec = this.transform.right;
    }
}
