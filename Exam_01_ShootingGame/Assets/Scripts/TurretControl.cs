using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 스크립트는 Turret 이라는 컴포넌트를 필요로 한다.
[RequireComponent(typeof(Turret))]
public class TurretControl : MonoBehaviour
{
    private Turret myTurret;

    void Start()
    {
        //나와 같이 쓰고 있는 게임 오브젝트에 붙어있는 
        //Turret 컴포넌트를 찾아와서 myTurret 에 참조시켜라.
        this.myTurret = this.GetComponent<Turret>();
    }

    void Update()
    {
        Vector2 rot = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rot.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rot.x += 1.0f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rot.y -= 1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rot.y += 1.0f;
        }

        rot *= Time.deltaTime * 90.0f;

        //Turret 스크립트 함수에 전달
        this.myTurret.RotateH(rot.x);
        this.myTurret.RotateV(rot.y);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.myTurret.AllFire();
        }
    }
}
