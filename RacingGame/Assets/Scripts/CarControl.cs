using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Car))]
public class CarControl : MonoBehaviour
{
    private Car myCar;

    public float rayAngle = 45.0f;
    public float rayDistance = 10.0f;

    private Ray leftFrontRay;
    private Ray rightFrontRay;

    public Transform rayControlTransform;   //레이 시작점


	void Awake ()
    {
        this.myCar = this.GetComponent<Car>();
    }

	void Update ()
    {
        //레이 준비
        
        //왼쪽 방향
        float leftFrontRad = (90.0f + this.rayAngle) * Mathf.Deg2Rad;
        Vector3 dirToLeftFront = new Vector3(Mathf.Cos(leftFrontRad), 0.0f, Mathf.Sin(leftFrontRad));

        //왼쪽 레이 시작점과 방향 벡터
        this.leftFrontRay.origin = this.rayControlTransform.position;
        this.leftFrontRay.direction = this.rayControlTransform.TransformDirection(dirToLeftFront);

        //오른쪽 방향
        float rightFrontRad = (90.0f - this.rayAngle) * Mathf.Deg2Rad;
        Vector3 dirToRightFront = new Vector3(Mathf.Cos(rightFrontRad), 0.0f, Mathf.Sin(rightFrontRad));

        //오른쪽 레이 시작점과 방향 벡터
        this.rightFrontRay.origin = this.rayControlTransform.position;
        this.rightFrontRay.direction = this.rayControlTransform.TransformDirection(dirToRightFront);

        //레이 히트 거리를 레이 쏘는 거리로 초기화
        float leftFrontHitDistance = this.rayDistance;
        float rightFrontHitDistance = this.rayDistance;

        //왼쪽 체크
        RaycastHit leftFrontHit;
        if(Physics.Raycast(this.leftFrontRay, out leftFrontHit, this.rayDistance))
        {
            leftFrontHitDistance = leftFrontHit.distance;
        }

        //오른쪽 체크
        RaycastHit rightFrontHit;
        if (Physics.Raycast(this.rightFrontRay, out rightFrontHit, this.rayDistance))
        {
            rightFrontHitDistance = rightFrontHit.distance;
        }

        //레이 거리 체크로 Steer 설정(-1~1) (좌우 회전 비율)
        float desireSteer = (rightFrontHitDistance - leftFrontHitDistance) / this.rayDistance;

        //회전 비율을 전달
        this.myCar.Steer(desireSteer);
    }

    void OnDrawGizmos()
    {
        //좌우 기즈모 그리기
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            this.leftFrontRay.origin,
            this.leftFrontRay.origin + this.leftFrontRay.direction * this.rayDistance);

        Gizmos.DrawLine(
            this.rightFrontRay.origin,
            this.rightFrontRay.origin + this.rightFrontRay.direction * this.rayDistance);
    }
}
