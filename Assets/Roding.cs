using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roding : MonoBehaviour {
    public float lordtime;
    public float lordcool;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lordtime = lordtime + Time.deltaTime;
        if (lordtime > lordcool)
        {
            GameManeger.Instance.i = GameManeger.Instance.i + 1;
           
            Application.LoadLevel(GameManeger.Instance.i);
          
        }
	}
}
