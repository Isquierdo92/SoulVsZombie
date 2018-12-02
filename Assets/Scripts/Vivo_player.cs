using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Vivo_player : MonoBehaviour {
    public bool esta_vivo;
   
	// Use this for initialization
	void Start () {
        esta_vivo = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!esta_vivo)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Application.LoadLevel("Game Over");
            SceneManager.LoadScene("Game Over");
        }
	}
}
