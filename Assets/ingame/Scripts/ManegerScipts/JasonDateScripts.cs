using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON; //SimpleJSON cs만들고 써야한다. 
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


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

  void Start()
  {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .EnableSavedGames()
        .RequestEmail()

        .RequestServerAuthCode(false)
        .RequestIdToken()
        .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        Btnsinin();

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Btnsinin()
    {
     
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
             
                GameManeger.Instance.i = GameManeger.Instance.i + 1;
                Application.LoadLevel(GameManeger.Instance.i);
            }
            else
            {

            }
        });
    }
    
  
}
