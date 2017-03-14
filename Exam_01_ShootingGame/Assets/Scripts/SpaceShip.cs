using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    //speed
    private float minSpeed = 0.0f;
    private float maxSpeed = 10.0f;
    private float accelSpeed = 3.0f;
    private float releaseSpeed = 2.0f;
    private float breakSpeed = 3.0f;
    private float nowSpeed = 0.0f;

    //rotate
    private float maxRotate = 90.0f;        //초당 최대 회전량
    private float accelRotate = 180.0f;     //초당 회전 증가량
    private float nowRotatePitch = 0.0f;    //현재 x축 회전량
    private float nowRotateYaw = 0.0f;      //현재 y축 회전량
    private float nowRotateRoll = 0.0f;     //현재 z축 회전량

    //Guns
    private Gun[] guns;

    //모델 우주선 가져오기
    private Transform spaceship;

    //생성자 느낌 / Start() 보다 먼저 실행됨
	void Awake ()
    {
        //자식 중에 Gun Scripts 를 전부 가져와 guns에 물려 넣는다.
        this.guns = this.GetComponentsInChildren<Gun>();

        //자식 모델의 트렌스폼을 가져온다.
        this.spaceship = this.transform.FindChild("omega_fighter").GetComponent<Transform>();
	}
	
	void Update ()
    {
        //z 이동
        this.transform.Translate(0, 0, Time.deltaTime * this.nowSpeed);
        //회전
        this.transform.Rotate(
            this.nowRotatePitch * Time.deltaTime,
            this.nowRotateYaw * Time.deltaTime,
            this.nowRotateRoll * Time.deltaTime
            );
	}
    //move
    //스피드 컨트롤 값(value)은 -1~1 사이의 값으로 받는다.
    public void Control_Speed(float value)
    {
        //증속
        if(value > 0.0f)
        {
            this.nowSpeed += value * this.accelSpeed * Time.deltaTime;
        }
        //감속
        else
        {
            //최고 속도가 음수 처리 되는 것
            //속도는 0에 가까워야 한다.
            //현재 속도와 0과의 차
            if(value == 0.0f)
            {
                float deltaSpeed = -this.nowSpeed;
                
                //차이가 존재할 때
                if (deltaSpeed != 0.0f)
                {
                    //지금 적용되는 감속력
                    float release = this.releaseSpeed * Time.deltaTime;

                    //0~1 사이의 차
                    float normalizeFactor = Mathf.Clamp01(Mathf.Abs(release / deltaSpeed));

                    this.nowSpeed = Mathf.Lerp(this.nowSpeed, 0, normalizeFactor);
                }
            }

            //후진역으로 이동
            if(value < 0.0f)
            {
                this.nowSpeed += this.breakSpeed * Time.deltaTime * value;
            }
        }

        //최대최소로 막는다.
        this.nowSpeed = Mathf.Clamp(this.nowSpeed, this.minSpeed, this.maxSpeed);
    }

    //x
    public void Control_Pitch(float value)
    {
        //타겟의 회전력
        float target = value * this.maxRotate;

        //차이량
        float delta = target - this.nowRotatePitch;

        //차이가 존재할 때
        if(delta != 0.0f)
        {
            //지금 적용되는 회전력
            float rotDelta = Time.deltaTime * this.accelRotate;

            //0~1 사이의 값
            float normalizeFactor = Mathf.Clamp01(Mathf.Abs(rotDelta / delta));

            this.nowRotatePitch = Mathf.Lerp(this.nowRotatePitch, target, normalizeFactor);
        }
    }

    //y
    public void Control_Yaw(float value)
    {
        //타겟의 회전력
        float target = value * this.maxRotate;

        //차이량
        float delta = target - this.nowRotateYaw;

        //차이가 존재할 때
        if (delta != 0.0f)
        {
            //지금 적용되는 회전력
            float rotDelta = Time.deltaTime * this.accelRotate;

            //0~1 사이의 값
            float normalizeFactor = Mathf.Clamp01(Mathf.Abs(rotDelta / delta));

            this.nowRotateYaw = Mathf.Lerp(this.nowRotateYaw, target, normalizeFactor);
        }

        //Yaw 처리
        //현재 회전력으로 자식 로컬 회전시킨다.
        if(this.spaceship != null)
        {
            this.spaceship.localRotation = Quaternion.Euler(0, 0, -this.nowRotateYaw);
        }
    }
    
    //z
    public void Control_Roll(float value)
    {
        //타겟의 회전력
        float target = value * this.maxRotate;

        //차이량
        float delta = target - this.nowRotateRoll;

        //차이가 존재할 때
        if (delta != 0.0f)
        {
            //지금 적용되는 회전력
            float rotDelta = Time.deltaTime * this.accelRotate;

            //0~1 사이의 값
            float normalizeFactor = Mathf.Clamp01(Mathf.Abs(rotDelta / delta));

            this.nowRotateRoll = Mathf.Lerp(this.nowRotateRoll, target, normalizeFactor);
        }
    }
    public void FireGun()
    {
        for (int i = 0; i < guns.Length; ++i)
        {
            this.guns[i].Fire();
        }
    }
}
