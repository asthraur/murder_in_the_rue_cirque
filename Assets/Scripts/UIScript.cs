using System;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class UIScript : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    public GameObject spriteBear;
    public GameObject spriteElephant;
    public GameObject spriteHare;
    public GameObject spriteCapuchin;
    public GameObject spriteLangur;
    public GameObject spriteLion;

    public GameObject spritePoppetMask;

    public GameObject frontInteriorScene;
    public GameObject leftInteriorScene;
    public GameObject backInteriorScene;
    public GameObject rightInteriorScene;

    public GameObject exteriorScene;
    public GameObject interiorScene;
    public GameObject blackOutScene;
    public GameObject gameWonScene;
    public GameObject gameLostScene;

    private Button buttonBear;
    private Button buttonElephant;
    private Button buttonHare;
    private Button buttonCapuchin;
    private Button buttonLangur;
    private Button buttonLion;

    private Button buttonNextDay;
    //public GameObject nextDay;
    public int currentDay = 1;

    private Button buttonLeft;
    private Button buttonRight;

    private Button buttonSuitcase;
    private Button buttonNotebook;

    private GameObject door;

    private AudioManager audioManager;

    public Teddy teddyInformation;
    public Eduard eduardInformation;
    public Mort mortInformation;
    public Widget widgetInformation;
    public Poppet poppetInformation;
    public Napoleon napoleonInformation;

    private InMemoryVariableStorage variableStorage;
    private bool verdictTrue = false;

    private string activeStartNode;
    private Button[] characterSelection;

    string activeCharacter;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        variableStorage = UnityEngine.Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();

        blackOutScene.SetActive(true);
        Invoke("Blackout", 3);

        buttonNextDay.transform.localScale = new Vector3(0, 0, 0);
        buttonNextDay.interactable = false;

        door = GameObject.Find("Door");

        

        dialogueRunner = UnityEngine.Object.FindFirstObjectByType<DialogueRunner>();

        GameObject[] characterSprites = { spriteBear, spriteElephant, spriteHare, spriteCapuchin, spriteHare, spriteLangur, spriteLion, spritePoppetMask };

        foreach(GameObject sprite in characterSprites)
        {
            sprite.SetActive(false);

        }

        OnButtonClick(buttonLion, "IntroStart", spriteLion, "Napoleon");
    }


    public void OnEnable()
    {

        buttonBear = GameObject.Find("ButtonBear").GetComponent<Button>();
        buttonElephant = GameObject.Find("ButtonElephant").GetComponent<Button>();
        buttonHare = GameObject.Find("ButtonHare").GetComponent<Button>();
        buttonCapuchin = GameObject.Find("ButtonCapuchin").GetComponent<Button>();
        buttonLangur = GameObject.Find("ButtonLangur").GetComponent<Button>();
        buttonLion = GameObject.Find("ButtonLion").GetComponent<Button>();

        buttonNextDay = GameObject.Find("ButtonNextDay").GetComponent<Button>();

        buttonLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        buttonRight = GameObject.Find("ButtonRight").GetComponent<Button>();

        buttonSuitcase = GameObject.Find("ButtonSuitcase").GetComponent<Button>();
        buttonNotebook = GameObject.Find("ButtonNotebook").GetComponent<Button>();


        buttonBear.onClick.AddListener(() => { OnButtonClick(buttonBear, "Te_Start_Day" + currentDay, spriteBear, "Teddy"); });

        buttonElephant.onClick.AddListener(() => { OnButtonClick(buttonElephant, "Ed_Start_Day" + currentDay, spriteElephant, "Eduard"); });

        buttonHare.onClick.AddListener(() => { OnButtonClick(buttonHare, "Mo_Start_Day" + currentDay, spriteHare, "Mort"); });

        buttonCapuchin.onClick.AddListener(() => { OnButtonClick(buttonCapuchin, "Po_Start_Day" + currentDay, spriteCapuchin, "Poppet"); });

        buttonLangur.onClick.AddListener(() => { OnButtonClick(buttonLangur, "Wi_Start_Day" + currentDay, spriteLangur, "Widget"); });

        buttonLion.onClick.AddListener(() => { OnButtonClick(buttonLion, "Na_Start_Day" + currentDay, spriteLion, "Napoleon");});


        buttonLeft.onClick.AddListener(() =>
        {
            audioManager.PlaySFX(audioManager.wall);


            if (frontInteriorScene.activeSelf == true)
            {
                frontInteriorScene.SetActive(false);
                leftInteriorScene.SetActive(true);
            }

            else if (leftInteriorScene.activeSelf == true)
            {
                leftInteriorScene.SetActive(false);
                backInteriorScene.SetActive(true);
            }

            else if (backInteriorScene.activeSelf == true)
            {
                backInteriorScene.SetActive(false);
                rightInteriorScene.SetActive(true);
            }

            else if (rightInteriorScene.activeSelf == true)
            {
                rightInteriorScene.SetActive(false);
                frontInteriorScene.SetActive(true);
            }
        });

        buttonRight.onClick.AddListener(() =>
        {
            audioManager.PlaySFX(audioManager.wall);

            if (frontInteriorScene.activeSelf == true)
            {
                frontInteriorScene.SetActive(false);
                rightInteriorScene.SetActive(true);
            }

            else if (rightInteriorScene.activeSelf == true)
            {
                rightInteriorScene.SetActive(false);
                backInteriorScene.SetActive(true);
            }

            else if (backInteriorScene.activeSelf == true)
            {
                backInteriorScene.SetActive(false);
                leftInteriorScene.SetActive(true);
            }

            else if (leftInteriorScene.activeSelf == true)
            {
                leftInteriorScene.SetActive(false);
                frontInteriorScene.SetActive(true);
            }
        });

        buttonNextDay.onClick.AddListener(() =>
        {
            blackOutScene.SetActive(true);
            buttonElephant.interactable = false;
            buttonHare.interactable = false;
            buttonLangur.interactable = false;
            buttonCapuchin.interactable = false;
            buttonLion.interactable = false;
            Invoke("Blackout", 3);
            currentDay += 1;
            buttonNextDay.transform.localScale = new Vector3(0, 0, 0);
            buttonNextDay.interactable = false;


            Button[] characterSelectionButtons = { buttonBear, buttonElephant, buttonHare, buttonCapuchin, buttonLangur, buttonLion };
            unhideButton(characterSelectionButtons);
        });
    } 
    
    private void Blackout()
    {
        blackOutScene.SetActive(false);
    }

    private void GameWon()
    {
        audioManager.StopMusic();
        audioManager.PlaySFX(audioManager.newspaper);

        exteriorScene.SetActive(false);
        gameObject.SetActive(false);

        gameWonScene.SetActive(true);
    }

    private void GameLost()
    {
        audioManager.StopMusic();
        audioManager.PlaySFX(audioManager.newspaper);

        exteriorScene.SetActive(false);
        gameObject.SetActive(false);

        gameLostScene.SetActive(true);
    }

    private void Update()
    {
        Button[] characterSelectionButtons = { buttonBear, buttonElephant, buttonHare, buttonCapuchin, buttonLangur, buttonLion };
        Button[] wallSwitchButtons = { buttonLeft, buttonRight };


        if (interiorScene.activeSelf == false && buttonNextDay.interactable == false)
        {
            unhideButton(characterSelectionButtons);
            hideButton(wallSwitchButtons);
        }
        else if(interiorScene.activeSelf == true && buttonNextDay.interactable == false)
        {
            unhideButton(wallSwitchButtons);
            hideButton(characterSelectionButtons);
        } else if(interiorScene.activeSelf == false)
        {
            hideButton(wallSwitchButtons);

        } else if (interiorScene.activeSelf)
        {
            unhideButton(wallSwitchButtons);

        }


    }

    private void hideButton(Button[] buttons)
    {
        foreach(Button button in buttons)
        {
            button.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    private void unhideButton(Button[] buttons)
    {
        foreach (Button button in buttons)
        {
            button.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnDialoagueComplete()
    {
        Button[] characterSelectionButtons = { buttonBear, buttonElephant, buttonHare, buttonCapuchin, buttonLangur, buttonLion };

        Debug.Log(activeStartNode);
        if(activeCharacter == "Teddy")
        {
            buttonElephant.interactable = true;
        } else if (activeCharacter == "Eduard")
        {
            buttonHare.interactable = true;
        } else if (activeCharacter == "Mort")
        {
            buttonLangur.interactable = true;
        } else if (activeCharacter == "Widget")
        {
            buttonCapuchin.interactable = true;
        } else if (activeCharacter == "Poppet")
        {
            buttonLion.interactable = true;
            spritePoppetMask.SetActive(false);
        } else if(activeCharacter == "Napoleon" && activeStartNode != "IntroStart")
        {
            buttonNextDay.transform.localScale = new Vector3(1, 1, 1);
            buttonNextDay.interactable = true;

            hideButton(characterSelectionButtons);

        }

        if(activeCharacter != "Napoleon")
        {
            unhideButton(characterSelectionButtons);

        }



        buttonSuitcase.interactable = true;
        buttonNotebook.interactable = true;

        door.GetComponent<PolygonCollider2D>().enabled = true;
        GameObject character = GameObject.FindWithTag("Character");
        Debug.Log(character);
        if (character)
        {
            character.SetActive(false);
        }

    }

    private void OnGameComplete()
    {
        
        variableStorage.TryGetValue("$verdict_true", out verdictTrue);

        if (verdictTrue)
        {
            Invoke("GameWon", 5);
        }
        else
        {
            Invoke("GameLost", 5);
        }
    }

    private void OnButtonClick(Button button, string startNode, GameObject CharacterSprite, string characterName)
    {
        activeCharacter = characterName;
        activeStartNode = startNode;
        button.interactable = false;

        Button[] characterSelectionButtons = { buttonBear, buttonElephant, buttonHare, buttonCapuchin, buttonLangur, buttonLion };
        hideButton(characterSelectionButtons);

        buttonSuitcase.interactable = false;
        buttonNotebook.interactable = false;

        Debug.Log(startNode);
        door.GetComponent<PolygonCollider2D>().enabled = false;
        Debug.Log(dialogueRunner);
        dialogueRunner.StartDialogue(startNode);
        if(startNode == "Po_Start_Day2")
        {
            spritePoppetMask.SetActive(true);
        }
        else
        {
            CharacterSprite.SetActive(true);
        }

        if (characterName =="Teddy"){
            teddyInformation.TeddyUpdateInformation(startNode);
        } else if(characterName == "Eduard"){
            eduardInformation.EduardUpdateInformation(startNode);
        } else if (characterName == "Mort"){
            mortInformation.MortUpdateInformation(startNode);
        } else if (characterName == "Widget"){
            widgetInformation.WidgetUpdateInformation(startNode);
        } else if (characterName == "Poppet"){
            poppetInformation.PoppetUpdateInformation(startNode);
        } else if (characterName == "Napoleon"){
            napoleonInformation.NapoleonUpdateInformation(startNode);
        }

        if(startNode == "Na_Start_Day3")
        {
            dialogueRunner.onDialogueComplete.AddListener(OnGameComplete);
        }
        else
        {
            dialogueRunner.onDialogueComplete.AddListener(OnDialoagueComplete);

        }
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }
}

    

