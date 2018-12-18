using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PlayerMove : MonoBehaviour {
   
    public int Player;
    public int Hp;
    public GameObject Bullet;
    public Transform firePos1;
    public Transform firePos2;
    public Transform firePos3;
    public GameObject SecondWeapon1;
    public Transform SecondfirePos1;
    public GameObject SecondWeapon2;
    public Transform SecondfirePos2;
    public GameObject Chairk1;
    public GameObject Chairk2;
    public GameObject Chairk3;
    public GameObject Chairk4;
    public GameObject Life;
    public bool fire2 = false;
    public bool fire3 = false;
    public bool SecondWeaponon1 = false;
    public bool SecondWeaponon2 = false;
    public bool playing = true;

 


    [SerializeField]
    static int Speed;
    [SerializeField]
    static int Damege;
    [SerializeField]
    static float Cooltime;
    [SerializeField]
    static int SecondWeaponDamege;
    [SerializeField]
    static float SecTime;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
       
        //Player = GameManeger.Instance.Player;
        ////var n = JSON.Parse(JasonDateScripts.Instance.Data1.text);
        ////Hp = (int)n[Player-1]["Hp"];
        ////Speed = (int)n[Player-1]["Speed"];
        ////Damege = (int)n[Player-1]["Damege"];
        ////Cooltime = (float)n[Player-1]["Cooltime"];
        ////SecondWeaponDamege = (int)n[Player-1]["SecondWeaponDamege"];
        ////Charic();

    }
	
	// Update is called once per frame
	void Update () {
        Player = GameManeger.Instance.Player;
    
        if (GameManeger.Instance.i >= 2)
        {
            Gameplay();
        }

    }
    void Gameplay()
    {
        if (playing == true)
        {
            LimitMove();
            Shoot();
            Move();
        }
        Charic();
        getData();


        if (GameManeger.Instance.Lifecount < 1)
        {
            playing = false;
        }
        else
        {
            playing = true;
        }

        if (SecondWeaponon2 == false)
        {
            SecondWeapon2.SetActive(false);
        }
        if (SecondWeaponon1 == false)
        {
            SecondWeapon1.SetActive(false);
        }
    }
    void Move()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Speed*Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,-Speed * Time.deltaTime, 0);
        }
    }
    void LimitMove()
    {
        if (transform.position.x < -2.4)
        {
            transform.position = new Vector3(-2.4f, transform.position.y, 0);
        }
        if (transform.position.x > 2.4)
        {
            transform.position = new Vector3(2.4f, transform.position.y, 0);
        }
        if (transform.position.y < -3.3)
        {
            transform.position = new Vector3(transform.position.x, -3.3f, 0);
        }
        if (transform.position.y > 5.4)
        {
            transform.position = new Vector3(transform.position.x, 5.4f, 0);
        }
    }
    void Shoot()
    {
        SecTime = SecTime + Time.deltaTime;
        if (SecTime > Cooltime)
        {
            GameObject Bull1 = Instantiate(Bullet, firePos1.position, firePos1.rotation) as GameObject;
            if (fire2 == true)
            {
                GameObject Bull2 = Instantiate(Bullet, firePos2.position, firePos2.rotation) as GameObject;

                if (fire3 == true)
                {
                    GameObject Bull3 = Instantiate(Bullet, firePos3.position, firePos3.rotation) as GameObject;

                    if (SecondWeaponon1 == true)
                    {
                        SecondWeapon1.SetActive(true);
                        GameObject Bull4 = Instantiate(Bullet, SecondfirePos1.position, SecondfirePos2.rotation) as GameObject;

                        if (SecondWeaponon2 == true)
                        {
                            SecondWeapon2.SetActive(true);
                            GameObject Bull5 = Instantiate(Bullet, SecondfirePos2.position, SecondfirePos2.rotation) as GameObject;

                        }
                        else
                        {
                            SecondWeapon2.SetActive(false);
                        }
                    }
                    else
                    {
                        SecondWeapon1.SetActive(false);
                    }
                }
               
            }
            
            SecTime = 0;
        }
        //if (fire2 ==true)
        //{
        //    GameObject Bull2 = Instantiate(Bullet, firePos2.position, firePos2.rotation) as GameObject;
        //    SecTime = 0;
        //}
        //if (fire3 == true)
        //{
        //    GameObject Bull3 = Instantiate(Bullet, firePos3.position, firePos3.rotation) as GameObject;
        //    SecTime = 0;
        //}
        //if (SecondWeaponon1 == true)
        //{
        //    GameObject Bull4 = Instantiate(Bullet, SecondfirePos1.position, SecondfirePos2.rotation) as GameObject;
        //    SecTime = 0;
        //}
        //if (SecondWeaponon2 == true)
        //{
        //    GameObject Bull5 = Instantiate(Bullet, SecondfirePos2.position, SecondfirePos2.rotation) as GameObject;
        //    SecTime = 0;
        //}

    }
  
    void Charic()
    {
        if (Player == 1)
        {
            Chairk1.SetActive(true);
            Chairk2.SetActive(false);
            Chairk3.SetActive(false);
            Chairk4.SetActive(false);
        }
        if (Player == 2)
        {
            Chairk1.SetActive(false);
            Chairk2.SetActive(true);
            Chairk3.SetActive(false);
            Chairk4.SetActive(false);
        }
        if (Player == 3)
        {
            Chairk1.SetActive(false);
            Chairk2.SetActive(false);
            Chairk3.SetActive(true);
            Chairk4.SetActive(false);
        }
        if (Player == 4)
        {
            Chairk1.SetActive(false);
            Chairk2.SetActive(false);
            Chairk3.SetActive(false);
            Chairk4.SetActive(true);
        }
    }
    void getData()
    {

        Speed = GameManeger.Instance.Speed;
        Damege = GameManeger.Instance.Damege;
        Cooltime = GameManeger.Instance.Cooltime;
        SecondWeaponDamege = GameManeger.Instance.SecondWeaponDamege;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fire2 == false)
        {
            if (collision.tag == "itemsword")
            {
                fire2 = true;

            }
        }
        else
        {
            if (fire3 == false)
            {
                if (collision.tag == "itemsword")
                {
                    fire3 = true;

                }
            }
            else
            {
                if (SecondWeaponon1 == false)
                {
                    if (collision.tag == "itemsword")
                    {
                        SecondWeaponon1 = true;

                    }
                }
                else
                {
                    if (SecondWeaponon2 == false)
                    {
                        if (collision.tag == "itemsword")
                        {
                            SecondWeaponon2 = true;

                        }
                    }
                }
            }
        }


        if (fire2 == true)
        {
            if (fire3 == true)
            {
                if (SecondWeaponon1 == true)
                {
                    if (SecondWeaponon2 == true)
                    {
                        if (collision.tag == "Enemy" || collision.tag == "EnemyBullet" || collision.tag == "Boss")
                        {
                            SecondWeaponon2 = false;
                        }
                    }
                    else
                    {
                        if (collision.tag == "Enemy" || collision.tag == "EnemyBullet" || collision.tag == "Boss")
                        {
                            SecondWeaponon1 = false;
                        }
                    }
                }
                else
                {
                    if (collision.tag == "Enemy" || collision.tag == "EnemyBullet" || collision.tag == "Boss")
                    {
                        fire3 = false;
                    }
                }
            }
            else
            {
                if (collision.tag == "Enemy" || collision.tag == "EnemyBullet" || collision.tag == "Boss")
                {
                    fire2 = false;
                }
            }

        }
        else
        {
            if (collision.tag == "Enemy" || collision.tag == "EnemyBullet" || collision.tag == "Boss")
            {
                transform.position = new Vector3(0, -5, 0);
                GameManeger.Instance.Lifecount = GameManeger.Instance.Lifecount - 1;
                HitStart();
            }
        }
        if (collision.tag == "itemlife")
        {
            GameManeger.Instance.Lifecount = GameManeger.Instance.Lifecount + 1;
        }
    }
    IEnumerator Hit(float time)
    {
        float dltime = 0f;
        while (dltime<time)
        {
            dltime += Time.deltaTime;
            Chairk1.GetComponent<SpriteRenderer>().enabled = false;
            Chairk2.GetComponent<SpriteRenderer>().enabled = false;
            Chairk3.GetComponent<SpriteRenderer>().enabled = false;
            Chairk4.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForEndOfFrame();

        }
        gameObject.GetComponent<BoxCollider2D>().enabled = true ;
        Chairk1.GetComponent<SpriteRenderer>().enabled = true;
        Chairk2.GetComponent<SpriteRenderer>().enabled = true;
        Chairk3.GetComponent<SpriteRenderer>().enabled = true;
        Chairk4.GetComponent<SpriteRenderer>().enabled = true;
    }
    void HitStart()
    {
        StartCoroutine(Hit(0.1f));
    }
}
