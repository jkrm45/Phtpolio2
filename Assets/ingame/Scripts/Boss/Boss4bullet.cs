using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4bullet : MonoBehaviour {
    public GameObject Sub;
    public float Speed;
    public Transform Player;
    Vector3 dir;
    public float movetime;
    public float moveaddtime;
    public float endtime;
    public float cool;
    public float cooladd;
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player").transform;
        dir = Player.position - transform.position;
        dir.Normalize();
    }
	
	// Update is called once per frame
	void Update () {
        moveaddtime = moveaddtime + Time.deltaTime;
        cooladd = cooladd + Time.deltaTime;
        if (moveaddtime < movetime)
        {
            transform.Translate(dir * Speed * Time.deltaTime, Space.World);
        }
        if (moveaddtime > endtime)
        {
            Destroy(gameObject);
        }
        if (cooladd > cool)
        {
            cooladd = 0;
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -100));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -90));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -80));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -70));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -60));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -50));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -40));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -30));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -20));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, -10));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, 0));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, 20));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, 40));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, 60));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, 80));
            Instantiate(Sub, transform.position, Quaternion.EulerRotation(0, 0, 100));
        }
        

    }
}
