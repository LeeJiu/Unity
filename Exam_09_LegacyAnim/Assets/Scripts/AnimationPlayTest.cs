using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationPlayTest : MonoBehaviour
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
    }

    void Update ()
    {
		if(Input.GetKeyDown("1"))
        {
            this.AnimationPlay("Idle");
        }
        else if (Input.GetKeyDown("2"))
        {
            this.AnimationPlay("Atk1");
        }
        else if (Input.GetKeyDown("3"))
        {
            this.AnimationPlay("Atk2");
        }
        else if (Input.GetKeyDown("4"))
        {
            this.AnimationPlay("Run");
        }
        else if (Input.GetKeyDown("5"))
        {
            this.AnimationPlay("RunFront");
        }
        else if (Input.GetKeyDown("6"))
        {
            this.AnimationPlay("RunBack");
        }
        else if (Input.GetKeyDown("7"))
        {
            this.AnimationPlay("Hit");
        }
        else if (Input.GetKeyDown("8"))
        {
            this.AnimationPlay("ShotPose");
        }
    }

    private void LateUpdate()
    {
        this.rootTrans.localPosition = Vector3.zero;
    }

    void AnimationPlay(string aniName)
    {
        this.charAnim.CrossFade(aniName, 0.3f);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 300, 50), this.charAnim.isPlaying.ToString(), this.guiStyle);
    }
}
