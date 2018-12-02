using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarAudio : MonoBehaviour {

    public GameObject som;

    private void Awake()
    {

        som = GameObject.Find("Som_Passos");
        
    }
	
	// Update is called once per frame
	public void Tocar () {

        som.GetComponent<AudioSource>().Play();

	}
    public bool Esta_tocando()
    {
        return som.GetComponent<AudioSource>().isPlaying;
    }

}
