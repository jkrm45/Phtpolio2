using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManergerScripts : MonoBehaviour {

    private static AudioManergerScripts _instance = null;
    public static AudioManergerScripts Instance { get { return _instance; } }

    public AudioClip Main;
    public AudioClip Stage;
    public AudioSource Audio;
    public AudioSource Bullet;
    public AudioSource Explore;

    //public GameObject MainLisener;
    public bool Playing = true;
    // Use this for initialization
    void Awake() {

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();
      

    }
    // Update is called once per frame
    void Update () {
        //MainLisener = GameObject.Find("Main Camera");
        if (Playing == false)
        {
            //MainLisener.GetComponent<AudioListener>().enabled = false;
            Bullet.mute = true;
            Explore.mute = true;
            Audio.Pause();
           
        }
        if (Playing == true)
        {
            Bullet.mute = false;
            Explore.mute = false;
            //MainLisener.GetComponent<AudioListener>().enabled = true;
            Audio.UnPause();

        }

       
        if (GameManeger.Instance.i == 1)
        {
            Audio.clip = Main;
          
        }
        if (GameManeger.Instance.i >= 2)
        {
            Audio.clip = Stage;
        
        }
        
      
    }
}
