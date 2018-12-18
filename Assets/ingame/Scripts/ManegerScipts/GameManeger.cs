using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;


public class GameManeger : MonoBehaviour {
    private static GameManeger _instance = null;
    public static GameManeger Instance { get { return _instance; } }
    public int Score;
    public int BestScore;
    public int Player;
  
    public int Speed;
    public int Damege;
    public float Cooltime;
    public int SecondWeaponDamege;
    public float SecTime;
    public bool boolStageClear = false;
    public List<int>aaa;

    public GameObject player;
    public int i = 2;
    public GameObject Scroetext;
    public GameObject BestScroetext;
    public GameObject Life;
    public int Lifecount = 3;
    public GameObject chir1;
    public GameObject chir2;
    public GameObject chir3;
    public GameObject chir4;


    // Use this for initialization
    void Awake () {
        _instance = this;
        DontDestroyOnLoad(gameObject);
       
       

    }
    void Start()
    {
       
       
        aaa = new List<int>();
        var T = JSON.Parse(JasonDateScripts.Instance.Data1.text);
        for (int i = 0; i < T.Count; i++)
        {
            aaa.Add(T[i]["Player"]);
        }


        //PlayerPrefs.GetInt("Score");
        //Debug.Log(PlayerPrefs.GetInt("Score"));
    }

    // Update is called once per frame
    void Update () {
        Life.GetComponent<UILabel>().text = "X " + Lifecount.ToString();
        Scroetext.GetComponent<UILabel>().text = Score.ToString();
        BestScroetext.GetComponent<UILabel>().text = PlayerPrefs.GetInt("BESTSCROE").ToString();
        //BestScroetext.GetComponent<UILabel>().text = PlayerPrefs.GetInt("BESTSCROE").ToString();

        if (Score > BestScore)
            {
                BestScore = Score;
                PlayerPrefs.SetInt("BESTSCROE", BestScore);
            }
      
        //if (Score > BestScore)
        //{
        //    BestScore = Score;
        //    PlayerPrefs.SetInt("BESTSCROE", BestScore);
        //}
        //StageCear();
        getdata();
        if (Lifecount < 1 )
        {
            Lifecount = 0;
            player.transform.position = new Vector3(0, -7, 0);
            player.GetComponent<BoxCollider2D>().enabled = false;
            //player.SetActive(false);
        }
        else
        {
            //Time.timeScale = 0;
            player.GetComponent<BoxCollider2D>().enabled = true;
            player.SetActive(true);
            StageCear();
        }
      


        
        //Score++;
        //PlayerPrefs.SetInt("Score", Score);
    }
    void getdata()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Player == aaa[i])
            {
                var N = JSON.Parse(JasonDateScripts.Instance.Data1.text);
                //EnemyNo = (string)N[i]["EnemyNo"];
                Speed = (int)N[i]["Speed"];
                Cooltime = (float)N[i]["Cooltime"];            
                Damege = (int)N[i]["Damege"];
                SecondWeaponDamege = (int)N[i]["SecondWeaponDamege"];
                SecTime = (float)N[i]["SecTime"];
                
            }

        }
    }
    void StageCear()
    {
        if (boolStageClear==true)
        {
            player.transform.Translate(0, Speed * Time.deltaTime, 0, Space.World);
            player.GetComponent<BoxCollider2D>().enabled = false;
            
            if (player.transform.position.y >5.4)
            {

                player.transform.position = new Vector3(0, -3.65f, 0);
                player.GetComponent<BoxCollider2D>().enabled = true;
                boolStageClear = false;
               
            }
            
        }
    }
    
 
}
