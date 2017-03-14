using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject CannonBall;   //Prefab 설정

    public float power = 10.0f;

    public Transform fireTrans;
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            //캐논 생성
            GameObject newGameObject = 
                Instantiate(this.CannonBall, this.fireTrans.position, this.fireTrans.rotation) as GameObject;

            //생성된 캐논에 힘 전달
            newGameObject.GetComponent<Rigidbody>().AddForce(
                this.fireTrans.forward * this.power, ForceMode.Impulse);
        }
	}
}
