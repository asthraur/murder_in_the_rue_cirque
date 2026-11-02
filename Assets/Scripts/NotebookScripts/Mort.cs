using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class Mort : MonoBehaviour
{
    public string text = "name: Mort \n";

    private Dictionary<string, List<string>> mort_information;

    private void Start()
    {
        mort_information = new Dictionary<string, List<string>>();

        mort_information["Mo_Start_Day1"] = new List<string>{
            "- occupation: magician \n",
            "- plagued by night terrors caused by.. her hat?\n",
            "- claims to perform wield magic, but denies being a witch \n"};

        mort_information["Mo_Start_Day2"] = new List<string>{
            "- plays cards in an unusual fashion \n",
            "- is friends with Teddy? or finds him amusing atleast \n",
            "- on bad terms with the deceased due to noise complaints \n"};

        mort_information["Mo_Start_Day3"] = new List<string>{
            "- had multiple belongings of hers turn up at the crime scene \n"};

    }

    public void MortUpdateInformation(string startNode)
    {
        mort_information[startNode].ForEach(bulletpoint =>
        {
            text += bulletpoint;
        });
    }
}
