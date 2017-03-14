using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotDrag : ItemSlot, IComparer<ItemSlot>
{
    private static ItemSlotDrag sInstance;
    public static ItemSlotDrag Instance
    {
        get
        {
            return sInstance;
        }
    }

    public List<ItemSlot> targetSlots = new List<ItemSlot>();
    public ItemSlot targetSlot = null;
    public ItemSlot catchSlot = null;


    protected new void Awake ()
    {
        sInstance = this;
        this.gameObject.SetActive(false);

        base.Awake();	
	}

    void Start() { }  //부모의 스타트 함수가 실행되는걸 막는다.
	

	void Update ()
    {
		if(targetSlots.Count > 0)
        {
            //나랑 충돌되어 드랍될 슬롯리스트를 나랑 제일 가까운 놈 순으로 정렬
            targetSlots.Sort(this);

            //가장 가까운 슬롯을 타겟 슬롯으로 잡는다.
            targetSlot = targetSlots[0];

            targetSlot.SlotOn();

            for(int i = 1; i < targetSlots.Count; ++i)
            {
                targetSlots[i].SlotOff();
            }
        }
        else
        {
            targetSlot = null;
        }
	}

    public void Catch(ItemSlot itemSlot, Vector2 screenPos)
    {
        this.gameObject.SetActive(true);

        //집은 아이템이 제일 앞에 그려지도록 한다.
        this.transform.SetAsLastSibling();

        //집은 아이템 슬롯의 정보 저장
        catchSlot = itemSlot;

        //집은 아이템에 대한 정보를 세팅
        SetItemInfo(itemSlot.GetItemInfo());

        //집은 아이템칸을 비움
        itemSlot.SetItemInfo(null);

        this.transform.position = new Vector3(screenPos.x, screenPos.y, 0);
    }

    public void DragMove(Vector2 screenPos)
    {
        this.transform.position = new Vector3(screenPos.x, screenPos.y, 0);
    }

    public void Drop()
    {
        if(this.GetItemInfo() == null)
        {
            return;
        }

        if(targetSlot == null)
        {
            catchSlot.SetItemInfo(this.GetItemInfo());
        }
        else
        {
            //셔플용
            ItemInfo targetItemInfo = targetSlot.GetItemInfo();

            if(targetItemInfo != null)
            {
                catchSlot.SetItemInfo(targetItemInfo);
            }

            targetSlot.SetItemInfo(this.GetItemInfo());
            targetSlot.SlotOff();
        }

        targetSlots.Clear();
        this.SetItemInfo(null);
        catchSlot = null;

        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemSlot itemSlot = collision.GetComponent<ItemSlot>();

        if(itemSlot != null)
        {
            targetSlots.Add(itemSlot);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ItemSlot itemSlot = collision.GetComponent<ItemSlot>();

        if (itemSlot != null)
        {
            targetSlots.Remove(itemSlot);
            itemSlot.SlotOff();
        }
    }

    public int Compare(ItemSlot s1, ItemSlot s2)
    {
        //s1 가 가깝다면 -1
        //s2 가 가깝다면 1
        //같다면 0
        float distS1= Vector3.Distance(s1.transform.position, this.transform.position);
        float distS2 = Vector3.Distance(s2.transform.position, this.transform.position);

        if(distS1 < distS2)
        {
            return -1;
        }
        else if(distS1 > distS2)
        {
            return 1;
        }

        return 0;
    }
}
