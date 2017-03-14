using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemInfo
{
    public string name;
    public int value;
    public Sprite icon;
    public string comment;

    public ItemInfo() { }
    public ItemInfo(string name, int value, Sprite icon, string comment)
    {
        this.name = name;
        this.value = value;
        this.icon = icon;
        this.comment = comment;
    }
}



public class ItemDataBase : MonoBehaviour
{
    private static ItemDataBase sInstance = null;

    public static ItemDataBase Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject gObj = new GameObject("_ItemDataBase");
                sInstance = gObj.AddComponent<ItemDataBase>();
            }
            return sInstance;
        }
    }

    private Sprite[] itemIcons;         //리소스 폴더에서 가져다 쓸 아이템 아이콘들
    private List<ItemInfo> itemInfos;   //아이템 정보를 담아둘 리스트

	void Awake ()
    {
        //조각낸 아이템 아이콘들의 스프라이트를 전부 가져온다.
        itemIcons = Resources.LoadAll<Sprite>("Textures/items");

        //아이템 데이터 베이스 구성(리스트에 목록 추가)
        itemInfos = new List<ItemInfo>();
        itemInfos.Add(new ItemInfo("캔들1", 10, itemIcons[0], "바람 불어도 안 꺼진다."));
        itemInfos.Add(new ItemInfo("횃불", 20, itemIcons[1], "횃불"));
        itemInfos.Add(new ItemInfo("캔들2", 30, itemIcons[2], "바람 불면 꺼진다."));
        itemInfos.Add(new ItemInfo("밧줄", 40, itemIcons[3], "밧줄"));
        itemInfos.Add(new ItemInfo("책1", 50, itemIcons[4], "빨간 책"));
        itemInfos.Add(new ItemInfo("책2", 60, itemIcons[5], "파란 책"));
    }

    public ItemInfo this[int index]
    {
        get
        {
            return itemInfos[index];
        }
    }
	
    public ItemInfo RandomItem
    {
        get
        {
            return itemInfos[Random.Range(0, itemInfos.Count)];
        }
    }

    public int ItemCount
    {
        get
        {
            return itemInfos.Count;
        }
    }

	void Update ()
    {
		
	}
}
