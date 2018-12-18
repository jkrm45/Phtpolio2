using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanerType4 : MonoBehaviour {
    public GameObject type4_1;
    public GameObject type4_2;
    public GameObject type4_3;
    public GameObject type4_4;
    public GameObject type4_5;
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
        if (Application.loadedLevel == 1)
        {
            if (other.tag == "GameManeger")
            {
                GameObject Enmey = Instantiate(type4_1, transform.position, type4_1.transform.localRotation) as GameObject;
                Enmey.transform.parent = gameObject.transform;
            }
        }
        if (Application.loadedLevel == 2)
        {
            if (other.tag == "GameManeger")
            {
                GameObject Enmey = Instantiate(type4_2, transform.position, type4_2.transform.localRotation) as GameObject;
                Enmey.transform.parent = gameObject.transform;
            }
        }
        if (Application.loadedLevel == 3)
        {
            if (other.tag == "GameManeger")
            {
                GameObject Enmey = Instantiate(type4_3, transform.position, type4_3.transform.localRotation) as GameObject;
                Enmey.transform.parent = gameObject.transform;
            }
        }
        if (Application.loadedLevel == 4)
        {
            if (other.tag == "GameManeger")
            {
                GameObject Enmey = Instantiate(type4_4, transform.position, type4_4.transform.localRotation) as GameObject;
                Enmey.transform.parent = gameObject.transform;
            }
        }
        if (Application.loadedLevel == 5)
        {
            if (other.tag == "GameManeger")
            {
                GameObject Enmey = Instantiate(type4_5, transform.position, type4_5.transform.localRotation) as GameObject;
                Enmey.transform.parent = gameObject.transform;
            }
        }


    }
}
