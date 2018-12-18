using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpcialBullet : MonoBehaviour {
    public float Speed;
    public Transform Player;
    Vector3 dir;
    public bool Taget = false;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player").transform;
        dir = Player.position - transform.position;
        dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Taget == false)
        {
            transform.Translate(0, Speed * Time.deltaTime, 0, Space.World);
            if (transform.position.y > 5)
            {
                Taget = true;
            }
        }

        if (Taget == true)
        {
            transform.Translate(dir * Speed * Time.deltaTime,Space.World);
            if (transform.position.y < -4)
            {
                Destroy(gameObject);
            }
        }
      
        Destroy(gameObject,4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
