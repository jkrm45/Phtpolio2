using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UiManerScripts : MonoBehaviour {

    private static UiManerScripts _instance = null;
    public static UiManerScripts Instance { get { return _instance; } }

    public GameObject IngameBtm;
    public GameObject IngameMenu;
    public GameObject InSound;
    public GameObject star;
    public GameObject Ban;
    public GameObject Bg;
    public bool Cont = false;
    public GameObject Timecount;
    public float Conttime = 10;
    public GameObject Contdown;
    public GameObject Ui;
    // Use this for initialization
    void Awake () {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        Adds();
        Roding();
	}
    void Roding()
    {
        if (GameManeger.Instance.i >= 2)
        {
            Ui.SetActive(true);
        }
        else
        {
            Ui.SetActive(false);
        }
    }
    void Adds()
    {
        if (Cont == true)
        {
            Conttime = (Conttime - Time.deltaTime);

            Timecount.GetComponent<UILabel>().text = "" + (int)(Conttime);
            if (Conttime < 0)
            {
                Conttime = 10;
                GameManeger.Instance.Lifecount = 3;
                GameManeger.Instance.Score = 0;
                GameManeger.Instance.i = 1;
                Application.LoadLevel(GameManeger.Instance.i);
          
            }
        }
        if (GameManeger.Instance.Lifecount < 1)
        {
            Contdown.SetActive(true);
        }
        else
        {
            Contdown.SetActive(false);
            Conttime = 10;
        }
    }
    public void OpenInGameMenu()
    {
        Time.timeScale = 0;
        Bg.SetActive(true);
    }
    public void Star()
    {
        Bg.SetActive(false);
        Time.timeScale = 1;
    }
    public void goMenu()
    {
        Bg.SetActive(false);
        GameManeger.Instance.Lifecount = 3;
        GameManeger.Instance.Score = 0;
        GameManeger.Instance.i = 1;

        Application.LoadLevel(GameManeger.Instance.i);
    }
    public void Sound()
    {
        Ban.SetActive(true);
    }
    public void BanSound()
    {
        Ban.SetActive(false);
    }
    public void No()
    {
        Conttime = 10;
        Contdown.SetActive(false);
        GameManeger.Instance.Lifecount = 3;
        GameManeger.Instance.Score = 0;
        GameManeger.Instance.i = 1;
        Application.LoadLevel(GameManeger.Instance.i);
    }
    public void Yes()
    {
        Conttime = 10;
        //광고

        GameManeger.Instance.Lifecount = 3;

      
    }
  
   
}
