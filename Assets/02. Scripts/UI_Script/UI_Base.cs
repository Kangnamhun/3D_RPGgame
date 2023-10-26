using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _object = new Dictionary<Type, UnityEngine.Object[]>();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] obj = new UnityEngine.Object[names.Length];
        _object.Add(typeof(T), obj);


        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                obj[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                obj[i] = Util.FindChild<T>(gameObject, names[i], true);
            }
            if (obj[i] == null)
            {
                Debug.Log($"¸øÃ£À½ {names[i]}");
            }
        }
    }

    T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] obj = null;
        if (_object.TryGetValue(typeof(T), out obj) == false)
        {
            return null;
        }
        return obj[idx] as T;
    }


    protected TextMeshProUGUI GetText(int idx)
    {
        return Get<TextMeshProUGUI>(idx);
    }

    protected Button GetButton(int idx)
    {
        return Get<Button>(idx);
    }

    protected Image GetImage(int idx)
    {
        return Get<Image>(idx);
    }

    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Evnet _evnet = Util.GetOrAddComponent<UI_Evnet>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                _evnet.OnClickHandler -= action;
                _evnet.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                _evnet.OnDragHandler -= action;
                _evnet.OnDragHandler += action;
                break;

        }
        _evnet.OnDragHandler += ((PointerEventData data) => { _evnet.gameObject.transform.position = data.position; });
    }
}
