using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public bool IsSelf = false;

    public float moveSpeed = 5.0f;

    public float movePower = 10.0f;

	void Update ()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;

        //z축으로 실시간 이동
        //this.transform.Translate(0.0f, 0.0f, moveDelta);

        //Self 는 Local / World 는 World
        //this.transform.Translate(0.0f, 0.0f, moveDelta, Space.World); 
        //this.transform.Translate(0.0f, 0.0f, moveDelta, 
        //    (this.IsSelf) ? Space.Self : Space.World);



//============================Vector로 이동================================
        Vector3 moveVec = new Vector3(0, 0, moveDelta);

        //자신의 축으로 움직여야 한다면 / Local
        if(this.IsSelf)
        {
            moveVec = this.transform.TransformDirection(moveVec);
        }
        this.transform.position += moveVec;


        //Time.deltaTime
        //한 프레임간의 시간을 초 단위로 알려준다.

        //this.transform
        //해당 컴포넌트가 붙은 오브젝트의 Transform
        //자식으로 존재할 때 
        //부모의 상대적인 LocalPosition 값을 Vector3로 접근하는 Property 
        //(부모가 없으면 Position 값과 같다.)

        //this.transform.position
        //Transform 의 월드 위치를 Vector3 형으로 접근 하는 Property (Get, Set 다 됨)

        //this.transform.localPosition
        //Transform 의 계층구조에 의한 다른 Transform의 자식으로 존재할 때 
        //부모의 상대적인 LocalPosition 값을 Vector3 로 접근하는 Property

        //월드 벡터 = this.transform.TransformDirection(로컬 벡터)
        //로컬 방향 벡터를 월드 방향 벡터로 바꾼다.

        //로컬 벡터 = this.transform.InverseTransformDirection(월드 벡터)
        //월드 방향 벡터를 로컬 방향 벡터로 바꾼다.

        //월드 위치 벡터 = this.transform.TransformPoint(로컬 위치 벡터)
        //로컬 위치 벡터를 월드 위치 벡터로 바꾼다.

        //로컬 위치 벡터 = this.transform.InverseTransformPoint(월드 위치 벡터)
        //월드 위치 벡터를 로컬(자기 기준의 위치 벡터)로 바꾼다.
    }
}
