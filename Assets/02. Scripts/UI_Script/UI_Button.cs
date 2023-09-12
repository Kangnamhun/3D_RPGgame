using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

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
    enum Images
    {
        ItemIcon
    }
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameOBJ));
        Bind<Image>(typeof(Images));
        GetText((int)Texts.ScoreText).text = "Bind Test";

        GameObject go =  GetImage((int)Images.ItemIcon).gameObject;
        UI_Evnet _evnet = go.GetComponent<UI_Evnet>();
        _evnet.OnDragHandler += ((PointerEventData data) => { _evnet.gameObject.transform.position = data.position; });
    }
    

    int score = 0;
    public void OnButtonClick()
    {
        Debug.Log("dddd");
        score++;
    }
}
