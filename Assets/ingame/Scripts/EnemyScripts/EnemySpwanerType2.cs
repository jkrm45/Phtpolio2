using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanerType2 : MonoBehaviour {
    public GameObject type2;
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
            GameObject Enmey = Instantiate(type2, transform.position, type2.transform.localRotation) as GameObject;
            Enmey.transform.parent = gameObject.transform;
        }
       
    }
}
