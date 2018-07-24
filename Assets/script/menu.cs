using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {
    public GameObject sign_up, sign_in;
	// Use this for initialization
	void Start () {
        sign_up.SetActive(false);
        sign_in.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void sign_up_btn()
    {
        sign_up.SetActive(true);
        gameObject.SetActive(false);
    }
    public void sign_in_btn()
    {
        sign_in.SetActive(true);
        gameObject.SetActive(false);
    }
}
