using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : MonoBehaviour
{
    public GameObject srcBullet;        //복사 생성할 오브젝트(총알)
    public Transform fireTrans;

    private float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            this.Fire();
            time = 0.0f;
        }
    }

    public void Fire()
    {
        //총알이 있지 않다면
        if (this.srcBullet == null)
        {
            print("총알이 없다. 총알을 장전해야한다.");
            return;
        }

        //복사 함수
        if (this.fireTrans != null)
        {
            Instantiate(
            this.srcBullet,             //복사할 게임 오브젝트
            this.fireTrans.position,    //복사 생성될 위치
            this.fireTrans.rotation     //복사 생성될 회전값
            );
        }
    }
}
