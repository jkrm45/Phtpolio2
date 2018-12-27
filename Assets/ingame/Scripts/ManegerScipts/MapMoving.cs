using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoving : MonoBehaviour {
    [SerializeField]
    static float MapmoveSpeed = 1f;
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;
   
    // Use this for initialization
    void Start () {
        AudioManergerScripts.Instance.Audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > -94)
        {
            Mapemove();
        }
	}
    void Mapemove()//백그라운 무빙
    {
        transform.Translate(0, -MapmoveSpeed * Time.deltaTime, 0);
    }
}
