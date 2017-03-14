using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoroutine : MonoBehaviour {

    private Vector3 moveVec = Vector3.zero;
    public float moveSpeed = 3.0f;

    void Awake()
    {
        StartCoroutine(CoMoveLogic());
    }

    void Update ()
    {
        this.transform.Translate(this.moveVec * Time.deltaTime * this.moveSpeed);	

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(CoMoveLogic());
        //    //StartCoroutine("CoMoveLogic");
        //    //StopCoroutine("CoMoveLogic");
        //}
    }

    IEnumerator CoMoveLogic()
    {
        //1초 뒤에 다음 행을 실행시킨다.
        //yield return new WaitForSeconds(1.0f);

        //다음 FixedUpdate()가 실행될 때까지 기다린다.
        //yield return new WaitForFixedUpdate();

        //한 프레임을 기다린다.
        //yield return null;

        //해당 프레임의 랜더링 처리가 끝난 마지막까지 기다린다.
        //yield return new WaitForEndOfFrame();

        //타임 값을 느리게 혹은 빠르게 변경없이 실제 타임을 적용하여 기다린다.
        //yield return new WaitForSecondsRealtime(float time);

        yield return null;
        print("1초 뒤 찍힌다~");

        yield return new WaitForSeconds(1.0f);
        this.moveVec = new Vector3(0, 0, 1);
        this.moveSpeed = 1.0f;

        yield return new WaitForSeconds(2.0f);
        this.moveVec = Vector3.right;
        this.moveSpeed = 0.5f;

        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i < 5; ++i)
        {
            if((i & 1) == 0)
            {
                this.moveVec = Vector3.left;
                this.moveSpeed = 3.0f;
            }
            else
            {
                this.moveVec = Vector3.right;
                this.moveSpeed = 3.0f;
            }
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.0f);
        this.moveVec = Vector3.forward;
        this.moveSpeed = 10.0f;
    }
}
