using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour {

    public GameObject player;
    public GameObject self;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		
        if (player.GetComponent<movimento_player>().chave == true)
        {
            if (self != null)
            {
                Destroy(self);
            }
        }
	}
}
