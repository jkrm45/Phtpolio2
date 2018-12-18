using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBtmMeneger : MonoBehaviour {

    public GameObject Ban;
    public GameObject Chairchose;
    public GameObject play;
    public GameObject chir;
    public bool Left = false;
    public bool Right = false;
    public GameObject Check1;
    public GameObject Check2;
    public GameObject Check3;
    public GameObject Check4;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Checking();
        if (Left == true)
        {
            
            chir.transform.Translate(0.5f * Time.deltaTime, 0, 0);
            if (chir.transform.localPosition.x > -22.3)
            {
                chir.transform.localPosition = new Vector3(-22.3f, chir.transform.localPosition.y, 0);
            }
        }
        if (Right == true)
        {
            if (chir.transform.localPosition.x < -430.3)
            {
                chir.transform.localPosition = new Vector3(-430.3f, chir.transform.localPosition.y, 0);
            }
            chir.transform.Translate(-0.5f * Time.deltaTime, 0, 0);
        }
    }
    void Checking()
    {
        if (Check1.activeSelf== true)
        {
            GameManeger.Instance.Player = 1;
        }
        if (Check2.activeSelf == true)
        {
            GameManeger.Instance.Player = 2;
        }
        if (Check3.activeSelf == true)
        {
            GameManeger.Instance.Player = 3;
        }
        if (Check4.activeSelf == true)
        {
            GameManeger.Instance.Player =4;
        }
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
        Ban.SetActive(true);
    }
    public void UnSound()
    {
        Ban.SetActive(false);
    }

    public void onchose()
    {

        Chairchose.SetActive(true);
        play.GetComponent<BoxCollider>().enabled = false;
    }
    public void offchose()
    {
        play.GetComponent<BoxCollider>().enabled = true;
        Chairchose.SetActive(false);
    }
    public void MovePre()
    {
        Left = true;
    }
    public void MovePre2()
    {
        Left = false;
    }
    public void MoveNext()
    {

        Right = true;
    }
    public void MoveNext2()
    {

        Right = false;
    }
    public void Chirck1()
    {
        Check1.SetActive(true);
        Check2.SetActive(false);
        Check3.SetActive(false);
        Check4.SetActive(false);
    }
    public void Chirck2()
    {
        Check1.SetActive(false);
        Check2.SetActive(true);
        Check3.SetActive(false);
        Check4.SetActive(false);
    }
    public void Chirck3()
    {
        Check1.SetActive(false);
        Check2.SetActive(false);
        Check3.SetActive(true);
        Check4.SetActive(false);
    }
    public void Chirck4()
    {
        Check1.SetActive(false);
        Check2.SetActive(false);
        Check3.SetActive(false);
        Check4.SetActive(true);
    }
}
