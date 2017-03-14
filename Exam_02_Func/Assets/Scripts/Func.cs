using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Func : MonoBehaviour
{
    void Awake()
    {
        //로드하려면 여기서!
        Debug.Log("Awake() call");
    }

    //활성화될 때에 호출된다.
    void OnEnable()
    {
        Debug.Log("OnEnable() call");
    }

    void Start ()
    {
        Debug.Log("Start() call");
    }

    //물리 없데이트(RAY, RigidBody~)
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate() call");
    }
    //기본 업데이트
    void Update ()
    {
        Debug.Log("Update() call");
    }
    //Update() 가 끝나고 바로 실행되는 Update()
    void LateUpdate()
    {
        Debug.Log("LateUpdate() call");
    }

    //게임 오브젝트 비활성화될 때에 호출된다.
    void OnDisable()
    {
        Debug.Log("OnDisable() call");
    }

    //1. 게임 오브젝트가 하이어라키에서 사라질 때(파괴되었을 때)
    //2. 어플리케이션이 종료될 때
    void OnDestroy()
    {
        Debug.Log("OnDestroy() call");
    }

    //어플리케이션이 종료될 때(앱 종료)
    void OnApplicationQuit()
    {
        //세이브하려면 여기서!
        Debug.Log("OnApplicationQuit() call");
    }

    void Reset()
    {
        Debug.Log("Reset() call");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            this.transform.position,    //구 만들 위치
            1.0f                        //반지름
            );

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(
            this.transform.position,        //from
            this.transform.forward * 3.0f   //to
            );
    }
}
