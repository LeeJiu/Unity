using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float minSpeed = -10.0f;
    public float maxSpeed = 40.0f;
    public float steering = 90.0f;

    public float rotate = 0.0f;

	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveSpeed += Time.deltaTime;
            if (moveSpeed >= maxSpeed)
            {
                moveSpeed = maxSpeed;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveSpeed -= Time.deltaTime;
            if (moveSpeed <= minSpeed)
            {
                moveSpeed = minSpeed;
            }
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rotate -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotate += Time.deltaTime;
        }

        //직진
        this.transform.Translate(0, 0, this.moveSpeed * Time.deltaTime);

        //y축 회전
        this.transform.Rotate(
            0.0f,
            rotate * this.steering * Time.deltaTime,
            0.0f);
    }
}
