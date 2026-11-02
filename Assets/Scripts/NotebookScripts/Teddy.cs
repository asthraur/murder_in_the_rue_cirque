using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class Teddy :MonoBehaviour
{
    public string text = "name: Teddy \n";

    private Dictionary<string, List<string>> teddy_information;

    private void Start()
    {
        teddy_information = new Dictionary<string, List<string>>();

        teddy_information["Te_Start_Day1"] = new List<string>{
            "- occupation: harlekin clown \n",
            "- forms a duo with Mr. Eduard, claims to be his best friend and shares a wagon with him \n",
            "- has a sweet tooth \n",
            "- was conned into costume mending duties by Mr. Waddles \n",
            "- was juggling next to Mr. Eduard during the time of the murder \n"};

        teddy_information["Te_Start_Day2"] = new List<string>{
            "- doesn't have fingers \n",
            "- has the sniffles \n"};

        teddy_information["Te_Start_Day3"] = new List<string>{
            "- overheard an argument between the acrobats \n",
            "blub \n"};
    }
    
    public void TeddyUpdateInformation(string startNode)
    {
        teddy_information[startNode].ForEach(bulletpoint =>
        {
            text += bulletpoint;
        });
    }
}
