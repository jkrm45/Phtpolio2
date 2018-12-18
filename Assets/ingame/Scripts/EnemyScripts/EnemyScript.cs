using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EnemyScript : MonoBehaviour {
    public int Stage;
    public string EnemyNo;
    public int Speed;
    public int Mesilespeed;
    public float Cooltime;
    public int Hp;
    public string item;
    public string Type;
    public List<string> aaa;
    public bool Type1 = false;
    public bool Type2 = false;
    public bool Type3 = false;
    public bool Type4 = false;
    public bool Type5 = false;
    public bool Type6 = false;
    public bool Type7 = false;
    public int Result;
    public Transform Taget;
    //public Transform Movepos1_1;
    //public Transform Movepos1_2;
    public GameObject Movepos1_1;
    public GameObject Movepos1_2;
    public GameObject Movepos1_3;
    public GameObject Movepos1_4;
    public bool left = false;
    public bool right = false;
    public bool foward = false;
    public float totaltime = 15f;
    public float totaladdtime = 0f;
    public float time = 0;
    public float Movecool = 1f;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject firpos1;
    public GameObject firpos2;
    public GameObject firpos3;
    public GameObject firpos4;
    public GameObject firpos5;
    public float Type4shottime;
    public GameObject itemLife;
    public GameObject itemSword;
    public GameObject Effect;
    

    //public Transform Movepos1_2;
    //[SerializeField]
    //static int Speed;
    //[SerializeField]
    //static int Mesilespeed;
    //[SerializeField]
    //static float Cooltime;
    //[SerializeField]
    //static int Hp;
    //[SerializeField]
    //static int Damege;
    //[SerializeField]
    //static string item;
    //Use this for initialization
    public enum ENEMYSTATE
    {
        IDLE=0,
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
    public ENEMYSTATE Enemtstate = ENEMYSTATE.IDLE;
    

    void Start ()
    {
        aaa = new List<string>();
        var T = JSON.Parse(JasonDateScripts.Instance.Data2.text);
        for (int i = 0; i < T.Count; i++)
        {
            aaa.Add(T[i]["EnemyNo"]);
        }

        getdate();
        RandomNum();
        Taget = GameObject.Find("Player").transform;
        firpos1 = GameObject.Find("Firpos1");
        firpos2 = GameObject.Find("Firpos2");
        firpos3 = GameObject.Find("Firpos3");
        firpos4 = GameObject.Find("Firpos4");
        firpos5 = GameObject.Find("Firpos5");
        Movepos1_1 = GameObject.Find("MovePos1");
        Movepos1_2 = GameObject.Find("MovePos2");
        Movepos1_3 = GameObject.Find("MovePos3");
        Movepos1_4 = GameObject.Find("MovePos4");
        Tye3_MovingPos();


    }
	
	// Update is called once per frame
	void Update ()
    {
        TypeMove();
        ObejectDestory();

   

    }
    void getdate()
    {
        for (int i = 0; i < 28; i++)
        {
            if (EnemyNo == aaa[i])
            {
                var N = JSON.Parse(JasonDateScripts.Instance.Data2.text);
                //EnemyNo = (string)N[i]["EnemyNo"];
                Speed = (int)N[i]["Speed"];
                Mesilespeed = (int)N[i]["Mesilespeed"];
                Cooltime = (float)N[i]["Cooltime"];
                Hp = (int)N[i]["Hp"];
                item = (string)N[i]["item"];
                Type = (string)N[i]["type"];
            }

        }
        if (Type == "type1")
        {
            Type1 = true;
        }
        if (Type == "type2")
        {
            Type2 = true;
        }
        if (Type == "type3")
        {
            Type3 = true;
        }
        if (Type == "type4")
        {
            Type4 = true;
        }
        if (Type == "type5")
        {
            Type5 = true;
        }
        if (Type == "type6")
        {
            Type6 = true;
        }
        if (Type == "type7")
        {
            Type7 = true;
        }
    }//데이터값 초기화함수
    void TypeMove()//타입별 무빙함수
    {
        if (Type1 == true)
        {
            
            if (right == true)
            {
                transform.Translate(-Speed * Time.deltaTime, 0, 0, Space.World);
                if (transform.position.x < Result)
                {
                    right = false;
                    foward = true;
                }
            }
            if (left == true)
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0, Space.World);
                if (transform.position.x > Result)
                {
                    left = false;
                    foward = true;
                }
            }
            if (foward == true)
            {
                Vector3 dir5 = /*Taget.transform.position - */transform.position - Taget.transform.position;
                dir5.Normalize();
                transform.Translate(-dir5 * Speed * Time.deltaTime);

            }

       
        }
        if (Type2 == true)
        {
            transform.Translate(0, -Speed * Time.deltaTime, 0);
        }
        if (Type3 == true)
        {
            time = time + Time.deltaTime;
            if (time > Cooltime)
            {
                Instantiate(bullet3, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), transform.rotation);
                time = 0;
            }
            if (left==true)
            {
                if (transform.position.y > 1f)
                {

                    Vector3 dir = Movepos1_1.transform.position - transform.position;
                    dir.Normalize();
                    transform.Translate(dir * Speed * Time.deltaTime, Space.World);
                }

                if (transform.position.y < 1f)
                {
                    Vector3 dir2 = Movepos1_2.transform.position - transform.position;
                    dir2.Normalize();
                    transform.Translate(dir2 * Speed * Time.deltaTime, Space.World);
                }
            }
            if(right==true)
            {
                if (transform.position.y > 1f)
                {

                    Vector3 dir3 = Movepos1_3.transform.position - transform.position;
                    dir3.Normalize();
                    transform.Translate(dir3 * Speed * Time.deltaTime, Space.World);
                }

                if (transform.position.y < 1f)
                {
                    Vector3 dir4 = Movepos1_4.transform.position - transform.position;
                    dir4.Normalize();
                    transform.Translate(dir4 * Speed * Time.deltaTime, Space.World);
                }
            }
  
        }
        if (Type4 == true)
        {

            Type4shottime = Type4shottime + Time.deltaTime;
            if (Type4shottime > Cooltime)
            {
                Instantiate(bullet2, firpos1.transform.position,firpos1.transform.localRotation);
                Instantiate(bullet2, firpos2.transform.position, firpos2.transform.localRotation);
                Instantiate(bullet2, firpos3.transform.position, firpos3.transform.localRotation);
                Instantiate(bullet2, firpos4.transform.position, firpos4.transform.localRotation);
                Instantiate(bullet2, firpos5.transform.position, firpos5.transform.localRotation);
                Type4shottime = 0;
            }
            totaladdtime = totaladdtime + Time.deltaTime;
            if (totaladdtime > totaltime)
            {
                Enemtstate = ENEMYSTATE.GOOUT;
                totaladdtime = 0;
            }
            switch (Enemtstate)
            {
                case ENEMYSTATE.IDLE:
                    transform.Translate(0, -Speed * Time.deltaTime, 0,Space.World);
                    if (transform.position.y < 4.7)
                    {
                        SetRandomState();
                    }
                    break;
                case ENEMYSTATE.UP:
                    LimitMove();
                    transform.Translate(0 ,Speed * Time.deltaTime, 0, Space.World); 
                    time = time + Time.deltaTime;
                    if (time > Movecool)
                    {
                        SetRandomState();
                        time = 0;
                    }
                    break;
                case ENEMYSTATE.Left:
                    LimitMove();
                    transform.Translate(-Speed * Time.deltaTime,0, 0, Space.World);
                    time = time + Time.deltaTime;
                    if (time > Movecool)
                    {
                        SetRandomState();
                        time = 0;
                    }
                    break;
                case ENEMYSTATE.Rigt:
                    LimitMove();
                    transform.Translate(Speed * Time.deltaTime, 0, 0, Space.World);
                    time = time + Time.deltaTime;
                    if (time > Movecool)
                    {
                        SetRandomState();
                        time = 0;
                    }
                    break;
                case ENEMYSTATE.Down:
                    LimitMove();
                    transform.Translate(0, -Speed * Time.deltaTime, 0, Space.World);
                    time = time + Time.deltaTime;
                    if (time > Movecool)
                    {
                        SetRandomState();
                        time = 0;
                    }
                    break;
                case ENEMYSTATE.LeftUp:
                    LimitMove();
                    transform.Translate(-Speed * Time.deltaTime, Speed * Time.deltaTime, 0, Space.World);
                    time = time + Time.deltaTime;
                    if (time > Movecool)
                    {
                        SetRandomState();
                        time = 0;
                    }
                    break;
                case ENEMYSTATE.LeftDown:
                    LimitMove();
                    transform.Translate(-Speed * Time.deltaTime, -Speed * Time.deltaTime, 0, Space.World);
                    time = time + Time.deltaTime;
                    if (time > Movecool)
                    {
                        SetRandomState();
                        time = 0;
                    }
                    break;
                case ENEMYSTATE.RightUp:
                    LimitMove();
                    transform.Translate(Speed * Time.deltaTime, Speed * Time.deltaTime, 0, Space.World);
                    time = time + Time.deltaTime;
                    if (time > Movecool)
                    {
                        SetRandomState();
                        time = 0;
                    }
                    break;
                case ENEMYSTATE.RightDown:
                    LimitMove();
                    transform.Translate(Speed * Time.deltaTime, -Speed * Time.deltaTime, 0, Space.World);
                    time = time + Time.deltaTime;
                    if (time > Movecool)
                    {
                        SetRandomState();
                        time = 0;
                    }
                    break;


                case ENEMYSTATE.GOOUT:
                    transform.Translate(0, -Speed * Time.deltaTime,0,Space.World);
                    break;
                
            }
        }
        if (Type5 == true)
        {
            time = time + Time.deltaTime;
            if (time > Cooltime)
            {
                time = 0;
                //GameObject Type5Bull = Instantiate(bullet1, new Vector3(transform.position.x, transform.position.y - 1, 0), transform.rotation);
                Instantiate(bullet1, new Vector3(transform.position.x, transform.position.y - 0.2f, 0), transform.rotation);


            }
       
        }
        if (Type6 == true)
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
                    transform.Translate(0, -Speed * Time.deltaTime, 0, Space.World);
                    if (transform.position.y < 4.7)
                    {
                        SetRandomState();
                    }
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
                    LimitMove();
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
        if (Type7 == true)
        {
            if (right == true)
            {
                transform.Translate(-0.5f * Time.deltaTime, -Speed * Time.deltaTime, 0, Space.World);
            }
            if (left == true)
            {
                transform.Translate(0.5f * Time.deltaTime, -Speed * Time.deltaTime, 0, Space.World);
            }
            
            time = time + Time.deltaTime;
            if (time > Cooltime)
            {
                Instantiate(bullet3, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), transform.rotation);
                time = 0;
            }
        }
    }
    void ObejectDestory()//오브젝트파괴함수
    {
        
     
        if (Type4 == true)
        {

            if (Hp < 0)
            {
                GameManeger.Instance.Score = GameManeger.Instance.Score + 200;
                Instantiate(Effect, transform.position, transform.localRotation);
                Instantiate(itemLife, transform.position, itemLife.transform.localRotation);
                Destroy(gameObject);
               
            }
            if (transform.position.y < -4)
            {
                Destroy(gameObject);
            }
        }
        if (Type6 == true)
        {

            if (Hp < 0)
            {
                Instantiate(itemSword, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (transform.position.y < -4)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (Hp < 0)
            {
                GameManeger.Instance.Score = GameManeger.Instance.Score + 10;
                Instantiate(Effect, transform.position, transform.localRotation);
                Destroy(gameObject);
            }
            if (transform.position.y < -4)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Hp = Hp - GameManeger.Instance.Damege;
           
           
        }
        if (Type6 == true)
        {


        }
        else
        {
            if (collision.tag == "Player")
            {


                Destroy(gameObject);

            }
        }
       
    }

    int RandomNum()
    {
        Result=Random.Range(-2, 3);
        return Result;
    }

    void Tye3_MovingPos()
    {
        Movepos1_1 = GameObject.Find("MovePos1");
        Movepos1_2 = GameObject.Find("MovePos2");
        Movepos1_3 = GameObject.Find("MovePos3");
        Movepos1_4 = GameObject.Find("MovePos4");
        if (transform.position.x < 0)
        {
            left = true;
        }
        else
        {
            right = true;
        }
    }
    void LimitMove()
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
        if (transform.position.y < 1.5)
        {
          
            transform.position = new Vector3(transform.position.x, 1.5f, 0);
            Enemtstate = ENEMYSTATE.UP;
        }
        if (transform.position.y > 5)
        {
           
            transform.position = new Vector3(transform.position.x, 5, 0);
            Enemtstate = ENEMYSTATE.Down;
        }
        if (transform.position.x < -2.4 && transform.position.y < 1.5)
        {

            transform.position = new Vector3(-2.4f,1.5f, 0);
            Enemtstate = ENEMYSTATE.RightUp;
        }
        if (transform.position.x > 2.4  && transform.position.y<1.5)
        {

            transform.position = new Vector3(2.4f, 1.5f, 0);
            Enemtstate = ENEMYSTATE.LeftUp;
        }
        if (transform.position.x > 2.4 &&  transform.position.y >5)
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








}
