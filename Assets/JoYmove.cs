using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoYmove : MonoBehaviour {
    protected Joystick joystick;
    public int speed;
	// Use this for initialization
	void Start () {
        joystick = FindObjectOfType<Joystick>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(joystick.Horizontal * speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime, 0, Space.World);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
