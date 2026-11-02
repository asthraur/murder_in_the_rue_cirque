using System;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;


public class ItemPickup : MonoBehaviour
{
    
    public Item item;
    public Material defaultMaterial;
    public Material outlineMaterial;

    private bool itemCollected;
    private InMemoryVariableStorage variableStorage;

    private int moveStep = 1;

    private Color startColor;

    private AudioManager audioManager;

    private int day;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnMouseEnter()
    {
        day = GameObject.Find("UI").GetComponent<UIScript>().currentDay;
        if (item.day == day)
        {
            GetComponent<SpriteRenderer>().material = outlineMaterial;
        }
    }

    private void OnMouseExit()
    {
        if (item.day == day)
        {
            GetComponent<SpriteRenderer>().material = defaultMaterial;
        }
    }

    private void OnMouseDown()
    {
        if (item.day == day)
        {
            CollectItem();
        }
    }


    void Start()
    {
        variableStorage = UnityEngine.Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveStep = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveStep = 1;

    }
    public void CollectItem()
    {
        Debug.Log(item.itemName);

        //menu.gameObject.SetActive(false);

        string variable = item.variableName;
        InventoryManager.instance.AddItem(item);
        variableStorage.TryGetValue($"${variable}", out itemCollected);
        itemCollected = true;
        variableStorage.SetValue($"${variable}", itemCollected);
        
        item.infoText = "";
        item.infoText = item.info1;

        audioManager.PlaySFX(audioManager.grab);
        Destroy(gameObject);
    }

    public void MoveLeft()
    {
        
            transform.position = new Vector3(transform.position.x - moveStep, transform.position.y, transform.position.z);

        
    }

    public void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + moveStep, transform.position.y, transform.position.z);
    }
}
