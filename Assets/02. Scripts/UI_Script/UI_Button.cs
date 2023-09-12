using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_Button : UI_Base
{
    

    enum Buttons
    {
        PointButton
    } 
    enum Texts
    {
        PointText,
        ScoreText
    }

    enum GameOBJ
    {
        TestOBJ
    }
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameOBJ));
        GetText((int)Texts.ScoreText).text = "Bind Test";
    }
    

    int score = 0;
    public void OnButtonClick()
    {
        Debug.Log("dddd");
        score++;
    }
}
