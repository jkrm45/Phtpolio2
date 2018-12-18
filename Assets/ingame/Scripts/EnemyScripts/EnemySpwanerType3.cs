using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwanerType3 : MonoBehaviour {
    public GameObject type3;
    public GameObject[] Enmey;
  
    // Use this for initialization
    void Start()
    {
        Enmey = new GameObject[5];
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameManeger")
        {
            if (other.tag == "GameManeger")
            {
                Make();
                
            }
        }
        
    }
    IEnumerator MakeProcess() 
    {
        for (int i = 0; i < 5; i++)
        {
            Enmey[i] = Instantiate(type3, transform.position, type3.transform.localRotation) as GameObject;
            Enmey[i].transform.parent = gameObject.transform;
            yield return new WaitForSeconds(0.3f);
        }
          
   
        
       
    }
    public void Make()
    {
        StartCoroutine(MakeProcess()); 
    }

 
}
