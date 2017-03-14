using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Canvas parentCanvas;


	void Awake()
    {
        Cursor.visible = false;
        parentCanvas = this.GetComponentInParent<Canvas>();	
	}
	

	void Update ()
    {
        Vector2 pos;

        //화면상의 위치를 특정 RectTransform 의 로컬 포지션으로 얻어준다.
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform, 
            new Vector2(Input.mousePosition.x, Input.mousePosition.y), 
            parentCanvas.worldCamera, 
            out pos))
        {
            //위에서 얻은 로컬 포지션을 가지고 월드 포지션으로 대입한다.
            this.transform.position = 
                parentCanvas.transform.TransformPoint(new Vector3(pos.x, pos.y, 0.0f));
        }
	}
}
