using UnityEngine;
using Yarn.Unity;

public class SpriteSwitchScript : MonoBehaviour
{
    public GameObject sprite1;
    public GameObject sprite2;

    public Item item;
    public Material defaultMaterial;
    public Material outlineMaterial;

    private int day;

    private InMemoryVariableStorage variableStorage;

    private void Start()
    {
        variableStorage = UnityEngine.Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();
    }

    private void OnMouseEnter()
    {
        day = GameObject.Find("UI").GetComponent<UIScript>().currentDay;

        if (item.day == day)
        {
            var keyCollected = false;
            variableStorage.TryGetValue("$key", out keyCollected);

            if (this.gameObject.name == "trumpet case closed")
            {
                if (keyCollected == true)
                {
                    GetComponent<SpriteRenderer>().material = outlineMaterial;
                }
            }
            else
            {
                GetComponent<SpriteRenderer>().material = outlineMaterial;
            }
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
            var keyCollected = false;
            variableStorage.TryGetValue("$key", out keyCollected);

            if(this.gameObject.name == "trumpet case closed")
            {
                if( keyCollected == true)
                {
                    sprite1.SetActive(false);
                    sprite2.SetActive(true);
                } 
            }

            else{
                sprite1.SetActive(false);
                sprite2.SetActive(true);
            }
            
        }
    }
}
