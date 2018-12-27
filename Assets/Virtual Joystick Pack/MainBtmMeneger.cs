using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class MainBtmMeneger : MonoBehaviour {

    public GameObject Ban;
    public GameObject Chairchose;
    public GameObject play;
    public GameObject Soundpannel;
    public GameObject Chair;

    public GameObject Check1;
    public GameObject Check2;
    public GameObject Check3;
    public GameObject Check4;
    public GameObject rank;
    public GameObject Exit;


    //public const string leaderboard_1 = "CgkIgJDBp5IdEAIQAQ";

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
  
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        AudioManergerScripts.Instance.Audio.Play();


    }
	
	// Update is called once per frame
	void Update () {
       
     
    }
    

    public void toplay()
    {
        GameManeger.Instance.i = GameManeger.Instance.i + 1;
        Application.LoadLevel(GameManeger.Instance.i);
    }

    public void toQuit()
    {
        Application.Quit();
    }

    public void Sound()
    {
        AudioManergerScripts.Instance.Playing = false;
        Ban.SetActive(true);
    }
    public void UnSound()
    {
        AudioManergerScripts.Instance.Playing = true;
        Ban.SetActive(false);
    }

    public void onchose()
    {
     
        Chairchose.SetActive(true);
        play.GetComponent<BoxCollider>().enabled = false;
        rank.GetComponent<BoxCollider>().enabled = false;
        Ban.GetComponent<BoxCollider>().enabled = false;
       Exit.GetComponent<BoxCollider>().enabled = false;
       Soundpannel.GetComponent<BoxCollider>().enabled = false;
        Chair.GetComponent<BoxCollider>().enabled = false;

    }
    public void offchose()
    {
        play.GetComponent<BoxCollider>().enabled = true;
        rank.GetComponent<BoxCollider>().enabled = true;
        Ban.GetComponent<BoxCollider>().enabled = true;
        Exit.GetComponent<BoxCollider>().enabled = true;
        Soundpannel.GetComponent<BoxCollider>().enabled = true;
        Chair.GetComponent<BoxCollider>().enabled = true;
        Chairchose.SetActive(false);
    }
  
    public void Chirck1()
    {
        GameManeger.Instance.Player = 1;
        Check1.GetComponent<UILabel>().text = "Selected";
        Check2.GetComponent<UILabel>().text = "UnSelected";
        Check3.GetComponent<UILabel>().text = "UnSelected";
        Check4.GetComponent<UILabel>().text = "UnSelected";
    }
    public void Chirck2()
    {
        GameManeger.Instance.Player = 2;
        Check1.GetComponent<UILabel>().text = "UnSelected";
        Check2.GetComponent<UILabel>().text = "Selected";
        Check3.GetComponent<UILabel>().text = "UnSelected";
        Check4.GetComponent<UILabel>().text = "UnSelected";
    }
    public void Chirck3()
    {
        GameManeger.Instance.Player = 3;
        Check1.GetComponent<UILabel>().text = "UnSelected";
        Check2.GetComponent<UILabel>().text = "UnSelected";
        Check3.GetComponent<UILabel>().text = "Selected";
        Check4.GetComponent<UILabel>().text = "UnSelected";
    }
    public void Chirck4()
    {
        GameManeger.Instance.Player =4;
        Check1.GetComponent<UILabel>().text = "UnSelected";
        Check2.GetComponent<UILabel>().text = "UnSelected";
        Check3.GetComponent<UILabel>().text = "UnSelected";
        Check4.GetComponent<UILabel>().text = "Selected";
    }
    public void Btnsinin()
    {

        //Social.localUser.Authenticate(success => { });
        Social.localUser.Authenticate(success =>
        {
            if (true == success)
            {

                SenScore();
                ShowUI();

            }
            else
            {

            }

        });

    }
    #region
    public void SenScore()
    {
        Social.ReportScore(PlayerPrefs.GetInt("BESTSCROE"), GPGSIds.leaderboard_1, success => { });
       
   
         
    }

    public void ShowUI()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion

    public void Mute()
    {

    }
}
