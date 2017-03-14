using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //엔진용 씬매니저 사용

public class ChangeScene : MonoBehaviour
{
    public int nextSceneNum = 1;    //이동할 씬 인덱스

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(this.nextSceneNum);
        }
	}
}
