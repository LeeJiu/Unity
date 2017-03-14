using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShock : MonoBehaviour
{
	void Update ()
    {
        //회전 먹인 녀석들 회전을 없앤다.
        this.transform.localRotation =
            Quaternion.Slerp(this.transform.localRotation, Quaternion.identity, Time.deltaTime * 3.0f);
	}

    void OnFireShock()
    {
        //함수가 한번 들어올 때마다 랜덤하게 흔든다.
        this.transform.localRotation =
            Quaternion.Euler(Random.Range(-10.0f, -25.0f), Random.Range(0.0f, 5.0f), 0.0f);
    }
}
