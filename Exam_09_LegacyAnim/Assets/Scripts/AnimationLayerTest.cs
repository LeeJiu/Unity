using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationLayerTest : MonoBehaviour
{
    private Animation charAnim;
    public Transform rootTrans;

    public GUIStyle guiStyle;

    private void Awake()
    {
        this.charAnim = this.GetComponent<Animation>();

        //애니메이션 시작은 Idle
        this.charAnim.Play("Idle");

        //각각의 애니메이션 WrapMode 설정
        this.charAnim["Idle"].wrapMode = WrapMode.Loop;
        this.charAnim["Atk1"].wrapMode = WrapMode.Once;         //Once == Clamp == 1
        this.charAnim["Atk2"].wrapMode = WrapMode.Clamp;        //Once == Clamp == 1
        this.charAnim["Run"].wrapMode = WrapMode.Loop;
        this.charAnim["RunFront"].wrapMode = WrapMode.PingPong;
        this.charAnim["RunBack"].wrapMode = WrapMode.Loop;
        this.charAnim["Hit"].wrapMode = WrapMode.Once;
        this.charAnim["ShotPose"].wrapMode = WrapMode.ClampForever;

        //layer
        this.charAnim["Idle"].layer = 0;
        this.charAnim["Atk1"].layer = 1;
        this.charAnim["Atk2"].layer = 1;
        this.charAnim["Run"].layer = 0;
        this.charAnim["RunFront"].layer = 0;
        this.charAnim["RunBack"].layer = 0;
        this.charAnim["Hit"].layer = 2;
        this.charAnim["ShotPose"].layer = 1;

        //speed 설정
        this.charAnim["Atk1"].speed = 2.0f;
    }

    void Update ()
    {
        float InputH = Input.GetAxis("Horizontal");
        float InputV = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(InputH, 0.0f, InputV);

        //Run
        bool InputDash = Input.GetKey(KeyCode.LeftShift);

        if(moveVec.magnitude >= 1.0f)
        {
            moveVec.Normalize();
        }


        //이동 속도 값 설정 / 달리기
        if (InputDash && moveVec.z > 1.0f)
        {
            moveVec.z = 1.5f;
        }

        this.UpdateMoveAnim(moveVec);

        //atk
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.UpdateAtkAnim();
        }

        //hit
        if(Input.GetKeyDown(KeyCode.Return))
        {
            this.charAnim.CrossFade("Hit", 0.3f);

            if(this.charAnim.IsPlaying("Atk1"))
            {
                this.charAnim.Stop("Atk1");
            }
            else if (this.charAnim.IsPlaying("Atk2"))
            {
                this.charAnim.Stop("Atk2");
            }
        }
	}

    private void LateUpdate()
    {
        this.rootTrans.localPosition = Vector3.zero;
    }
    
    //Move
    void UpdateMoveAnim(Vector3 moveVec)
    {
        if (moveVec == Vector3.zero)
        {
            this.charAnim.CrossFade("Idle", 0.3f);
        }
        else
        {
            if(moveVec.z > 0.0f)
            {
                if(moveVec.z > 1.0f)
                {
                    this.charAnim.CrossFade("Run", 0.3f);
                }
                else
                {
                    this.charAnim.CrossFade("RunFront", 0.3f);
                    this.charAnim["RunFront"].speed = moveVec.z;
                }
            }
            else
            {
                this.charAnim.CrossFade("RunBack", 0.3f);
                this.charAnim["RunBack"].speed = Mathf.Abs(moveVec.z);
            }
        }
    }

    //Attack
    void UpdateAtkAnim()
    {
        if(this.charAnim.IsPlaying("Hit") == false)
        {
            int rand = Random.Range(0, 2);
            string atkNum = "Atk1";

            //if(rand == 1)
            //{
            //    atkNum = "Atk2";
            //}

            this.charAnim.CrossFade(atkNum, 0.3f);

            //QueueMode.PlayNow             //애니메이션 중간(입력받은 순간)에 실행
            //QueueMode.CompleteOthers      //지금 실행 중인 애니메이션이 끝난 뒤 실행

            AnimationState newState = this.charAnim.CrossFadeQueued(atkNum, 0.2f, QueueMode.PlayNow);
            newState.speed = this.charAnim[atkNum].speed;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 300, 50), this.charAnim.isPlaying.ToString(), this.guiStyle);
    }
}
