using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using TMPro;


public class ItemInformationScript : MonoBehaviour
{
    public List<Item> items;
    private Item item;

    private TMP_Text information;
    private TMP_Text itemName;
    private Image itemPic;
    private Button button;
    private TMP_Text selectedItemName;


    public void OnItemClick()
    {
        information = GameObject.FindGameObjectWithTag("Information").GetComponent<TMP_Text>();
        information.text = "";
        
        itemName = GameObject.FindGameObjectWithTag("ItemName").GetComponent<TMP_Text>();
        itemName.text = "";

        itemPic = GameObject.FindGameObjectWithTag("ItemPic").GetComponent<Image>();
        itemPic.sprite = null;

        button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        selectedItemName = button.transform.Find("ItemName").GetComponent<TMP_Text>();

        item = InventoryManager.items.Find(listItem => listItem.itemName == selectedItemName.text);
        Debug.Log(item);

        if (item)
        {
            information.text = item.infoText;
            itemName.text = item.itemName;
            itemPic.sprite = item.itemIcon;
        }
        else
        {
            information.text = "???";
        }
    }
}
