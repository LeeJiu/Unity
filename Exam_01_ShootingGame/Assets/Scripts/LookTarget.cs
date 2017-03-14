using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Turret))]
public class LookTarget : MonoBehaviour
{
    public GameObject target;

    private Turret myTurret;

    void Start()
    {
        //나와 같이 쓰고 있는 게임 오브젝트에 붙어있는 
        //Turret 컴포넌트를 찾아와서 myTurret 에 참조시켜라.
        this.myTurret = this.GetComponent<Turret>();
    }

    void Update ()
    {
        //방법 1.
        //Vector3 dirToTarget = this.target.transform.position - this.transform.position;
        //this.transform.rotation = Quaternion.LookRotation(dirToTarget, Vector3.up);

        //방법 2.
        //Vector3.Slerp(Vector3 A, Vector3 B, T) //벡터 구형 보간(방향)
        //Vector3.Lerp(Vector3 A, VectorB, T)    //벡터 선형 보간(위치)
        //Vector3 dirToTarget = this.target.transform.position - this.transform.position;
        //Vector3 vec = Vector3.Slerp(this.transform.forward, dirToTarget, Time.deltaTime);
        //this.transform.rotation = Quaternion.LookRotation(vec, Vector3.up);

        Vector3 dirToTarget = this.target.transform.position - this.transform.position;
        float distance = Vector3.Distance(this.target.transform.position, this.transform.position);
        float angle = Vector3.Angle(this.myTurret.defaultForward, dirToTarget);


        if (distance <= 50.0f && angle <= 60.0f)
        {
            Vector3 vec = Vector3.Slerp(this.transform.forward, dirToTarget, Time.deltaTime);
            this.transform.rotation = Quaternion.LookRotation(vec, Vector3.up);

            this.myTurret.SetFire(true);
        }
        else
        {
            Vector3 vec = Vector3.Slerp(this.transform.forward, this.myTurret.defaultForward, Time.deltaTime);
            this.transform.rotation = Quaternion.LookRotation(vec, Vector3.up);

            this.myTurret.SetFire(false);
        }
    }
}
