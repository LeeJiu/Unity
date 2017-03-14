using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidMove : MonoBehaviour
{
    private Rigidbody myRigid;

	void Awake ()
    {
        //this.GetComponent
        //현재 게임 오브젝트에 달려있는 RigidBody 컴포넌트를 가져와서 물린다.
        this.myRigid = this.GetComponent<Rigidbody>();
        this.myRigid.useGravity = false;
	}

	void Update ()
    {
        /*
        //Transform.Translate 이동
        Vector3 moveVec = new Vector3(0, 0, 0);
        moveVec.x = Input.GetAxis("Horizontal");
        moveVec.y = Input.GetAxis("Vertical");

        moveVec *= Time.deltaTime * 3.0f;

        this.transform.Translate(moveVec, Space.World);
        */

        /*
        //RigidBody 로 움직여보자
        Vector3 moveVec = new Vector3(0, 0, 0);
        moveVec.x = Input.GetAxis("Horizontal");
        moveVec.y = Input.GetAxis("Vertical");

        moveVec *= Time.deltaTime * 3.0f;

        //이동이 아닌 위치 세팅
        this.myRigid.MovePosition(this.transform.position + moveVec);
        */

        /*
        //Velocity 로 이동해보자
        Vector3 moveVec = new Vector3(0, 0, 0);
        moveVec.x = Input.GetAxis("Horizontal");
        moveVec.y = Input.GetAxis("Vertical");

        moveVec *= 3.0f;

        //Velocity 가 시간 계산하므로 timeDelta는 빠진다.
        this.myRigid.velocity = moveVec;
        */

        //Force로 이동해보자
        Vector3 moveVec = new Vector3(0, 0, 0);
        moveVec.x = Input.GetAxis("Horizontal");
        moveVec.y = Input.GetAxis("Vertical");

        this.myRigid.AddForce(
            moveVec * 0.1f,
            ForceMode.VelocityChange
            );
    }
}
