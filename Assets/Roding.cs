using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roding : MonoBehaviour {
    public float time;
    public float Aplv1time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time =time+ Time.deltaTime;
        if (time > Aplv1time)
        {
            GameManeger.Instance.i = GameManeger.Instance.i + 1;
            Application.LoadLevel(GameManeger.Instance.i);
        }
	}
}
