using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonBall : MonoBehaviour
{
    private Rigidbody myRigid;

    public float ExplosionRange = 10.0f;
    public float ExplosionPower = 100.0f;
    public float upExplosionPower = 1000.0f;

    public GameObject explosionEffect;

    //물리 충돌시 들어오는 충돌 함수
    void OnCollisionEnter(Collision collision)
    {
        print("in OnCollisionEnter() !");

        //반경에 들어온 모든 콜라이더들을 가져오자.
        Collider[] cols = Physics.OverlapSphere(this.transform.position, this.ExplosionRange);

        //각각의 cube에게 폭발하는 힘 전달
        for(int i = 0; i < cols.Length; ++i)
        {
            if(cols[i].GetComponent<Rigidbody>() != null)
            {
                cols[i].GetComponent<Rigidbody>().AddExplosionForce(
                    this.ExplosionPower,
                    this.transform.position,
                    this.ExplosionRange,
                    upExplosionPower,           //상방 보정량
                    ForceMode.Impulse
                    );
            }

            //Effect
            if(this.explosionEffect != null)
            {
                GameObject newGameObject =
                    Instantiate(this.explosionEffect, this.transform.position, this.transform.rotation);

                Destroy(newGameObject, 1.0f);
            }
            Destroy(this.gameObject, 1.0f);
        }
    }
}
