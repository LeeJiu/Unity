using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpaceShip))]
public class SpaceShipControl : MonoBehaviour
{
    private SpaceShip airCraft;

    public GUIStyle guiStyle;

    void Awake()
    {
        this.airCraft = this.GetComponent<SpaceShip>();
    }

	void Update ()
    {
        float speedControl = 0.0f;
        float pitchControl = 0.0f;
        float yawControl = 0.0f;
        //float rollControl = 0.0f;

        //현재 마우스 위치를 얻는다.
        //좌하단이 0, 0이다.
        Vector3 mousePos = Input.mousePosition; //z값은 무시

        //마우스 위치값을 0~1 값으로
        float mX = Mathf.Clamp01(mousePos.x / Screen.width);
        float mY = Mathf.Clamp01(mousePos.y / Screen.height);

        //위의 마우스 위치값을 -1~1 로 바꾼다.
        pitchControl = (mY * 2.0f) - 1.0f;
        yawControl = (mX * 2.0f) - 1.0f;

        //SpaceShip 스크립트에 회전값 전달
        this.airCraft.Control_Pitch(-pitchControl);
        this.airCraft.Control_Yaw(yawControl);

        //키보드 w, s 키로 스피드 컨트롤
        speedControl = Input.GetAxis("Vertical");
        this.airCraft.Control_Speed(speedControl);

        if(Input.GetMouseButton(0))   //==Input.GetButton("Fire1")
        {
            this.airCraft.FireGun();
        }
    }

    void OnGUI()
    {
        //현재 마우스 위치를 얻는다.
        //좌하단이 0, 0이다.
        Vector3 mousePos = Input.mousePosition; //z값은 무시

        //마우스 위치값을 0~1 값으로
        float mX = Mathf.Clamp01(mousePos.x / Screen.width);
        float mY = Mathf.Clamp01(mousePos.y / Screen.height);

        //마우스 위치값 표시
        GUI.Label(new Rect(0, 0, 300, 50), string.Format("mX = {0:F2}, mY = {1:F2}", mX, mY), this.guiStyle);
    }
}
