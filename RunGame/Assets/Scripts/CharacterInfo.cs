using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    int nHp;
    int nScore;
    int nCoin;

    void Awake()
    {
        nHp = 100;
        nScore = 0;
        nCoin = 0;
    }

    public float GetHp()
    {
        return nHp;
    }

    public int GetScore()
    {
        return nScore;
    }

    public int GetCoin()
    {
        return nCoin;
    }

    public void AddCoin()
    {
        nCoin++;
    }

    public void AddScore(int score)
    {
        nScore += score;
    }


    public void Damaged(int damaged)
    {
        Debug.Log("Damaged");
        nHp -= damaged;

        if(nHp <= 0)
        {
            this.GetComponent<CharacterControl>().Dead();
            return;
        }

        this.GetComponent<CharacterControl>().Damaged();
    }
}
