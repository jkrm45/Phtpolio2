using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class BossMeneger : MonoBehaviour {
    private static BossMeneger _instance = null;
    public static BossMeneger Instance { get { return _instance; } }
    public int Stage;
    public int Speed;
    public int Hp;
    public float Cooltime;
    public float SpecialAttackCooltime;
    public List<int> aaa;
    // Use this for initialization
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);


    }
    void Start()
    {
        aaa = new List<int>();
        var T = JSON.Parse(JasonDateScripts.Instance.Data3.text);
        for (int i = 0; i < T.Count; i++)
        {
            aaa.Add(T[i]["Stage"]);
        }

    }

    void Update()
    {
        getdata();
       
    }
    void getdata()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Stage == aaa[i])
            {
                var N = JSON.Parse(JasonDateScripts.Instance.Data3.text);
                Speed = (int)N[i]["Speed"];
                Hp = (int)N[i]["HP"];
                Cooltime = (float)N[i]["Cooltime"];
                SpecialAttackCooltime = (float)N[i]["SpecialAttackCooltime"];
             

            }
            
        }
    }
   

}

