using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float steering = 90.0f;

	void Update ()
    {
        //직진
        this.transform.Translate(0, 0, this.moveSpeed * Time.deltaTime);
	}

    public void Steer(float value)
    {
        //y축 회전
        this.transform.Rotate(
            0.0f,
            value * this.steering * Time.deltaTime,
            0.0f);
    }
}
