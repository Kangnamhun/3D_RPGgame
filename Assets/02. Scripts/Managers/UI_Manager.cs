using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager
{
    int order = 10;

    Stack<UI_Popup> popupStack = new Stack<UI_Popup>();
    UI_Scene sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject ui = GameObject.Find("@UI");
            if (ui == null)
            {
                ui = new GameObject { name = "@UI" };
            }
            return ui;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas =  Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = order;
            order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = Managers.Resource.Instantiate($"UI_Scene/{name}");

        T scene_ui = Util.GetOrAddComponent<T>(go);
        sceneUI = scene_ui;

        go.transform.SetParent(Root.transform);
        return scene_ui;
    }

    

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go =  Managers.Resource.Instantiate($"UI_Popup/{name}");

        T popup_ui = Util.GetOrAddComponent<T>(go);
        popupStack.Push(popup_ui);

        GameObject ui = GameObject.Find("@UI");
        if(ui == null)
        {
            ui = new GameObject { name = "@UI" };
        }
        go.transform.SetParent(ui.transform);
        return popup_ui;
    } 



    public void ClosePopup(UI_Popup popup)
    {
        if (popupStack.Count == 0)
        {
            return;
        }
        if(popupStack.Peek() != popup)
        {
            Debug.Log("½ºÅÃ");
            return;
        }
        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if(popupStack.Count == 0)
        {
            return;
        }
        UI_Popup popup =  popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        order--;
    }

    public void CloseAllPopupUI()
    {
        while(popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }

}
