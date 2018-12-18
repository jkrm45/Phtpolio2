using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManergerScripts : MonoBehaviour {

    private static AudioManergerScripts _instance = null;
    public static AudioManergerScripts Instance { get { return _instance; } }
    // Use this for initialization
    void Awake() {

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
