using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    private void Awake()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat("PosX", this.transform.position.x);
        PlayerPrefs.SetFloat("PosY", this.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", this.transform.position.z);
        PlayerPrefs.SetFloat("RotY", this.transform.eulerAngles.y);

        SaveManager.Instance.Save();

        PlayerPrefs.Save();
    }

    public void Load()
    {
        Vector3 vPos = Vector3.zero;
        Vector3 vRot = Vector3.zero;

        if(PlayerPrefs.HasKey("PosX"))
        {
            vPos.x = PlayerPrefs.GetFloat("PosX");
        }

        if (PlayerPrefs.HasKey("PosY"))
        {
            vPos.y = PlayerPrefs.GetFloat("PosY");
        }

        if (PlayerPrefs.HasKey("PosZ"))
        {
            vPos.z = PlayerPrefs.GetFloat("PosZ");
        }

        if (PlayerPrefs.HasKey("RotY"))
        {
            vRot.y = PlayerPrefs.GetFloat("RotY");
        }

        this.transform.position = vPos;
        this.transform.eulerAngles = vRot;

        SaveManager.Instance.Load();
    }
}
