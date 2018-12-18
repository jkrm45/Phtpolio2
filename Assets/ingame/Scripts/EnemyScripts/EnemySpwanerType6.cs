using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanerType6 : MonoBehaviour {
    public GameObject type6;
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
            GameObject Enmey = Instantiate(type6, transform.position, type6.transform.localRotation) as GameObject;
            Enmey.transform.parent = gameObject.transform;
        }
      
    }
}
