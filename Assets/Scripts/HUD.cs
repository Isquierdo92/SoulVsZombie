using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public GameObject jogador;
    public Text texto;
    int x;

	// Use this for initialization
	void Start () {
        jogador = GameObject.Find("player");
        
	}
	
	// Update is called once per frame
	void Update () {
        x = jogador.GetComponent<Instanciar_pedaco>().org -jogador.GetComponent<Instanciar_pedaco>().cont;
        texto.text = "orgãos: " + x/*jogador.GetComponent<Instanciar_pedaco>().cont*/;
	}
}
