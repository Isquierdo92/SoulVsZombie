using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerinicio : MonoBehaviour {

    public GameObject Soul;

	// Use this for initialization
	void Start () {
        Soul = GameObject.Find("inimigo");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Enemy_follow>().vivo = true;
    }
}
