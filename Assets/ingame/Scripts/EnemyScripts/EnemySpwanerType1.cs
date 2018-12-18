using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanerType1 : MonoBehaviour {
    public GameObject type1;
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
            GameObject Enmey = Instantiate(type1, transform.position, type1.transform.localRotation) as GameObject;
            Enmey.transform.parent = gameObject.transform;
        }
  
    }
    
}
