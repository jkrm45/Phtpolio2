using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class BulletSripts : MonoBehaviour {
    public bool type3 = false;
    public bool type4 = false;
    public bool type5 = false;
    public int Speed = 8;
    public Transform player;
    Vector3 dir6;
    public string Type;
    public int Damege;
    public List<string> aaa;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").transform;
        dir6 =  transform.position-player.position;
        dir6.Normalize();
        aaa = new List<string>();
        var T = JSON.Parse(JasonDateScripts.Instance.Data2.text);
        for (int i = 0; i < T.Count; i++)
        {
            aaa.Add(T[i]["type"]);
        }
        getdate();
    }
	
	// Update is called once per frame
	void Update ()
    {
        typeMove();
	}

    void typeMove()
    {
        if (type3 == true)
        {
            transform.Translate(0, -Speed * Time.deltaTime, 0,Space.World);
        }
        if (type5 == true)
        {
            transform.Translate(-dir6 * Speed * Time.deltaTime, Space.World);
        }
        if (type4 == true)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
        }
        Destroy(gameObject, 3);
    }
    void getdate()
    {
        for (int i = 0; i < 25; i++)
        {
            if (Type == aaa[i])
            {
                var N = JSON.Parse(JasonDateScripts.Instance.Data2.text);
                //EnemyNo = (string)N[i]["EnemyNo"];
             
                Damege = (int)N[i]["Damege"];
               
            }

        }
     
    }//데이터값 초기화함수
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
           
            Destroy(gameObject);
        }
      
    }
}
