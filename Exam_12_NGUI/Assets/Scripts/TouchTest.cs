using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    private TouchImage[] childTouchImage;
    private Camera uiCamera;

    private void Awake()
    {
        childTouchImage = this.GetComponentsInChildren<TouchImage>();
        uiCamera = this.GetComponentInParent<Camera>();
    }

    void Update ()
    {
        //터치 이미지들을 전부 비활성화
		for(int i = 0; i < this.childTouchImage.Length; ++i)
        {
            childTouchImage[i].gameObject.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 click2D = Input.mousePosition;
            Vector3 click3D = new Vector3(click2D.x, click2D.y, 0.0f);

            int nID = 0;

            childTouchImage[nID].gameObject.SetActive(true);
            childTouchImage[nID].SetFingerID(nID);

            Vector3 world = uiCamera.ScreenToWorldPoint(click3D);
            childTouchImage[nID].transform.position = world;
        }

        //터치된 정보들을 터치 배열에 담는다.
        Touch[] touches = Input.touches;

        for(int i = 0; i < touches.Length; ++i)
        {
            Vector2 touch2D = touches[i].position;
            Vector3 touch3D = new Vector3(touch2D.x, touch2D.y, 0.0f);

            int fingerID = touches[i].fingerId;

            childTouchImage[i].gameObject.SetActive(true);
            childTouchImage[i].SetFingerID(fingerID);

            Vector3 world = uiCamera.ScreenToWorldPoint(touch3D);
            childTouchImage[i].transform.position = world;
        }
	}
}
