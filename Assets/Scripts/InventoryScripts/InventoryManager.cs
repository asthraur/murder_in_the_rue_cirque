using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public static List<Item> items = new List<Item>();

    public Transform itemContent; //grid layout of inventory
    public GameObject inventoryItem; //prefab for items in inventory

    public int itemPosition = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void ListItems()
    {
        foreach(Transform obj in itemContent)
        {
            Destroy(obj.gameObject);
        }

        foreach (Item item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            obj.transform.SetSiblingIndex(itemPosition);

            TMP_Text itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            
            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
            itemIcon.preserveAspect = true;
            itemIcon.color = new Color(255, 255, 255, 255);
            itemPosition += 1;
        }
    }
}
