using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public int nCount = 3;
    private int nNextCount;

    private UILabel uiLabel;

    void Awake()
    {
        nNextCount = nCount - 1;

        uiLabel = this.GetComponent<UILabel>();
        uiLabel.text = nCount.ToString();

        StartCoroutine(CoCountDown());
    }

    void Update()
    {
        if(nNextCount == nCount)
        {
            nNextCount--;
            if (nCount > 0)
            {
                StartCoroutine(CoCountDown());
            }
            else
            {
                uiLabel.text = "Go!";
                GameManager.Instance.bStart = true;
                GameManager.Instance.gPlayer.GetComponent<CharacterControl>().StartRun();
                Destroy(this.gameObject, 0.5f);
            }
        }
    }

    IEnumerator CoCountDown()
    {
        yield return new WaitForSeconds(1.0f);
        nCount = nNextCount;
        uiLabel.text = nCount.ToString();
    }
}
