using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class CharControl : MonoBehaviour
{
    private CharacterController charCon;
    private float moveSpeed = 5.0f;

    public bool useGravity = false;

    private CollisionFlags colFlags;

    public GUIStyle guiStyle;

    private void Awake()
    {
        this.charCon = this.GetComponent<CharacterController>();
    }

    void Update ()
    {
        float InputH = Input.GetAxis("Horizontal");
        float InputV = Input.GetAxis("Vertical");

        Vector3 moveVec = 
            new Vector3(InputH, 0.0f, InputV) * this.moveSpeed * Time.deltaTime;

        //Gravity
        if(this.useGravity)
        {
            moveVec += Vector3.down * Time.deltaTime;
            //moveVec += Vector3.down;
        }

        //CharacterController 이동 함수
        this.colFlags = this.charCon.Move(moveVec);
	}

    private void OnGUI()
    {
        if(this.colFlags == CollisionFlags.None)
        {
            GUI.Label(new Rect(0, 0, 400, 40), "공중에 떠 있다.", this.guiStyle);
        }
        else
        {
            if((this.colFlags & CollisionFlags.Sides) != 0)
            {
                GUI.Label(new Rect(0, 40, 400, 40), "벽과 충돌 중이다.", this.guiStyle);
            }

            if ((this.colFlags & CollisionFlags.Above) != 0)
            {
                GUI.Label(new Rect(0, 80, 400, 40), "천장과 충돌 중이다.", this.guiStyle);
            }

            if ((this.colFlags & CollisionFlags.Below) != 0)
            {
                GUI.Label(new Rect(0, 120, 400, 40), "바닥과 충돌 중이다.", this.guiStyle);
            }
        }
    }

    //CharacterController 가 다른 물체에 충돌이나 접촉 했을 때 호출되는 함수
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.DrawLine(
            this.transform.position,
            this.transform.position + hit.normal * 3.0f,
            Color.cyan
            );

        //충돌된 게임 오브젝트가 가진 rigidbody 에 접근하여 힘 전달
        if(hit.gameObject.GetComponent<Rigidbody>() != null)
        {
            hit.gameObject.GetComponent<Rigidbody>().AddForce(
                hit.moveDirection * 5.0f,
                ForceMode.Impulse
                );
        }
    }
}
