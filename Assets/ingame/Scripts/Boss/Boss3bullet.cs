using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3bullet : MonoBehaviour {

    public float Speed;
    public Transform Player;
    Vector3 dir;
    public float Movetime;
    public float Movetimeadd;
    public float endtime;
   
    // Use this for initialization
    void Start()
    {
      
    }
    // Use this for initialization
   

    // Update is called once per frame
    void Update()
    {
        Movetimeadd = Movetimeadd + Time.deltaTime;
        if (Movetimeadd < Movetime)
        {
            Player = GameObject.Find("Player").transform;
            dir = Player.position - transform.position;
            dir.Normalize();
            transform.Translate(dir * Speed * Time.deltaTime, Space.World);
            
        }
        if (Movetimeadd < endtime && Movetimeadd>Movetime)
        {
            gameObject.transform.localScale += new Vector3(3 * Time.deltaTime, 3 * Time.deltaTime, 0);
        }
        if (Movetimeadd > endtime)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
