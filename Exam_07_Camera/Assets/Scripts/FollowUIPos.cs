using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUIPos : MonoBehaviour
{
    public Transform target;     //따라 움직일 타켓
    public Camera targetCamera;
    public Camera uiCamera;
   
	void Update ()
    {
        //동차 좌표(-1~1)로 화면에 타겟의 위치를 설정
        Vector3 viewPos = this.targetCamera.WorldToViewportPoint(target.position);

        //위의 동차 좌표가 uiCamera 기준의 월드 위치로는 어떻게 되니?
        Vector3 myWorld = this.uiCamera.ViewportToWorldPoint(viewPos);

        Vector3 dirTo = myWorld - this.uiCamera.transform.position;

        //카메라로부터의 거리
        this.transform.position =
            this.uiCamera.transform.position + dirTo.normalized * 20.0f;
	}
}
