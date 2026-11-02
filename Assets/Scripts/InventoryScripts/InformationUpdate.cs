using UnityEngine;
using Yarn.Unity;

public class InformationUpdate : MonoBehaviour
{
    public Item letter;
    private bool letter_info = false;
    private InMemoryVariableStorage variableStorage;
    

    void Start()
    {
        variableStorage = Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();
    }

    void Update()
    {
            //variableStorage.TryGetValue("$letter_info", out letter_info);

            if (letter_info && !letter.infoText.Contains(letter.info2))
            {
                Debug.Log("hello");

                letter.infoText = letter.infoText + "\n" + letter.info2;
                letter_info = false;
                variableStorage.SetValue("$letter_info", letter_info);
        }
       
    }
}
