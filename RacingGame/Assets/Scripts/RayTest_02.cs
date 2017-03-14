using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest_02 : MonoBehaviour
{
    [Range(0, 10)]
    public float distance = 10.0f;      //레이 길이

    private RaycastHit[] hits;     //충돌 정보를 가져올 레이 캐스트

    public LayerMask maskValue = -1;    //모든 레이어 선택

    void FixedUpdate()
    {
        //ray setting
        Ray ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        this.hits = Physics.RaycastAll(ray, this.distance, this.maskValue.value);
    }

    void OnDrawGizmos()
    {
        //충돌 됐을 때
        if (this.hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; ++i)
            {
                //충돌 지점에 빨간 구 그리기
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(this.hits[i].point, 0.5f);

                //hit 지점까지 라인 그리기
                Gizmos.color = Color.white;
                Gizmos.DrawLine(this.transform.position,
                    this.transform.position + this.transform.forward * this.hits[i].distance);

                //hit 지점의 노말 방향
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(this.hits[i].point, this.hits[i].point + this.hits[i].normal);

                //충돌된 반사 방향
                Gizmos.color = Color.magenta;

                Vector3 reflect = Vector3.Reflect(this.transform.forward, this.hits[i].normal);
                reflect.Normalize();

                Gizmos.DrawLine(this.hits[i].point, this.hits[i].point + reflect * 2.0f);
            }
        }
        //충돌 안 됐을 때
        else
        {
            Gizmos.DrawLine(this.transform.position,
                this.transform.position + this.transform.forward * this.distance);
        }
    }
}
