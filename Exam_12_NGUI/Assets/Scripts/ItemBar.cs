using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBar : MonoBehaviour
{
    private UILabel nameLabel;
    private UISprite itemImage;
    private ItemInfo itemInfo;
    private ItemList parentItemList;


	void Awake ()
    {
        Transform nameLabelTrans = this.transform.FindChild("ItemName");

        if(nameLabelTrans != null)
        {
            nameLabel = nameLabelTrans.gameObject.GetComponent<UILabel>();
        }

        Transform itemImageTrans = this.transform.FindChild("ItemImage");

        if(itemImageTrans != null)
        {
            itemImage = itemImageTrans.gameObject.GetComponent<UISprite>();
        }
	}

    private void Start()
    {
        parentItemList = this.GetComponentInParent<ItemList>();
    }

    public void SetItemInfo(ItemInfo newInfo)
    {
        itemInfo = newInfo;

        if (nameLabel != null)
        {
            nameLabel.text = itemInfo.strName;
        }

        if(itemImage != null)
        {
            //세팅될 아이콘의 스프라이트 이름을 가져온다.
            string itemSpriteName = ItemInfo.iconName[itemInfo.nImageIndex];

            //같은 아틀라스를 사용한다는 가정하에 이름만 세팅해주면 Sprite 이미지가 바뀐다.
            itemImage.spriteName = itemSpriteName;
        }
    }

    public ItemInfo GetItemInfo()
    {
        return itemInfo;
    }

    public void Delete()
    {
        //나의 부모에게 나를 죽여달라고 부탁한다.
        parentItemList.DeleteItemBar(this);
    }
}
