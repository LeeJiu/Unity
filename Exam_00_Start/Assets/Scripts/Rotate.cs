using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    [Range(0, 180.0f)]  //범위지정(Make SliderBar)
    public float rotSpeed = 90.0f;      //초당 90도 회전
    public bool IsRotateSelf = false;   //셀프 회전

    private float angleX = 0.0f;

	void Update ()
    {
        Vector3 rot = new Vector3(this.rotSpeed, 0, 0) * Time.deltaTime;

        //오일러 회전량으로 Transform 회전시켜주는 함수
        //this.transform.Rotate(rot, (this.IsRotateSelf) ? Space.Self : Space.World);

        //사원수 회전, 오일러 회전 축을 넣어 회전시킴 / 월드로만 회전함
        this.angleX += this.rotSpeed * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(angleX, angleX, 0);

        //=======================================Note===========================================
        //this.transform.eulerAngles
        //Transform 의 월드 회전량을 Defree 로 접근하는 Property

        //this.transform.localEulerAngles
        //Transform 에 계층구조에 의한 다른 Transform 의 자식으로 존재할 때(부모가 있는 경우)
        //부모의 상대적인 회전량 Degree 값을 Vector3 로 접근하는 Property
        //(부모가 없다면 eulerAngles 랑 같다.)

        //this.transform.rotation
        //Transform 의 월드 회전량을 사원수 값으로 접근하는 Property

        //this.transform.localRotation
        //Transform 의 계층구조가 존재한다면 다른 Transform 의 자식으로 존재할 때
        //부모의 상대적인 회전량을 사원수 값으로 접근하는 Property
        //(부모가 없다면 Rotation과 같다.)

        //사원수 값을 기본적으로 만들어 주는 Quaternion class함수
        //Quaternion.LookRotation(방향 벡터)
        //해당 방향을 바라보는 사원수 회전값을 만들어 준다.

        //Quaternion.LookRotation(방향 벡터, 업 벡터)
        //해당 방향을 바라보되, 업 벡터 방향을 위로 기준을 잡는 사원수 회전값을 만들어 준다.

        //Quaternion.Euler(오일러 회전값)
        //오일러 회전값만큼 회전 사원수 값을 만들어 준다.
	}
}
