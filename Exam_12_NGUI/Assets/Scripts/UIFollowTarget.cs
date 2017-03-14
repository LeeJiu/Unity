using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowTarget : MonoBehaviour
{
    public GameObject target;

    private UILabel uiLabel;
    private Camera targetCamera;    //타겟을 찍고 있는 카메라 정보
    private Camera uiCamera;        //UI 를 찍고 있는 카메라 정보


    private void Awake()
    {
        uiLabel = this.GetComponent<UILabel>();

        //오브젝트의 레이어 값을 이용해서 해당 오브젝트를 찍고 있는 카메라를 찾아준다.
        targetCamera = NGUITools.FindCameraForLayer(target.layer);
        uiCamera = this.GetComponentInParent<Camera>();
    }

    void Update ()
    {
        //타겟의 스크린 위치를 계산한다.
        Vector3 screenPos = targetCamera.WorldToScreenPoint(target.transform.position);

        //타겟이 화면에 보여질 때
        if(screenPos.z >= 0.0f)
        {
            //위에서 계산한 화면의 위치로 UI 의 월드 위치를 계산한다.
            Vector3 uiPos = uiCamera.ScreenToWorldPoint(screenPos);

            uiLabel.fontSize = 50 - (int)uiPos.z;
            uiPos.z = 0.0f;

            this.transform.position = uiPos;
        }
	}
}
