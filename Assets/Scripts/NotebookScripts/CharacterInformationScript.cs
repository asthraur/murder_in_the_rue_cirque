using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class CharacterInfoScript : MonoBehaviour
{
    public Sprite spriteTeddy;
    public Sprite spriteEduard;
    public Sprite spriteMort;
    public Sprite spriteWidget;
    public Sprite spritePoppet;
    public Sprite spriteNapoleon;

    private TMP_Text information;
    private Image drawing;
    private Button button;
    private TMP_Text selectedCharacterName;

    private AudioManager audioManager;

    public Teddy teddyInformation;
    public Eduard eduardInformation;
    public Mort mortInformation;
    public Widget widgetInformation;
    public Poppet poppetInformation;
    public Napoleon napoleonInformation;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnTabClick()
    {
        audioManager.PlaySFX(audioManager.paper);

        information = GameObject.FindGameObjectWithTag("Information").GetComponent<TMP_Text>();
        information.text = "";

        drawing = GameObject.FindGameObjectWithTag("Drawing").GetComponent<Image>();
        drawing.sprite = null;
        drawing.preserveAspect = true;
        drawing.color = new Color(1, 1, 1, 0);


        button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        selectedCharacterName = button.transform.Find("CharacterName").GetComponent<TMP_Text>();


        if (selectedCharacterName.text == "Teddy")
        {
            information.text = teddyInformation.text;
            drawing.sprite = spriteTeddy;
            drawing.color = new Color(1, 1, 1, 1);
            
        }
        else if(selectedCharacterName.text == "Eduard")
        {
            information.text = eduardInformation.text;
            drawing.sprite = spriteEduard;
            drawing.color = new Color(1, 1, 1, 1);
        }
        else if(selectedCharacterName.text == "Mort")
        {
            information.text = mortInformation.text;
            drawing.sprite = spriteMort;
            drawing.color = new Color(1, 1, 1, 1);
        }
        else if (selectedCharacterName.text == "Poppet")
        {
            information.text = poppetInformation.text;
            drawing.sprite = spritePoppet;
            drawing.color = new Color(1, 1, 1, 1);
        }
        else if(selectedCharacterName.text == "Widget")
        {
            information.text = widgetInformation.text;
            drawing.sprite = spriteWidget;
            drawing.color = new Color(1, 1, 1, 1);
        }
        else if(selectedCharacterName.text == "Napoleon")
        {
            information.text = napoleonInformation.text;
            drawing.sprite = spriteNapoleon;
            drawing.color = new Color(1, 1, 1, 1);
        }

    }
}
