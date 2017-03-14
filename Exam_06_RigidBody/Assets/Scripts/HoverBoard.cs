using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class HoverBoard : MonoBehaviour
{
    private Rigidbody myRigid;
    public float hoverPower = 5.0f; //호버 파워
    public float height = 1.0f;     //레이 거리

    void Awake()
    {
        this.myRigid = this.GetComponent<Rigidbody>();
    }


    void FixedUpdate ()
    {
        Ray downRay = new Ray(
            this.transform.position,    //Start
            -this.transform.up);        //Direction

        RaycastHit hit;

        //뜨는 거
        if(Physics.Raycast(downRay, out hit, this.height))
        {
            //높이 값
            float powerRate = 1.0f - (hit.distance / this.height);

            this.myRigid.AddForce(
                Vector3.up * this.hoverPower * powerRate, //방향과 힘
                ForceMode.Acceleration);
        }

        //move
        float InputH = Input.GetAxis("Horizontal");
        float InoutV = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(InputH, 0.0f, InoutV);

        this.myRigid.AddForce(moveVec * 10.0f, ForceMode.Acceleration);
	}
}
