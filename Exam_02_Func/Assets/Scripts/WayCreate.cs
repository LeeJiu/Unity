using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayCreate : MonoBehaviour
{
    public GameObject wayPoint;

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.C))
        {
            this.AddWayPoint();
        }
	}

    public void AddWayPoint()
    {
        //복사 함수
        Instantiate(
            this.wayPoint,          //복사할 프리팹
            new Vector3(            //복사 생성될 위치
                Random.Range(-50.0f, 50.0f), 
                Random.Range(-50.0f, 50.0f), 
                Random.Range(-50.0f, 50.0f)),
            Quaternion.identity     //복사 생성될 회전값
            );
    }
}
