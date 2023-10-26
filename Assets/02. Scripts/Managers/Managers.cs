using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers ins; // 유일성이 보장된다
    static Managers Instance { get { Init(); return ins; } } // 유일한 매니저를 갖고온다

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UI_Manager ui = new UI_Manager();
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UI_Manager UI { get { return Instance.ui; } }

    // Start is called before the first frame update
    void Start()
    {
        Init();
	}

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (ins == null)
        {
			GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            ins = go.GetComponent<Managers>();
		}		
	}
}
