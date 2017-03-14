using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    //이벤트 함수(OnTrigger 함수)
    //발생 조건
    //1. A 오브젝트와 B 오브젝트 둘 다 Collider 를 가지고 있어야 한다.
    //2. A 오브젝트와 B 오브젝트 둘 중 하나라도
    //  IsTrigger 항목이 체크되어 있어야 한다.
    //3. A 오브젝트와 B 오브젝트 둘 중 하나라도 RigidBody를 가지고 있어야 한다.
    //  (이왕이면 움직이는 녀석이 RigidBody를 가지게 하자.)
    //4. 위의 쌍방 충돌 조건이 만족하면 이벤트는 양쪽으로 똑같이 들어간다.
    void Awake()
    {
        Rigidbody myBody = this.GetComponent<Rigidbody>();
        myBody.useGravity = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject hitObject = coll.gameObject;

        print("충돌!" + hitObject.gameObject.name + "과 충돌했다.");
    }

    void OnTriggerStay(Collider coll)
    {
        GameObject hitObject = coll.gameObject;

        print("충돌!" + hitObject.gameObject.name + "과 충돌 중이다.");
    }

    void OnTriggerExit(Collider coll)
    {
        GameObject hitObject = coll.gameObject;

        print("충돌!" + hitObject.gameObject.name + "과 충돌 끝.");
    }
}
