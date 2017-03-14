using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10.0f;     //속도
    public float moveDistance = 100.0f; //사거리

	void Update ()
    {
        //초당 이동량
        float moveDelta = this.moveSpeed * Time.deltaTime;

        this.transform.Translate(0, 0, moveDelta);

        this.moveDistance -= moveDelta;

        if(this.moveDistance <= 0.0f)
        {
            //게임 오브젝트 파괴
            //GameObject.Destroy(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyPlane")
        {
            Destroy(this.gameObject);
        }
    }
}
