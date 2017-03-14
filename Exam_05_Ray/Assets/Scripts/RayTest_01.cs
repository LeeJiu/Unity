using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest_01 : MonoBehaviour
{
    [Range(0, 10)]
    public float distance = 10.0f;      //레이 길이

    private RaycastHit hit;     //충돌 정보를 가져올 레이 캐스트

    public LayerMask maskValue = -1;    //모든 레이어 선택

	void FixedUpdate ()
    {
        //ray setting
        Ray ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        //if(Physics.Raycast(ray))
        //{
        //    print("Hit!");
        //}

        //충돌 지점을 hit 보내준다.
        //if(Physics.Raycast(ray, out hit))
        //{
        //    print(hit.collider.gameObject.name + "과 충돌");
        //}

        //레이 길이 지정
        //if (Physics.Raycast(ray, out hit, this.distance))
        //{
        //    print(hit.collider.gameObject.name + "과 충돌");
        //}

        //레이어로 충돌할 오브젝트를 나눌 수 있다.
        if (Physics.Raycast(ray, out hit, this.distance, this.maskValue))
        {
            print(hit.collider.gameObject.name + "과 충돌");
        }
    }

    void OnDrawGizmos()
    {
        //충돌 됐을 때
        if(this.hit.collider != null)
        {
            //충돌 지점에 빨간 구 그리기
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(this.hit.point, 0.5f);

            //hit 지점까지 라인 그리기
            Gizmos.color = Color.white;
            Gizmos.DrawLine(this.transform.position, 
                this.transform.position + this.transform.forward * this.hit.distance);

            //hit 지점의 노말 방향
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(this.hit.point, this.hit.point + this.hit.normal);

            //충돌된 반사 방향
            Gizmos.color = Color.magenta;

            Vector3 reflect = Vector3.Reflect(this.transform.forward, this.hit.normal);
            reflect.Normalize();

            Gizmos.DrawLine(this.hit.point, this.hit.point + reflect * 2.0f);
        }
        //충돌 안 됐을 때
        else
        {
            Gizmos.DrawLine(this.transform.position, 
                this.transform.position + this.transform.forward * this.distance);
        }
    }
}
