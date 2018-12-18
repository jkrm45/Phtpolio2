using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanerType7 : MonoBehaviour {
    public GameObject type7_1;
    public GameObject type7_2;
    public GameObject type7_3;
    public int Result;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameManeger")
        {
            //GameObject Enmey = Instantiate(type7, transform.position, type7.transform.localRotation) as GameObject;
            //Enmey.transform.parent = gameObject.transform;
            Shcosse();
        }


    }
    int RandomNum()
    {
        Result = Random.Range(0, 3);
        return Result;
    }
    void Shcosse()
    {
        switch (RandomNum())
        {
            case 0:
                GameObject Enmey1 = Instantiate(type7_1, transform.position, type7_1.transform.localRotation) as GameObject;
                Enmey1.transform.parent = gameObject.transform;
                break;
            case 1:
                GameObject Enmey2 = Instantiate(type7_2, transform.position, type7_2.transform.localRotation) as GameObject;
                Enmey2.transform.parent = gameObject.transform;
                break;
            case 2:
                GameObject Enmey3 = Instantiate(type7_3, transform.position, type7_3.transform.localRotation) as GameObject;
                Enmey3.transform.parent = gameObject.transform;
                break;
            default:
                break;
        }
    }
}
