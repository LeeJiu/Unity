using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPad : MonoBehaviour
{
    private UISprite uiOutCircle;
    private UISprite uiInCircle;
    private float fRadius;

    private int nFingerID = -1; // -1 : 터치가 안된 초기값
    private Camera uiCam;

    void Awake ()
    {
        uiOutCircle = this.transform.FindChild("OuterCircle").GetComponent<UISprite>();
        uiInCircle = this.transform.FindChild("InnerCircle").GetComponent<UISprite>();

        fRadius = uiOutCircle.localSize.x / 2;

        uiCam = this.GetComponentInParent<Camera>();
    }
	

	void Update ()
    {

#if UNITY_ANDROID
        if(nFingerID != -1)
        {
            Vector3 myJoyStick = uiCam.WorldToScreenPoint(this.transform.position);
            Vector2 myJoyStick2D = new Vector2(myJoyStick.x, myJoyStick.y);

            Touch[] touches = Input.touches;

            for(int i = 0; i < touches.Length; ++i)
            {
                if(touches[i].fingerId == nFingerID)
                {
                    Vector2 touchPos = touches[i].position;
                    Vector2 dirTouch = touchPos - myJoyStick2D;

                    float dirTouchLength = dirTouch.magnitude;

                    //터치가 터치 반경 밖으로 나간 경우
                    if(dirTouchLength > fRadius)
                    {
                        uiInCircle.transform.localPosition = dirTouch.normalized * fRadius;
                    }
                    else
                    {
                        uiInCircle.transform.position = uiCam.ScreenToWorldPoint(touchPos);
                    }

                    return;
                }
            }

            SetRelease();
        }

#elif UNITY_STANDALONE
        Vector3 pos = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            pos.y = fRadius / 2;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            pos.y = -fRadius / 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.x = -fRadius / 2;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x = fRadius / 2;
        }

        if(pos == Vector3.zero)
        {
            SetRelease();
        }
        else
        {
            SetPress();
            uiInCircle.transform.localPosition = pos;
        }

#endif

    }

    //NGUI 내장 함수 / 터치할 때 자동으로 들어온다. / 업데이트에서 불러올 필요 없다.
    void OnPress()
    {
        //터치가 안 됐으면 나가라.
        if(nFingerID != -1)
        {
            return;
        }

        Touch[] touches = Input.touches;

        //터치 정보를 월드 포인트에서 스크린 포인트(화면상의 좌표)로 저장한다.
        Vector3 myJoyStick = uiCam.WorldToScreenPoint(this.transform.position);
        Vector2 myJoyStick2D = new Vector2(myJoyStick.x, myJoyStick.y);

        for(int i = 0; i < touches.Length; ++i)
        {
            //스크린 위치의 터치 포인트
            Vector2 touchPos = touches[i].position;

            //화면 기준의 자신의 위치에서 터치 방향
            Vector2 dirTouch = touchPos - myJoyStick2D;
            
            //방향 벡터의 크기 값으로 터치 패드가 움직인 양을 알 수 있다.
            float dirTouchLength = dirTouch.magnitude;

            //터치한 위치가 터치패드의 반경을 벗어나지 않은 경우
            if(dirTouchLength <= fRadius)
            {
                nFingerID = touches[i].fingerId;

                uiInCircle.transform.position = uiCam.ScreenToWorldPoint(touchPos);

                SetPress();

                break;
            }
        }
    }

    void SetPress()
    {
        uiOutCircle.spriteName = "OuterOn";
        uiInCircle.spriteName = "InnerOn";
    }

    void SetRelease()
    {
        uiOutCircle.spriteName = "OuterOff";
        uiInCircle.spriteName = "InnerOff";
        nFingerID = -1;
        uiInCircle.transform.localPosition = Vector3.zero;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 300, 50), fRadius.ToString());
        GUI.Label(new Rect(0, 30, 300, 50), uiInCircle.transform.localPosition.ToString());

        if(GUI.Button(new Rect(10, 60, 60, 110), "QUIT"))
        {
            Application.Quit();
        }
    }

    public Vector2 ControlDir
    {
        get
        {
            Vector2 dir = new Vector2(uiInCircle.transform.localPosition.x,
                uiInCircle.transform.localPosition.y);

            return dir / fRadius;
        }
    }
}
