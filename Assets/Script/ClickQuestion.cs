using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickQuestion : MonoBehaviour
{
    public Text nameQuestion;
    void Start()
    {
        nameQuestion.text = "";
    }

    public void setSonName()
    {
        if (nameQuestion.text == "")
            nameQuestion.text = "Son";
        else
            nameQuestion.text = "";
    }

    public void setFamilyName()
    {
        if (nameQuestion.text == "")
            nameQuestion.text = "Family";
        else
            nameQuestion.text = "";
    }
}
