using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class Eduard : MonoBehaviour
{
    public string text = "Name: Eduard \n";

    private Dictionary<string, List<string>> eduard_information;

    private void Start()
    {
        eduard_information = new Dictionary<string, List<string>>();

        eduard_information["Ed_Start_Day1"] = new List<string>{
            "- occupation: pierrot clown \n",
            "- does not like his job, wants to be an actor \n",
            "- seem to had known the victim well. insists they were not friends \n",
            "- had borrowed the victim a book \n",
            "- seems oblivious to his little partner. is that an act? \n"};

        eduard_information["Ed_Start_Day2"] = new List<string>{
            "- insists the fingerprints on the mirror are not his \n",
            "- but is not accusing anyone else \n",
            "- appears to be moved by the aftermath \n"};

        eduard_information["Ed_Start_Day3"] = new List<string>{
            "- insists the clown nose is unrelated to the case \n",
            "- claims the victim had stolen his watch \n"};
    }

    public void EduardUpdateInformation(string startNode)
    {
        eduard_information[startNode].ForEach(bulletpoint =>
        {
            text += bulletpoint;
        });
    }
}
