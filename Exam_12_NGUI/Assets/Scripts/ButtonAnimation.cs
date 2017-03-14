using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TweenScale))]
[RequireComponent(typeof(TweenRotation))]
public class ButtonAnimation : MonoBehaviour
{
    private TweenScale tweenScale;
    private TweenRotation tweenRotation;
    private Camera uiCamera;

	void Awake ()
    {
        tweenScale = this.GetComponent<TweenScale>();
        tweenRotation = this.GetComponent<TweenRotation>();
        uiCamera = this.GetComponentInParent<Camera>();
	}
	

	void Update ()
    {
        Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            tweenScale.enabled = true;
            tweenRotation.enabled = true;
        }
        else
        {
            if((tweenScale.value.x - tweenScale.from.x) < 0.01f)
            {
                tweenScale.enabled = false;
            }

            if(Mathf.Abs(tweenRotation.value.z) < 0.01f)
            {
                tweenRotation.enabled = false;
            }
        }
	}
}
