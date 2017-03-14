using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBarFixed : MonoBehaviour
{
    private UIScrollBar uiScrollBar;
    private bool bReset = false;

	void Awake ()
    {
        uiScrollBar = this.GetComponent<UIScrollBar>();
	}
	
	void LateUpdate ()
    {
        //인벤토리가 커져서 스크롤바(foreground)의 사이즈가 작아진 상황
		if(Mathf.Abs(1.0f - uiScrollBar.barSize) > 0.01f)
        {
            bReset = true;
        }

        //인벤토리의 아이템이 삭제가 돼서 스크롤바가 사라진 상황
        //스크롤바 사이즈 == 1.0f 를 Epsilon 으로 계산한 것
        if(Mathf.Abs(1.0f - uiScrollBar.barSize) < 0.01f)
        {
            if(bReset == true)
            {
                uiScrollBar.value = 1.0f;
                bReset = false;
            }
            else
            {
                uiScrollBar.value = 0.0f;
            }
        }
	}
}
