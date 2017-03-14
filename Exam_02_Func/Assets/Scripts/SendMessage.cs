using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessage : MonoBehaviour {

    public GameObject targetObject;

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            targetObject.SendMessage("ReceiveTest", "Hello!", SendMessageOptions.DontRequireReceiver);

            targetObject.SendMessage("ReceiveTest2");

            //함수가 없으면 무시
            targetObject.SendMessage("ReceiveTest3", SendMessageOptions.DontRequireReceiver);
        }
	}
}
