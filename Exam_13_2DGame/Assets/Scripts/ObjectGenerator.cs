using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public float fGenRange = 10.0f;


	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GenObject();
        }
        else if(Input.GetKeyDown(KeyCode.Backspace))
        {
            DelObject();
        }
    }

    void GenObject()
    {
        int nObjType = Random.Range(0, 3);

        GameObject newObj = GameObject.CreatePrimitive((PrimitiveType)nObjType);

        newObj.name = nObjType.ToString();

        Vector3 pos = new Vector3(
            Random.Range(-fGenRange, fGenRange), 
            Random.Range(-fGenRange, fGenRange), 
            Random.Range(-fGenRange, fGenRange));

        Vector3 rot = new Vector3(
            Random.Range(-180.0f, 180.0f),
            Random.Range(-180.0f, 180.0f),
            Random.Range(-180.0f, 180.0f));

        newObj.name = nObjType.ToString();
        newObj.transform.position = pos;
        newObj.transform.eulerAngles = rot;
        newObj.tag = "SaveObject";
        newObj.transform.SetParent(this.transform);
    }

    void DelObject()
    {
        GameObject[] gFindObject = GameObject.FindGameObjectsWithTag("SaveObject");

        if(gFindObject.Length > 0)
        {
            GameObject delTarget = gFindObject[Random.Range(0, gFindObject.Length - 1)];
            Destroy(delTarget);
        }
    }
}
