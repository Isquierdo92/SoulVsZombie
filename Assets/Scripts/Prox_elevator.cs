using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prox_elevator : MonoBehaviour {

    public float x_prox_elevador;
    public float y_prox_elevador;
    public GameObject jogador;
    public GameObject Outro_elevador;
	// Use this for initialization
	void Start ()
    {
        //PEGA A REFERENCIA DO PLAYER
        jogador = GameObject.Find("player");
	}
	

    public void Prox()
    {
        x_prox_elevador = Outro_elevador.GetComponent<Transform>().position.x;
        y_prox_elevador = Outro_elevador.GetComponent<Transform>().position.y;
        //PEGA AS POSICOES DO PROX ELEVADOR E SETA NO PLAYER
        jogador.GetComponent<movimento_player>().Elevador(x_prox_elevador, y_prox_elevador);
        Debug.Log(x_prox_elevador + "  "  +"   " + y_prox_elevador);
    }

}
