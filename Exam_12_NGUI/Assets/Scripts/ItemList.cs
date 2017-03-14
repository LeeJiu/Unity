using System.Collections;
using System.Collections.Generic;
//추가
using System.Xml;
using System;
using System.Text;
//
using UnityEngine;


[RequireComponent(typeof(UIGrid))]
public class ItemList : MonoBehaviour
{
    public GameObject gItemBar;

    private UIGrid uiGrid;


	void Awake ()
    {
        uiGrid = this.GetComponent<UIGrid>();
        LoadHaveItemID();
    }

    private void OnApplicationQuit()
    {
        SaveHaveItemID();
    }

    public void AddRandomItem()
    {
        ItemInfo newItemInfo = ItemDatabase.Instance.GetRandomItem;
        AddItemBar(newItemInfo);
    }

    public void AddItemBar(ItemInfo newItemInfo)
    {
        GameObject newItemBar = 
            Instantiate(gItemBar, this.transform.position, Quaternion.identity) as GameObject;

        //현재 오브젝트를 새로 생성된 아이템바의 부모로 설정
        newItemBar.transform.SetParent(this.transform);

        //크기 조정
        newItemBar.transform.localScale = new Vector3(1, 1, 1);

        ItemBar newBar = newItemBar.GetComponent<ItemBar>();

        //아이템바에 정보를 세팅
        newBar.SetItemInfo(newItemInfo);

        //그리드 재정렬
        uiGrid.Reposition();
    }

    public void DeleteItemBar(ItemBar itemBar)
    {
        Destroy(itemBar.gameObject);

        StartCoroutine("CoDeleteItem");
    }

    IEnumerator CoDeleteItem()
    {
        yield return null;

        GameObject temp =
            Instantiate(gItemBar, this.transform.position, Quaternion.identity) as GameObject;

        temp.transform.SetParent(this.transform);
        Destroy(temp);

        uiGrid.Reposition();
    }

    void SaveHaveItemID()
    {
        XmlWriter xmlWriter = null;

        //Application.persistentDataPath
        //유니티에서 지정해준 외부파일 저장 절대 경로
        //ex) C:\User\1\AppData\LocalLow\DefaultCompany\26_NGUI
        string filePath = Application.persistentDataPath + "/HaveItem.xml";

        try
        {
            XmlWriterSettings xmlSetting = new XmlWriterSettings();
            xmlSetting.Indent = true;
            xmlSetting.Encoding = Encoding.UTF8;

            xmlWriter = XmlWriter.Create(filePath, xmlSetting);
        }
        catch (Exception e)
        {
            print(e);
            return;
        }

        xmlWriter.WriteStartElement("HaveItemList");

        //저장될 아이템의 개수(나의 자식 개수)만큼 포문을 돌려서 저장
        for(int i = 0; i < this.transform.childCount; ++i)
        {
            Transform childTrans = this.transform.GetChild(i);
            ItemBar itemBar = childTrans.gameObject.GetComponent<ItemBar>();

            if(itemBar != null)
            {
                int itemId = itemBar.GetItemInfo().nId;

                xmlWriter.WriteStartElement("ItemID");
                xmlWriter.WriteAttributeString("ID", itemId.ToString());
                xmlWriter.WriteEndElement();
            }
        }

        xmlWriter.WriteEndElement();

        xmlWriter.Close();
    }

    void LoadHaveItemID()
    {
        XmlReader xmlReader = null;

        string filePath = Application.persistentDataPath + "/HaveItem.xml";

        try
        {
            XmlReaderSettings xmlSetting = new XmlReaderSettings();
            xmlSetting.IgnoreComments = true;       //주석 부분은 읽지 말아라.
            xmlSetting.IgnoreWhitespace = true;     //공백 부분은 읽지 말아라.

            xmlReader = XmlReader.Create(filePath, xmlSetting);
        }
        catch (Exception e)
        {
            print(e);
            return;
        }

        while(xmlReader.Read())
        {
            if(xmlReader.Name == "ItemID" && xmlReader.NodeType == XmlNodeType.Element)
            {
                int itemID = int.Parse(xmlReader.GetAttribute("ID"));

                ItemInfo loadItemInfo = ItemDatabase.Instance[itemID];

                if(loadItemInfo != null)
                {
                    AddItemBar(loadItemInfo);
                }
            }
        }

        xmlReader.Close();
    }
}
