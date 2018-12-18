using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON; //SimpleJSON cs만들고 써야한다. 

public class JasonDateScripts : MonoBehaviour
{
    private static JasonDateScripts _instance = null;
    public static JasonDateScripts Instance { get { return _instance; } }
    public TextAsset Data1;
    public TextAsset Data2;
    public TextAsset Data3;

 
    // Use this for initialization
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);

        //var N = JSON.Parse(jsondate.text);

        //for (int i = 0; i < N.Count; i++)

        //{

        //    Debug.Log(N[i]["Unit"]);

        //}

    }

    // Update is called once per frame
    void Update()
    {

    }
    
  
}
