using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuest : MonoBehaviour
{
    private string strQuest;

    public UILabel uiLabel;
    public string strName;

    private void Awake()
    {
        uiLabel.enabled = false;
        uiLabel.fontSize = 80;
        uiLabel.color = Color.white;
    }

    public void ShowQuest1()
    {
        strQuest = "{0}님 첫 번째 퀘스트입니다.\n [ff0000]멧돼지 10마리[-]를 잡아 오세요.";
        strQuest = string.Format(strQuest, strName);

        uiLabel.enabled = true;
        uiLabel.text = strQuest;
    }

    public void ShowQuest2()
    {
        strQuest = string.Format("{0}님 두 번째 퀘스트입니다.\n [ff0000]멧돼지 10마리[-]를 잡아 오세요.", strName);

        uiLabel.enabled = true;
        uiLabel.text = strQuest;
    }

    public void ShowQuest3()
    {
        strQuest = "{0} {1}님 세 번째 퀘스트입니다.\n [ff0000]멧돼지 10마리[-]를 잡아 오세요.";
        strQuest = string.Format(strQuest, strName, strName);

        uiLabel.enabled = true;
        uiLabel.text = strQuest;
    }
}
