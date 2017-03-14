using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTest : MonoBehaviour
{
    public UISprite uiSprite;

    private void Awake()
    {
        uiSprite = this.GetComponent<UISprite>();
        uiSprite.type = UIBasicSprite.Type.Filled;
        uiSprite.fillAmount = 0.0f;
    }

    void Update ()
    {
        uiSprite.fillAmount += 0.01f;

        if (uiSprite.fillAmount == 1.0f)
        {
            uiSprite.fillAmount = 0.0f;
        }
	}
}
