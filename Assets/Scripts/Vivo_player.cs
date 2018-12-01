using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Vivo : MonoBehaviour {
    public bool vivo;
   
	// Use this for initialization
	void Start () {
        vivo = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!vivo)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
