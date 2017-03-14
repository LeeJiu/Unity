using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddForceTest : MonoBehaviour
{
    private Rigidbody myRigid;

    public float power = 3.0f;
    public Vector3 forceDir;

    private bool onceDown = false;
    public GUIStyle guiStyle;

	void Awake ()
    {
        this.myRigid = this.GetComponent<Rigidbody>();
	}

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            this.onceDown = true;
        }
	}

    void FixedUpdate()
    {
        /*
        if(onceDown)
        {
            this.myRigid.AddForce(this.forceDir.normalized * power);
            onceDown = false;
        }
        */

        //ForceMode
        //Force = 0,            //default 지속적으로 힘을 가할 때(질량 영향 받음)
        //Impulse = 1,          //단타로 힘을 가할 때(질량 영향 받음)
        //VelocityChange = 2,   //단타로 힘을 가할 때(질량의 영향 안 받음)
        //Acceleration = 5      //지속적으로 힘을 가할 때(질량의 영향 안 받음)

        /*
        //Force
        if (Input.GetKey(KeyCode.Space))
        {
            this.myRigid.AddForce(forceDir.normalized * this.power, ForceMode.Force);
        }
        */

        /*
        //Impulse
        if(onceDown)
        {
            this.myRigid.AddForce(this.forceDir.normalized * power, ForceMode.Impulse);
            onceDown = false;
        }
        */

        //VelocityChange
        //if (onceDown)
        //{
        //    this.myRigid.AddForce(this.forceDir.normalized * power, ForceMode.VelocityChange);
        //    onceDown = false;
        //}

        //Acceleration
        if (Input.GetKey(KeyCode.Space))
        {
            this.myRigid.AddForce(forceDir.normalized * this.power, ForceMode.Acceleration);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 300, 30),
            "Velocity : " + this.myRigid.velocity.ToString(),
            this.guiStyle);
    }
}
