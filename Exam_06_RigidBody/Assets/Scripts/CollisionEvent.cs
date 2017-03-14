using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    //OnCollision 이벤트 함수
    //실제 충돌 함수(IsTrigger 체크 해제)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.DrawLine(
            this.transform.position,
            this.transform.position + collision.relativeVelocity,   //반작용 방향
            Color.red,
            3.0f);

        //모서리 라인 기준의 히트 지점과 히트 지점의 노말을 배열로 얻기
        ContactPoint[] contacts = collision.contacts;
        for(int i =0; i < contacts.Length; ++i)
        {
            Debug.DrawLine(
                contacts[i].point,
                collision.contacts[i].point + contacts[i].normal,
                Color.gray,
                4.0f);
        }
    }

    //지속적인 충돌이 일어날 때 들어오는 함수
    private void OnCollisionStay(Collision collision)
    {
        //모서리 라인 기준의 히트 지점과 히트 지점의 노말을 배열로 얻기
        ContactPoint[] contacts = collision.contacts;
        for (int i = 0; i < contacts.Length; ++i)
        {
            Debug.DrawLine(
                contacts[i].point,
                collision.contacts[i].point + contacts[i].normal,
                Color.cyan,
                4.0f);
        }
    }

    //충돌이 일어나고 끝날 떄 들어오는 함수
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌 끝");
    }
}
