using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON; //SimpleJSON cs만들고 써야한다. 
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

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
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .EnableSavedGames()
        .RequestEmail()

        .RequestServerAuthCode(false)
        .RequestIdToken()
        .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
       


        //var N = JSON.Parse(jsondate.text);

        //for (int i = 0; i < N.Count; i++)

        //{

        //    Debug.Log(N[i]["Unit"]);

        //}

    }

  void Start()
  {
        Debug.Log("Login btn Press!!");
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                print("Fial");

            }
            else
            {
                print("Fial");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
  
}
