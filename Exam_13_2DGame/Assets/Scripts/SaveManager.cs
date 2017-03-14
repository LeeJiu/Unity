using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//추가
//2진 데이터 형식을 사용하기 위해서
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;    //메모리 스트림을 사용하기 위해
using System;       //Convert, Serialization 을 사용하기 위해서


//클래스의 메모리 공간을 직렬화하려 할당 / 연결된 메모리 할당
[Serializable]
public class cObjectInfo
{
    public string name;

    public float posX;
    public float posY;
    public float posZ;

    public float rotX;
    public float rotY;
    public float rotZ;
}

public class SaveManager : MonoBehaviour
{
    private static SaveManager sInstance;
    public static SaveManager Instance
    {
        get
        {
            if(sInstance == null)
            {
                GameObject gObj = new GameObject("_SaveManager");
                sInstance = gObj.AddComponent<SaveManager>();
            }
            return sInstance;
        }
    }

	
    public void Save()
    {
        GameObject[] gSaveObjects = GameObject.FindGameObjectsWithTag("SaveObject");

        List<cObjectInfo> lstObjInfos = new List<cObjectInfo>();

        for(int i = 0; i < gSaveObjects.Length; ++i)
        {
            cObjectInfo cObjSave = new cObjectInfo();

            cObjSave.name = gSaveObjects[i].name;
            cObjSave.posX = gSaveObjects[i].transform.position.x;
            cObjSave.posY = gSaveObjects[i].transform.position.y;
            cObjSave.posZ = gSaveObjects[i].transform.position.z;
            cObjSave.rotX = gSaveObjects[i].transform.eulerAngles.x;
            cObjSave.rotY = gSaveObjects[i].transform.eulerAngles.y;
            cObjSave.rotZ = gSaveObjects[i].transform.eulerAngles.z;

            lstObjInfos.Add(cObjSave);
        }

        //2진화된 데이터를 담을 메모리 공간
        MemoryStream memStream = new MemoryStream();

        //2진 데이터 변환 클래스
        BinaryFormatter formatter = new BinaryFormatter();

        //메모리스트림에 리스트의 내용들을 2진 데이터화해서 저장한다.
        formatter.Serialize(memStream, lstObjInfos);

        //메모리 스트림에 저장된 2진 데이터를 byte 배열에 저장한다.
        byte[] bytes = memStream.GetBuffer();

        //bytes 배열을 문자열로 바꾼다.
        string memStr = Convert.ToBase64String(bytes);

        PlayerPrefs.SetString("SaveObject", memStr);
    }

    public void Load()
    {
        GameObject[] gRemainedObj = GameObject.FindGameObjectsWithTag("SaveObject");

        for(int i = 0; i < gRemainedObj.Length; ++i)
        {
            Destroy(gRemainedObj[i]);
        }

        if(PlayerPrefs.HasKey("SaveObject"))
        {
            string memStr = PlayerPrefs.GetString("SaveObject");

            //문자열을 byte 배열로 바꾼다.
            byte[] bytes = Convert.FromBase64String(memStr);

            //byte 배열을 메모리스트림에 담는다.
            MemoryStream memStream = new MemoryStream(bytes);

            //2진 데이터 변환 클래스
            BinaryFormatter formatter = new BinaryFormatter();

            //메모리 스트림에 저장된 내용을 리스트 형태로 복구시킨다.
            List<cObjectInfo> loadInfos = (List<cObjectInfo>)formatter.Deserialize(memStream);

            for(int i = 0; i < loadInfos.Count; ++i)
            {
                int objType = int.Parse(loadInfos[i].name);

                if(objType >= 0 && objType <= 3)
                {
                    GameObject gLoadObject = GameObject.CreatePrimitive((PrimitiveType)objType);     

                    Vector3 pos = 
                        new Vector3(loadInfos[i].posX, loadInfos[i].posY, loadInfos[i].posZ);

                    Vector3 rot = 
                        new Vector3(loadInfos[i].rotX, loadInfos[i].rotY, loadInfos[i].rotZ);

                    gLoadObject.name = loadInfos[i].name;
                    gLoadObject.transform.position = pos;
                    gLoadObject.transform.eulerAngles = rot;
                    gLoadObject.tag = "SaveObject";
                }
            }
        }
    }
}
