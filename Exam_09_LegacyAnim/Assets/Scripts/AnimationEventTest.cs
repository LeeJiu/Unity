using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animation))]
public class AnimationEventTest : MonoBehaviour
{
    private Animation charAnim;
    private static bool bAddEvent = false;

    public Collider atkHitCollider;
    public Transform hitTrans;
    public Transform leftFootTrans;
    public Transform rightFootTrans;
    public GameObject effect;
    public GameObject effect_step;

    private void Awake()
    {
        this.charAnim = this.GetComponent<Animation>();

        if(bAddEvent == false)
        {
            //애니메이션 이벤트 추가
            AnimationEvent atkEvent = new AnimationEvent();

            atkEvent.functionName = "AttackStart";
            //위의 함수가 없어도 예외처리(경고)를 하지 않겠다.
            atkEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
            atkEvent.time = 10.0f / 32.0f;
            //애니메이션에 이벤트 함수 추가하기
            this.charAnim["Atk1"].clip.AddEvent(atkEvent);

            ///////////////////////////////////////////////////////////////////

            //애니메이션 이벤트2 추가
            AnimationEvent atkEvent2 = new AnimationEvent();

            atkEvent2.functionName = "AttackEnd";
            //위의 함수가 없어도 예외처리(경고)를 하지 않겠다.
            atkEvent2.messageOptions = SendMessageOptions.DontRequireReceiver;
            atkEvent2.time = 20.0f / 32.0f;
            //애니메이션에 이벤트 함수 추가하기
            this.charAnim["Atk1"].clip.AddEvent(atkEvent2);

            //////////////////////////////////////////////////////////////////
            
            //애니메이션 이벤트 추가
            AnimationEvent atkEvent3 = new AnimationEvent();

            atkEvent3.functionName = "atkPosition";
            //위의 함수가 없어도 예외처리(경고)를 하지 않겠다.
            atkEvent3.messageOptions = SendMessageOptions.DontRequireReceiver;
            atkEvent3.time = 10.0f / 32.0f;
            //애니메이션에 이벤트 함수 추가하기
            this.charAnim["Atk1"].clip.AddEvent(atkEvent3);

            //////////////////////////////////////////////////////////////////
            // STEP
            //////////////////////////////////////////////////////////////////

            //애니메이션 이벤트 추가
            AnimationEvent stepEvent = new AnimationEvent();

            stepEvent.functionName = "Left_Step";
            //위의 함수가 없어도 예외처리(경고)를 하지 않겠다.
            stepEvent.messageOptions = SendMessageOptions.DontRequireReceiver;
            stepEvent.time = 0.0f / 16.0f;
            //애니메이션에 이벤트 함수 추가하기
            this.charAnim["Run"].clip.AddEvent(stepEvent);

            //////////////////////////////////////////////////////////////////

            //애니메이션 이벤트 추가
            AnimationEvent stepEvent2 = new AnimationEvent();

            stepEvent2.functionName = "Right_Step";
            //위의 함수가 없어도 예외처리(경고)를 하지 않겠다.
            stepEvent2.messageOptions = SendMessageOptions.DontRequireReceiver;
            stepEvent2.time = 9.0f / 16.0f;
            //애니메이션에 이벤트 함수 추가하기
            this.charAnim["Run"].clip.AddEvent(stepEvent2);
        }

        this.atkHitCollider.enabled = false;
    }

    void AttackStart()
    {
        this.atkHitCollider.enabled = true;
        print(this.gameObject.name.ToString() + " 공격 시작");
       
        //effect
        GameObject newGameObject = Instantiate(
            this.effect, this.hitTrans.position, Quaternion.identity) as GameObject;

        Destroy(newGameObject, 1.0f);
    }

    void AttackEnd()
    {
        this.atkHitCollider.enabled = false;

        print(this.gameObject.name.ToString() + " 공격 끝");
    }

    void atkPosition()
    {
        Collider[] cols =
            Physics.OverlapSphere(this.hitTrans.position, 2.0f);

        for(int i =0; i< cols.Length; ++i)
        {
            //본인과 같은 테그가 아니면 지운다.
            if(cols[i].gameObject.tag != this.gameObject.tag)
            {
                Destroy(cols[i].gameObject);
            }
        }
    }

    //runFront 오른쪽 발 디딜 때 이펙트
    void Right_Step()
    {
        //effect
        GameObject newGameObject = Instantiate(
            this.effect_step, this.rightFootTrans.position, Quaternion.identity) as GameObject;

        Destroy(newGameObject, 1.0f);
    }

    void Left_Step()
    {
        //effect
        GameObject newGameObject = Instantiate(
            this.effect_step, this.leftFootTrans.position, Quaternion.identity) as GameObject;

        Destroy(newGameObject, 1.0f);
    }
}
