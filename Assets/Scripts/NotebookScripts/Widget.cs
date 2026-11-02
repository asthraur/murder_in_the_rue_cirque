using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class Widget : MonoBehaviour
{
    public string text = "Name: Widget \n";

    private Dictionary<string, List<string>> widget_information;

    private void Start()
    {
        widget_information = new Dictionary<string, List<string>>();

        widget_information["Wi_Start_Day1"] = new List<string>{
            "Occupation: Acrobat \n",
            "- loves his job \n",
            "- great hair? \n",
            "- friends with lady poppet \n",
            "- long time member of the circus\n"};

        widget_information["Wi_Start_Day2"] = new List<string>{
            "- claims to have entered the crime during a trumpet heist with her fellow acrobat \n",
            "- had a mini break down after his confession \n",
            "- the victim seemed to be rather mean to him \n"};

        widget_information["Wi_Start_Day3"] = new List<string>{
            "- had spotted eduard rehearsing for the two man show \n",
            "- claims the wagon was uncannily quite \n"};

    }

    public void WidgetUpdateInformation(string startNode)
    {
        widget_information[startNode].ForEach(bulletpoint =>
        {
            text += bulletpoint;
        });
    }
}
