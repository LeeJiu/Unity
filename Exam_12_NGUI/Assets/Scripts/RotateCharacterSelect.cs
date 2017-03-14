using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacterSelect : MonoBehaviour
{
    public GameObject[] selectCharacter;    //선택할 캐릭터를 담을 배열
    public float circleRadius = 2.0f;       //캐릭터 배치 변경
    public float startAngle = 90.0f;        //시작 각도 / x = cos / z = sin
    public float rotatePerSec = 90.0f;      //초당 회전 속도

    private bool bRotate = false;           //회전 중이라면 클릭을 막는다.
    private float selectDelta;              //회전 중 시간 누적
    private float selectSec;                //다음 캐릭터로 선택이 바뀌는데 걸리는 시간
    private float prevEulerY;               //이전 y축 기준 각도
    private bool bLeft;
    private float intervalAngle;            //캐릭터 간의 각도 차이

    public AnimationCurve animC;            //회전 값 계산을 위한 함수 사용을 위해 선언

    void Awake()
    {
        intervalAngle = 360 / selectCharacter.Length;

        for (int i = 0; i < selectCharacter.Length; i++)
        {
            GameObject newObject;

            if (selectCharacter[i] != null)
            {
                newObject = Instantiate(selectCharacter[i], Vector3.zero, Quaternion.identity) as GameObject;
            }
            else
            {
                newObject = new GameObject();
            }

            //생성할 오브젝트의 이름 설정
            newObject.name = string.Format("Select Object {0}", i);

            //생성된 오브젝트를 내 자식으로 물린다.
            newObject.transform.parent = this.transform;

            //로컬 위치에서의 각도
            float angleRad = (startAngle + intervalAngle * i) * Mathf.Deg2Rad;

            //로컬의 위치
            Vector3 localPos = new Vector3(Mathf.Cos(angleRad) * circleRadius, 0.0f, Mathf.Sin(angleRad) * circleRadius);

            //방향벡터 구해서 정면을 바라보게 하는. (해당 캐릭터의 정면으로 바라보게)
            newObject.transform.localRotation = Quaternion.LookRotation(localPos.normalized);
            newObject.transform.localPosition = localPos;
        }

        //초당 회전 속도에 비례해서 하나 선택하는데 걸리는 시간을 계산한다.
        selectSec = intervalAngle / rotatePerSec;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //왼쪽으로 회전
            LeftSelect();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            //오른쪽으로 회전
            RightSelect();
        }

        if(bRotate == true)
        {
            //회전 중이라면 시간을 누적시킨다.
            selectDelta += Time.deltaTime;

            float t = Mathf.InverseLerp(0, selectSec, selectDelta);

            //회전이 끝났을 경우
            if(t >= 1.0f)
            {
                bRotate = false;

                Vector3 eAngle = this.transform.eulerAngles;
                
                if(bLeft == true)
                {
                    this.transform.eulerAngles.Set(eAngle.x, prevEulerY - intervalAngle, eAngle.z);
                }
                else
                {
                    this.transform.eulerAngles.Set(eAngle.x, prevEulerY + intervalAngle, eAngle.z);
                }
            }
            //회전 중일 경우
            else
            {
                Vector3 eAngle = this.transform.eulerAngles;

                if (bLeft == true)
                {
                    //animC.Evaluate(t) : 애니메이션 커브의 t만큼 진행된 벨류 값을 가져온다.
                    eAngle.y = prevEulerY - intervalAngle * animC.Evaluate(t);
                }
                else
                {
                    eAngle.y = prevEulerY + intervalAngle * animC.Evaluate(t);
                }

                this.transform.eulerAngles = eAngle;
            }
        }
    }

    public void LeftSelect()
    {
        if (bRotate == true) return;

        bRotate = true;
        selectDelta = 0.0f;
        prevEulerY = this.transform.eulerAngles.y;
        bLeft = true;
    }

    public void RightSelect()
    {
        if (bRotate == true) return;

        bRotate = true;
        selectDelta = 0.0f;
        prevEulerY = this.transform.eulerAngles.y;
        bLeft = false;
    }
}
