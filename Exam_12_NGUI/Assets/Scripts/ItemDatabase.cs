using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    public static string[] iconName =
    {
        "Orc Armor - Bracers",
        "Orc Armor - Boots",
        "Orc Armor - Shoulders"
    };

    public int nId;             // 아이템 번호
    public string strName;      // 아이템 이름
    public string strComment;   // 아이템 설명
    public int nValue;          // 아이템 가격
    public int nImageIndex;    // 아이템 이미지 인덱스 번호

    public ItemInfo(int id, string name, string comment, int value, int imageIndex)
    {
        nId = id;
        strName = name;
        strComment = comment;
        nValue = value;
        nImageIndex = imageIndex;
    }
}

public class ItemDatabase : MonoBehaviour
{
    private static ItemDatabase sInstance;
    public static ItemDatabase Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("_ItemDatabase");
                sInstance = newGameObject.AddComponent<ItemDatabase>();
            }
            return sInstance;
        }
    }

    //아이템 정보 클래스를 저장하는 리스트
    protected List<ItemInfo> itemInfos;

    private void Awake()
    {
        sInstance = this;
        itemInfos = new List<ItemInfo>();

        itemInfos.Add(new ItemInfo(0, "1", "1번 아이템", 100, 0));
        itemInfos.Add(new ItemInfo(1, "2", "2번 아이템", 200, 1));
        itemInfos.Add(new ItemInfo(2, "3", "3번 아이템", 300, 2));
    }

    //랜덤 아이템 정보 전달
    public virtual ItemInfo GetRandomItem
    {
        get
        {
            return itemInfos[Random.Range(0, itemInfos.Count)];
        }
    }

    //인덱스 번호로 아이템 정보 전달
    public ItemInfo GetItem(int index)
    {
        if (itemInfos.Count == 0 || index > itemInfos.Count)
        {
            return null;
        }

        return itemInfos[index];
    }

    //인덱스 프로퍼티로 접근해서 아이템 정보 전달 / 클래스를 배열처럼 사용 가능하게
    public ItemInfo this[int index]
    {
        get
        {
            if(itemInfos.Count == 0 || index >= itemInfos.Count)
            {
                return null;
            }

            return itemInfos[index];
        }
    }

    public void AddNewItemType(ItemInfo itemInfo)
    {
        itemInfo.nId = itemInfos.Count;
        itemInfos.Add(itemInfo);
    }
}
