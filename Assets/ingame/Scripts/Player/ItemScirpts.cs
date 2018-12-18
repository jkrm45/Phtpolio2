using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScirpts : MonoBehaviour {
    public enum ENEMYSTATE
    {
        IDLE = 0,
        UP,
        Left,
        Rigt,
        Down,
        LeftDown,
        RightDown,
        LeftUp,
        RightUp,
        GOOUT

    }
    public float totaladdtime;
    public float totaltime = 20f;
    public float Speed = 1.5f;
    public float time;
    public float Movecool = 2f;
    public ENEMYSTATE Enemtstate = ENEMYSTATE.IDLE;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        totaladdtime = totaladdtime + Time.deltaTime;
        if (totaladdtime > totaltime)
        {
            Enemtstate = ENEMYSTATE.GOOUT;
            totaladdtime = 0;
        }
        switch (Enemtstate)
        {
            case ENEMYSTATE.IDLE: 
                    SetRandomState();
                      break;
            case ENEMYSTATE.UP:
                LimitMove2();
                transform.Translate(0, Speed * Time.deltaTime, 0, Space.World);
                time = time + Time.deltaTime;
                if (time > Movecool)
                {
                    SetRandomState();
                    time = 0;
                }
                break;
            case ENEMYSTATE.Left:
                LimitMove2();
                transform.Translate(-Speed * Time.deltaTime, 0, 0, Space.World);
                time = time + Time.deltaTime;
                if (time > Movecool)
                {
                    SetRandomState();
                    time = 0;
                }
                break;
            case ENEMYSTATE.Rigt:
                LimitMove2();
                transform.Translate(Speed * Time.deltaTime, 0, 0, Space.World);
                time = time + Time.deltaTime;
                if (time > Movecool)
                {
                    SetRandomState();
                    time = 0;
                }
                break;
            case ENEMYSTATE.Down:
                LimitMove2();
                transform.Translate(0, -Speed * Time.deltaTime, 0, Space.World);
                time = time + Time.deltaTime;
                if (time > Movecool)
                {
                    SetRandomState();
                    time = 0;
                }
                break;
            case ENEMYSTATE.LeftUp:
                LimitMove2();
                transform.Translate(-Speed * Time.deltaTime, Speed * Time.deltaTime, 0, Space.World);
                time = time + Time.deltaTime;
                if (time > Movecool)
                {
                    SetRandomState();
                    time = 0;
                }
                break;
            case ENEMYSTATE.LeftDown:
                LimitMove2();
                transform.Translate(-Speed * Time.deltaTime, -Speed * Time.deltaTime, 0, Space.World);
                time = time + Time.deltaTime;
                if (time > Movecool)
                {
                    SetRandomState();
                    time = 0;
                }
                break;
            case ENEMYSTATE.RightUp:
                LimitMove2();
                transform.Translate(Speed * Time.deltaTime, Speed * Time.deltaTime, 0, Space.World);
                time = time + Time.deltaTime;
                if (time > Movecool)
                {
                    SetRandomState();
                    time = 0;
                }
                break;
            case ENEMYSTATE.RightDown:
                LimitMove2();
                transform.Translate(Speed * Time.deltaTime, -Speed * Time.deltaTime, 0, Space.World);
                time = time + Time.deltaTime;
                if (time > Movecool)
                {
                    SetRandomState();
                    time = 0;
                }
                break;


            case ENEMYSTATE.GOOUT:
                transform.Translate(0, -Speed * Time.deltaTime, 0, Space.World);
                break;

        }
    }
    
    int RandomState()
    {
        int ranstage = Random.Range(0, 4);
        return ranstage;
    }
    void SetRandomState()
    {
        switch (RandomState())
        {
            case 0:
                Enemtstate = ENEMYSTATE.LeftUp;
                break;
            case 1:
                Enemtstate = ENEMYSTATE.LeftDown;

                break;
            case 2:
                Enemtstate = ENEMYSTATE.RightUp;
                break;
            case 3:
                Enemtstate = ENEMYSTATE.RightDown;
                break;


        }
    }
    void LimitMove2()
    {
        if (transform.position.x < -2.4)
        {

            transform.position = new Vector3(-2.4f, transform.position.y, 0);
            Enemtstate = ENEMYSTATE.Rigt;
        }
        if (transform.position.x > 2.4)
        {

            transform.position = new Vector3(2.4f, transform.position.y, 0);
            Enemtstate = ENEMYSTATE.Left;
        }
        if (transform.position.y < -3.5)
        {

            transform.position = new Vector3(transform.position.x, -3.5f, 0);
            Enemtstate = ENEMYSTATE.UP;
        }
        if (transform.position.y > 5)
        {

            transform.position = new Vector3(transform.position.x, 5, 0);
            Enemtstate = ENEMYSTATE.Down;
        }
        if (transform.position.x < -2.4 && transform.position.y < -3.5)
        {

            transform.position = new Vector3(-2.4f, -3.5f, 0);
            Enemtstate = ENEMYSTATE.RightUp;
        }
        if (transform.position.x > 2.4 && transform.position.y < -3.5)
        {

            transform.position = new Vector3(2.4f, -3.5f, 0);
            Enemtstate = ENEMYSTATE.LeftUp;
        }
        if (transform.position.x > 2.4 && transform.position.y > 5)
        {

            transform.position = new Vector3(2.4f, 5, 0);
            Enemtstate = ENEMYSTATE.LeftDown;
        }
        if (transform.position.x < -2.4 && transform.position.y > 5)
        {

            transform.position = new Vector3(-2.4f, 5, 0);
            Enemtstate = ENEMYSTATE.RightDown;
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
