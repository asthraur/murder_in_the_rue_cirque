using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class Poppet : MonoBehaviour
{
    public string text = "name: Poppet \n";

    private Dictionary<string, List<string>> poppet_information;

    private void Start()
    {
        poppet_information = new Dictionary<string, List<string>>();

        poppet_information["Po_Start_Day1"] = new List<string>{
            "- occupation: acrobat \n",
            "- heiress of house dunsmoore \n",
            "- forms a twin-monkey-acrobat-duo with Mr. Widget \n",
            "- claims the victim was a failed actor \n",
            "- alledges closeness of the victim to Eduard the clown \n"};

        poppet_information["Po_Start_Day2"] = new List<string>{
            "- supplies the members with her cooking and baking \n",
            "- claims to have entered the crime during a trumpet heist with her fellow acrobat"};

        poppet_information["Po_Start_Day3"] = new List<string>{
            "- repeatedly accused to magician of commiting the crime \n"};

    }

    public void PoppetUpdateInformation(string startNode)
    {
        poppet_information[startNode].ForEach(bulletpoint =>
        {
            text += bulletpoint;
        });
    }
}
