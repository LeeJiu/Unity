using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fMoveVSpeed = 10.0f;
    public float fMoveHSpeed = 8.0f;

    //벽 감지용
    Ray rayFront;
    Ray rayRight;
    Ray rayLeft;

    const float fRayDistRightInit = 8.0f;       //오른쪽 감지 거리 초기값
    float fRayDistFront = 4.0f;                 //정면 감지 거리
    float fRayDistRight = fRayDistRightInit;    //오른쪽 감지 거지

    //좌우 움직임 제한 값
    public float fRayLimit = 0.5f;

    //점프
    bool bJump = false;
    public float fJumpPower = 15.0f;
    const float fGravity = 0.5f;
    float fCurrentGravity = 0.0f;

    
    void FixedUpdate ()
    {
        rayFront.origin = this.transform.position + this.transform.forward;
        rayFront.direction = this.transform.forward;

        rayRight.origin = this.transform.position + this.transform.right;
        rayRight.direction = this.transform.right;

        rayLeft.origin = this.transform.position - this.transform.right;
        rayLeft.direction = -this.transform.right;

        this.transform.Translate(0, 0, fMoveVSpeed * Time.deltaTime);

        Steer();
        MoveLR();
        Jump();
	}

    void Steer()
    {
        RaycastHit rayHitFront;
        RaycastHit rayHitRight;

        bool bHitFront = Physics.Raycast(rayFront, out rayHitFront, this.fRayDistFront);

        if(bHitFront == true && rayHitFront.collider.tag == "Wall")
        {
            bool bHitRight = Physics.Raycast(rayRight, out rayHitRight, this.fRayDistRight);

            if(bHitRight == true && rayHitRight.collider.tag == "Wall")
            {
                this.transform.Rotate(0, -90.0f, 0);
            }
            else
            {
                this.transform.Rotate(0, 90.0f, 0);
            }

            fRayDistRight = fRayDistRightInit;
        }
    }

    void MoveLR()
    {
        RaycastHit rayHit;

        if(Input.GetKey(KeyCode.A))
        {
            if( (Physics.Raycast(rayLeft, out rayHit, fRayLimit) && rayHit.collider.tag == "Wall")
                == false )
            {
                this.transform.Translate(-1.0f * fMoveHSpeed * Time.deltaTime, 0 , 0);
                fRayDistRight += fMoveHSpeed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if ((Physics.Raycast(rayRight, out rayHit, fRayLimit) && rayHit.collider.tag == "Wall")
                == false)
            {
                this.transform.Translate(1.0f * fMoveHSpeed * Time.deltaTime, 0, 0);
                fRayDistRight -= fMoveHSpeed * Time.deltaTime;
            }
        }
    }

    void Jump()
    {
        if(bJump == false && Input.GetKey(KeyCode.Space))
        {
            bJump = true;
        }

        if (bJump == true)
        {
            fCurrentGravity += fGravity;

            Vector3 v3Pos = this.transform.position;
            v3Pos.y += (fJumpPower - fCurrentGravity) * Time.deltaTime;
            this.transform.position = v3Pos;
        
            if(this.transform.position.y <= 1.0f)
            {
                bJump = false;
                fCurrentGravity = 0;

                v3Pos = this.transform.position;
                v3Pos.y = 1.0f;
                this.transform.position = v3Pos;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(rayFront.origin, rayFront.origin + rayFront.direction * fRayDistFront);
        Gizmos.DrawLine(rayRight.origin, rayRight.origin + rayRight.direction * fRayDistRight);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayRight.origin, rayRight.origin + rayRight.direction * fRayLimit);
        Gizmos.DrawLine(rayLeft.origin, rayLeft.origin + rayLeft.direction * fRayLimit);
    }
}
