using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CreateInventory : MonoBehaviour
{
    // 슬롯 개수
    public int slotCntWidth = 4;
    public int slotCntHeight = 4;
    // 슬롯 사이즈
    public int slotWidthSize = 64;
    public int slotheightSize = 64;
    // 슬롯 프리팹
    public GameObject prefabSlot;
    public RectTransform parentObj;
    public Sprite backSprite;
    public int SlotTopBarSize = 20;
    GameObject inventory;
    public List <GameObject> slots = new List<GameObject> ();
    public GameObject prefabItem;
    List<Item1> initem = new List<Item1>();
    Item1 Exi = new Item1();


    private void Start()
    {
        SetInventory();
        inventory.SetActive(false);
    }

    public void AddItems()
    {
        Debug.Log("아이템 추가");
        initem.Add(Exi);
        SetItem(initem);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventory.activeSelf)
            {
                inventory.SetActive(false );
            } else
            {
                inventory.SetActive(true );
            }
        }

    }

    void SetInventory()
    {
        inventory = new GameObject ();
        Image image = inventory.AddComponent<Image> ();
        if(backSprite != null )
        {
            image.sprite = backSprite;
        }
        RectTransform inventoryRt = inventory.GetComponent<RectTransform> ();
        inventoryRt.SetParent (parentObj);
        inventoryRt.anchoredPosition = Vector3.zero;
        inventoryRt.sizeDelta = new Vector2(slotWidthSize * slotCntWidth, slotheightSize * slotCntHeight + SlotTopBarSize);
        inventoryRt.name = "Inventory";

        // 인벤토리를 움직일 헤더 생성
        GameObject backTop = new GameObject();  
        Image backToplmg = backTop.AddComponent<Image> ();
        backToplmg.color = Color.blue;
        RectTransform backTopRt = backTop.GetComponent<RectTransform> ();
        backTopRt.SetParent(inventoryRt);
        backTopRt.pivot = Vector2.up;
        backTopRt.anchorMin = Vector2.up;
        backTopRt.anchorMax = Vector2.up;
        backTopRt.anchoredPosition = Vector3.zero ;
        backTopRt.sizeDelta = new Vector2(slotWidthSize * slotCntWidth, SlotTopBarSize);
        backTop.AddComponent<DragObject>();

        for (int i = 0; i < slotCntHeight; i++)
        {
            for(int j = 0; j < slotCntWidth; j++)
            {
                GameObject slot = Instantiate(prefabSlot);
                RectTransform slotRT = slot.GetComponent<RectTransform> ();
                slotRT.SetParent(inventoryRt);
                slotRT.pivot = Vector2.up;
                slotRT.anchorMin = Vector2.up;
                slotRT.anchorMax = Vector2.up;
                slotRT.anchoredPosition= Vector3.zero ;
                slotRT.anchoredPosition += new Vector2(slotWidthSize * i, -(slotheightSize * j) - SlotTopBarSize);
                slotRT.sizeDelta = new Vector2(slotWidthSize, slotheightSize);
                slotRT.name = i + " , " + j;
                slots.Add(slot);
            }
        }
    }

    public void SetItem(List<Item1> item)
    {
        for(int i = 0;i < item.Count;i++)
        {
            GameObject it = Instantiate(prefabItem);
            RectTransform itRT = it.GetComponent<RectTransform> ();
            itRT.SetParent(slots[i].GetComponent<RectTransform>());
            itRT.pivot = new Vector2(0.5f, 0.5f);
            itRT.anchorMin = Vector2.zero;
            itRT.anchorMax = Vector2.one;
            itRT.offsetMax = new Vector2(-10, -10);
            itRT.offsetMin = new Vector2(10, 10);
            it.AddComponent<DragObject>().parentTr = it.transform;
        }
    }


}
