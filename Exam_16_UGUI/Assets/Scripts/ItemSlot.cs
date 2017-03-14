using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//이벤트 시스템이 가지고 있는 인터페이스 핸들러
public class ItemSlot : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Image slotImage;
    private Image itemIcon;
    private ItemInfo itemInfo;
    private float alpha;

    private bool catchMe = false;


	protected void Awake ()
    {
        itemIcon = this.transform.FindChild("ItemIcon").GetComponent<Image>();

        slotImage = this.GetComponent<Image>();

        if(slotImage != null)
        {
            //원래 이미지의 알파값 저장해둠
            alpha = slotImage.color.a;
        }
	}
	

	void Start ()
    {
        int rand = Random.Range(0, 2);

        if(rand == 0)
        {
            SetItemInfo(ItemDataBase.Instance.RandomItem);
        }
        else
        {
            SetItemInfo(null);
        }
	}

    public void SetItemInfo(ItemInfo newItem)
    {
        itemInfo = newItem;

        if (itemInfo != null)
        {
            itemIcon.enabled = true;
            itemIcon.sprite = itemInfo.icon;
        }
        else
        {
            itemIcon.enabled = false;
        }
    }

    public ItemInfo GetItemInfo()
    {
        return itemInfo;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemInfo == null)
        {
            return;
        }

        catchMe = true;

        //print(itemInfo.name + " Catch");
        ItemSlotDrag.Instance.Catch(this, eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(catchMe == false)
        {
            return;
        }

        //print(itemInfo.name + " Drag");
        ItemSlotDrag.Instance.DragMove(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(catchMe == false)
        {
            return;
        }

        //print(itemInfo.name + " Drop");
        ItemSlotDrag.Instance.Drop();

        catchMe = false;
    }

    public void SlotOn()
    {
        slotImage.color = new Color(0, 1, 0, alpha);
    }

    public void SlotOff()
    {
        slotImage.color = new Color(1, 1, 1, alpha);
    }
}
