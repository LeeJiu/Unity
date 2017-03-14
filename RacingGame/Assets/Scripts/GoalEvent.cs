using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEvent : MonoBehaviour
{
    public GUIStyle guiStyle;
    private string winnerName;

    private int goal = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            if(goal < 1)
            {
                winnerName = other.gameObject.name;
            }
            Destroy(other.gameObject);
        }
        else if(other.tag == "Player")
        {
            if (goal < 1)
            {
                winnerName = "Player";
            }
            Player obj = other.gameObject.GetComponent<Player>();
            obj.moveSpeed = 0;
            obj.rotate = 0.0f;

            TimeCheck time = other.gameObject.GetComponent<TimeCheck>();
            time.isGoal = true;
        }
        goal++;
    }

    void OnGUI()
    {
        if(goal > 0)
        {
            GUI.Label(new Rect(0, 0, 300, 50), string.Format(winnerName + " Won!"), this.guiStyle);
        }
    }
}
