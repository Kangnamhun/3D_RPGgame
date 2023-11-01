using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class UI_Button : UI_Popup
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
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameOBJ));
        Bind<Image>(typeof(Images));



        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClick);
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }


    int score = 0;
    public void OnButtonClick(PointerEventData data)
    {
        score++;
        GetText((int)Texts.ScoreText).text = $"Á¡¼ö : {score}";
    }
}
