using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //무언가 찍어내는 조직에서
    //참조되는 게임 오브젝트는 Prefab 이어야 한다.
    public GameObject srcBullet;        //복사 생성할 오브젝트(총알)
    public float errorAngle = 3.5f;     //사격 오차각

    public Transform fireTrans;

	void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    this.Fire();
        //}
    }

    public void Fire()
    {
        //총알이 있지 않다면
        if(this.srcBullet == null)
        {
            print("총알이 없다. 총알을 장전해야한다.");
            return;
        }

        //오차각에 의한 발사 회전 사원수 구하기
        Quaternion rotFire = Quaternion.identity;
        //Quaternion.identity = 회전값이 없는 사원수 / 사원수 초기화

        //랜덤 다리안 값(0~360도)
        float radRandomAngle = Random.Range(0, Mathf.PI * 2.0f);

        Vector3 rotVec = new Vector3(Mathf.Cos(radRandomAngle), Mathf.Sin(radRandomAngle), 0.0f);

        //발사 방향
        Vector3 shotDir = Vector3.forward;
        
        //오차각에 의한 발사 방향 회전 사원수
        //(0~errorAngle 각을 가지는 랜덤 원뿔)
        Quaternion oneBBulRot = Quaternion.AngleAxis(Random.Range(0, this.errorAngle), rotVec);

        //사원수 회전값으로 벡터값을 회전시키기
        shotDir = oneBBulRot * shotDir;

        //최종 회전 사원수
        rotFire = Quaternion.LookRotation(shotDir) * this.transform.rotation;

        //복사 함수
        if(this.fireTrans != null)
        {
            Instantiate(
            this.srcBullet,             //복사할 게임 오브젝트
            this.fireTrans.position,    //복사 생성될 위치
            rotFire                     //복사 생성될 회전값
            );
        }
    }
}
