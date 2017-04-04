using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    private GameObject gPlayer;

    private UIProgressBar uiProgressBar;
    private UILabel uiLabel;

    private int nCurHp;
    private int nMaxHp;

	void Awake ()
    {
        gPlayer = GameManager.Instance.gPlayer;

        nMaxHp = gPlayer.GetComponent<PlayerInfo>().nHp;
        nCurHp = nMaxHp;

        uiProgressBar = this.GetComponent<UIProgressBar>();

        uiLabel = this.GetComponentInChildren<UILabel>();
        uiLabel.text = "HP " + nCurHp + " / " + nMaxHp;
	}
	

	void Update ()
    {
        nCurHp = gPlayer.GetComponent<PlayerInfo>().nHp;

        uiProgressBar.value = ((float)nCurHp / (float)nMaxHp);

        uiLabel.text = "HP " + nCurHp + " / " + nMaxHp;
    }
}
