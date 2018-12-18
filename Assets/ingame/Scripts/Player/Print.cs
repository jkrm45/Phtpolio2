using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Print : MonoBehaviour {
    public int Speed;
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        printmove();
    }
    void printmove()
    {
        var N = JSON.Parse(JasonDateScripts.Instance.Data1.text);
        Speed = (int)N[2]["Speed"];
        transform.Translate(Speed * Time.deltaTime, 0, 0);
        
    }
}
