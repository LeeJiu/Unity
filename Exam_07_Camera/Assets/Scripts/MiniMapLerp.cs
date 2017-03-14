using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapLerp : MonoBehaviour
{
    private bool isOn;
    private Vector3 originPos;
    private Vector2 centerPos;

    private void Awake()
    {
        isOn = false;
        centerPos = this.transform.position;
        centerPos.x = Screen.width * 0.5f;
        originPos = this.transform.position;
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.M))
        {
            isOn = !isOn;
        }

        if(isOn == true)
        {
            Vector2 mapPos;
            mapPos.x = this.transform.position.x;
            mapPos.y = this.transform.position.y;
            mapPos = Vector2.Lerp(mapPos, centerPos, Time.deltaTime * 2);
            this.transform.position = new Vector3(mapPos.x, mapPos.y, this.transform.position.z);
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, this.originPos, Time.deltaTime * 2);
        }
	}
}
