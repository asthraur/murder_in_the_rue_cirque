using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class Napoleon : MonoBehaviour
{
    public string text = "Name: Napoleon \n";

    private Dictionary<string, List<string>> napoleon_information;

    private void Start()
    {
        napoleon_information = new Dictionary<string, List<string>>();

        napoleon_information["IntroStart"] = new List<string>{
            "Occupation: circus manager \n",
            "- about the victim: caus of death is unknown\n",
            "- the wagon was locked"};

        napoleon_information["Na_Start_Day1"] = new List<string>{
            "- claims did not knew about the victims possible resignation \n",
            "- was allegedly ready to hire another trumpet pinguin, says it's his usual routine"};

        napoleon_information["Na_Start_Day2"] = new List<string>{
            "- is blackmailing the local press? \n",
            "- busy auditioning trumpet pinguins\n"};

        napoleon_information["Na_Start_Day3"] = new List<string>{
             "- It's time.\n"};

    }

    public void NapoleonUpdateInformation(string startNode)
    {
        napoleon_information[startNode].ForEach(bulletpoint =>
        {
            text += bulletpoint;
        });
    }
}
