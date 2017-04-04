using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int nHp = 100;
    public int nScore = 0;
    public int nCoin = 0;

    public bool bDead = false;


    public void AddCoin()
    {
        if (bDead == true) return;
        nCoin++;
    }

    public void AddScore(int score)
    {
        if (bDead == true) return;
        nScore += score;
    }


    public void Damaged(int damaged)
    {
        nHp -= damaged;

        if(nHp <= 0)
        {
            nHp = 0;
            this.GetComponent<CharacterControl>().Dead();
            bDead = true;
            return;
        }

        this.GetComponent<CharacterControl>().Damaged();
    }
}
