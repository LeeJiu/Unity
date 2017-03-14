using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheck : MonoBehaviour
{
    public GUIStyle guiStyle;

    private int minute = 0;
    private float second = 0.0f;

    public bool isGoal = false;

    void Update ()
    {
        if(isGoal == false)
        {
            second += Time.deltaTime;
            if (second >= 60)
            {
                minute++;
                second = 0.0f;
            }
        }
	}

    void OnGUI()
    {
        GUI.Label(new Rect(300, 0, 100, 50), string.Format("{0} : {1}", minute, second), this.guiStyle);
    }
}
