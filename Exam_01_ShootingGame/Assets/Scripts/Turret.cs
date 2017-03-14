using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float angleH = 0.0f;
    private float angleV = 0.0f;
    private float time = 0.0f;
    private bool isFire = false;

    public Transform headTrans;      //터렛 헤드 트랜스
    public Vector3 defaultForward;   //터렛 헤드 트랜스2

    public Gun[] guns;

    void Start()
    {
        defaultForward = headTrans.forward;     //헤드의 디폴트를 저장한다.
    }

    void Update ()
    {
        //this.headTrans.localRotation = Quaternion.Euler(this.angleV, this.angleH, 0.0f);

        if (isFire == true)
        {
            time += Time.deltaTime;
            if (time > 1.0f)
            {
                AllFire();
                time = 0.0f;
            }
        }

        //나를 기준으로 자식 중에 Gun이라는 Component를 찾아 배열에 넣어준다.
        this.guns = this.gameObject.GetComponentsInChildren<Gun>();
	}

    //수평 회전
    public void RotateH(float angle)
    {
        this.angleH += angle;
        this.angleH = Mathf.Clamp(this.angleH, -90.0f, 90.0f);
    }

    //수직 회전
    public void RotateV(float angle)
    {
        this.angleV += angle;
        this.angleV = Mathf.Clamp(this.angleV, -90.0f, 90.0f);
    }

    //일제 사격
    public void AllFire()
    {
        for(int i = 0; i < this.guns.Length; ++i)
        {
            if(this.guns[i] != null)
            {
                this.guns[i].Fire();
            }
        }
    }

    public void SetFire(bool setFire) { isFire = setFire; }
}
