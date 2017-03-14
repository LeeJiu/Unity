using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    private UIProgressBar uiProgressBar;
    public float maxHp = 500.0f;

    private float curHp = 0.0f;
    private UILabel hpText;

    private bool bHeal = false;
    private float healAmount = 0.0f;
    private bool bDamage = false;
    private float damageAmount = 0.0f;

    private float timeD = 0.0f;

    void Awake()
    {
        uiProgressBar = this.GetComponent<UIProgressBar>();

        curHp = maxHp;
        uiProgressBar.foregroundWidget.color = Color.green;     //피통 색

        //피 수치 텍스트
        hpText = this.GetComponentInChildren<UILabel>();
        hpText.text = curHp.ToString() + " HEALTH";
        hpText.color = Color.black;
    }

    void Update()
    {
        curHp = (curHp >= maxHp) ? maxHp : curHp;
        curHp = (curHp <= 0.0f) ? 0.0f : curHp;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bHeal = true;
            healAmount = 50.0f;  
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bDamage = true;
            damageAmount = 30.0f;
        }

        GetHeal();
        GetDamage();

        //체력 바의 밸류 설정
        uiProgressBar.value = curHp / maxHp;
        hpText.text = ((int)curHp).ToString() + " HEALTH";

        ChangeColor();
    }

    void GetHeal()
    {
        if(bHeal == true)
        {
            curHp += Time.deltaTime * 50.0f;
            healAmount -= Time.deltaTime * 50.0f;

            if(healAmount <= 0.0f || curHp >= maxHp)
            {
                bHeal = false;
            }
        }
    }

    void GetDamage()
    {
        if (bDamage == true)
        {
            curHp -= Time.deltaTime * 30.0f;
            damageAmount -= Time.deltaTime * 30.0f;

            if (damageAmount <= 0.0f || curHp <= 0.0f)
            {
                bDamage = false;
            }
        }
    }

    void ChangeColor()
    {
        //체력바에 비례해서 색이 바뀐다.
        Color tempColor = Color.Lerp(Color.red, Color.green, uiProgressBar.value);
        uiProgressBar.foregroundWidget.color = tempColor;
    }
}
