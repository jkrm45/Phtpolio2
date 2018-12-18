using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScripts : MonoBehaviour {
    static int Speed =10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        SelfDestory();

	}
    void Move()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }
    void SelfDestory()
    {
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy" || collision.tag == "Type6")
        {
            Destroy(gameObject);
        }
    }
}
