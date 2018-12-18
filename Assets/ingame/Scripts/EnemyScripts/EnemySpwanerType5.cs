using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanerType5 : MonoBehaviour {
    public GameObject type5;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
      
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameManeger")
        {
            GameObject Enmey = Instantiate(type5, transform.position, type5.transform.localRotation) as GameObject;
            Enmey.transform.parent = gameObject.transform;
        }
       
    }
}
