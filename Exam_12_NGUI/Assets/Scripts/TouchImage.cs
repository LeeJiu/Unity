using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchImage : MonoBehaviour
{
    public UILabel pointerIDLabel;

    public void SetFingerID(int id)
    {
        pointerIDLabel.text = id.ToString() + " 번";
    }
}
