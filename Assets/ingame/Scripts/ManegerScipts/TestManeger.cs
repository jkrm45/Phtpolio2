﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManeger : MonoBehaviour {
    private static TestManeger _instance = null;
    public static TestManeger Instance { get { return _instance; } }
    
   
    // Use this for initialization
    void Start () {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (GameManeger.Instance.i <6)
            {
                GameManeger.Instance.i = GameManeger.Instance.i + 1;
            }
            else
            {
                GameManeger.Instance.i = 1;
            }
           
            Application.LoadLevel(GameManeger.Instance.i);
        }
	}
}
