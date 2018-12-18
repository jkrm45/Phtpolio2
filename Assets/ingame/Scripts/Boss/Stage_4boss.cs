using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_4boss : MonoBehaviour {
    public int Stage;
    public int Speed;
    public int Hp;
    public float Cooltime;
    public float SpecialAttackCooltime;
    // Use this for initialization
    public enum BOSSTATE
    {
        IDLE = 0,
        UP,
        DOWN,
        LEFT,
        RIGHT,
        DEAD
    }
    public Transform BossbaseMovepos;
    public BOSSTATE Bossate;
    public int Result;
    public GameObject BossBullet;

    public float cooladdtime;
    public GameObject Efeft;
    public GameObject[] Eeffet;
    // Use this for initialization
    void Start()
    {
        //BossMeneger.Instance.Stage = Stage;
        START();
        Bossate = BOSSTATE.IDLE;
        BossbaseMovepos = GameObject.Find("Boss").transform;
        Eeffet = new GameObject[7];
        
    }

    // Update is called once per frame
    void Update()
    {
        cooladdtime = cooladdtime + Time.deltaTime;

        if (cooladdtime > Cooltime)
        {
            cooladdtime = 0;
            Instantiate(BossBullet, transform.position, transform.rotation);

        }
        switch (Bossate)
        {
            case BOSSTATE.IDLE:
                Vector3 dir = BossbaseMovepos.position - transform.position;
                dir.Normalize();
                transform.Translate(dir * Speed * Time.deltaTime);
                float distance = Vector3.Distance(BossbaseMovepos.position, transform.position);

                if (distance < 0.15)
                {
                    RandonMove();
                }
                break;
            case BOSSTATE.UP:
                transform.Translate(0, Speed * Time.deltaTime, 0, Space.World);
                LimitMove();

                break;
            case BOSSTATE.DOWN:
                transform.Translate(0, -Speed * Time.deltaTime, 0, Space.World);
                LimitMove();
                break;
            case BOSSTATE.LEFT:
                transform.Translate(-Speed * Time.deltaTime, 0, 0, Space.World);
                LimitMove();
                break;
            case BOSSTATE.RIGHT:
                transform.Translate(Speed * Time.deltaTime, 0, 0, Space.World);
                LimitMove();
                break;
            case BOSSTATE.DEAD:
                cooladdtime = 0;
                transform.Translate(Speed * Time.deltaTime, -Speed * Time.deltaTime, 0, Space.World);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                GameManeger.Instance.player.GetComponent<BoxCollider2D>().enabled = false;
                GameManeger.Instance.boolStageClear = true;
                Make();
                if (GameManeger.Instance.player.transform.position.y > 5.3)

                {
                    //GameManeger.Instance.boolStageClear = false;
                    GameManeger.Instance.player.GetComponent<BoxCollider2D>().enabled = true;
                    GameManeger.Instance.Score = GameManeger.Instance.Score + 1000;
                    GameManeger.Instance.i = GameManeger.Instance.i + 1;
                    Application.LoadLevel(GameManeger.Instance.i);
                    Destroy(gameObject);

                }
                break;
            default:
                break;
        }
        BossDestory();
    }
    void BossDestory()
    {
        if (Hp < 0)
        {
            //player score ++ 
            Bossate = BOSSTATE.DEAD;

        }

    }
    void LimitMove()
    {
        if (transform.position.x < -1.9)
        {
            transform.position = new Vector3(-1.9f, transform.position.y, 0);
            //Bossate = BOSSTATE.RIGHT;
            Bossate = BOSSTATE.IDLE;
        }
        if (transform.position.x > 1.9)
        {
            transform.position = new Vector3(1.9f, transform.position.y, 0);
            //Bossate = BOSSTATE.LEFT;
            Bossate = BOSSTATE.IDLE;
        }
        if (transform.position.y < 2.5)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, 0);
            //Bossate = BOSSTATE.UP;
            Bossate = BOSSTATE.IDLE;
        }
        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
            //Bossate = BOSSTATE.DOWN;
            Bossate = BOSSTATE.IDLE;
        }
    }
    int RandomNum()
    {
        Result = Random.Range(0, 4);
        return Result;
    }
    void RandonMove()
    {
        switch (RandomNum())
        {
            case 0:
                Bossate = BOSSTATE.UP;
                break;
            case 1:
                Bossate = BOSSTATE.DOWN;
                break;
            case 2:
                Bossate = BOSSTATE.LEFT;
                break;
            case 3:
                Bossate = BOSSTATE.RIGHT;
                break;
            default:
                break;
        }
    }
    void GetData()
    {
        Speed = BossMeneger.Instance.Speed;
        Hp = BossMeneger.Instance.Hp;
        Cooltime = BossMeneger.Instance.Cooltime;
        SpecialAttackCooltime = BossMeneger.Instance.SpecialAttackCooltime;
    }  
    IEnumerator Star()
    {
        BossMeneger.Instance.Stage = Stage;
        yield return new WaitForSeconds(0.001f);
        GetData();





    }
    public void START()
    {
        StartCoroutine(Star());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Hp = Hp - GameManeger.Instance.Damege;
        }
    }
    IEnumerator MakeProcess()
    {
        for (int i = 0; i < 7; i++)
        {
            Eeffet[i] = Instantiate(Efeft, new Vector3(transform.position.x + Random.Range(-1, 2), transform.position.y + Random.Range(-1, 2), 0), Efeft.transform.localRotation) as GameObject;

            yield return new WaitForSeconds(1);
        }




    }
    public void Make()
    {
        StartCoroutine(MakeProcess());
    }
}
