using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLabel : MonoBehaviour
{
    private GameObject gPlayer;

    private UILabel uiLabel;
    private int nCoin;

    void Awake()
    {
        gPlayer = GameManager.Instance.gPlayer;
        uiLabel = this.GetComponentInChildren<UILabel>();
        uiLabel.text = "Coin [ff0000]" + gPlayer.GetComponent<PlayerInfo>().nCoin;
    }


    void Update()
    {
        uiLabel.text = "Coin [ff0000]" + gPlayer.GetComponent<PlayerInfo>().nCoin;
    }
}
