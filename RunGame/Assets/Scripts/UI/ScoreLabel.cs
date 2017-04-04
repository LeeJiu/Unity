using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    private GameObject gPlayer;

    private UILabel uiLabel;
    private int nScore;

    void Awake()
    {
        gPlayer = GameManager.Instance.gPlayer;
        uiLabel = this.GetComponentInChildren<UILabel>();
        uiLabel.text = "Score [ff0000]" + gPlayer.GetComponent<PlayerInfo>().nScore;
    }


    void Update ()
    {
        uiLabel.text = "Score [ff0000]" + gPlayer.GetComponent<PlayerInfo>().nScore;
    }
}
