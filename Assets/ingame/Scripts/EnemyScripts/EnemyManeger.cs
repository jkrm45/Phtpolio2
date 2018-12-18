using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EnemyManeger : MonoBehaviour {
    private static EnemyManeger _instance = null;
    public static EnemyManeger Instance { get { return _instance; } }
  
    // Use this for initialization
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
      
	}

}

