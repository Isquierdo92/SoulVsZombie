using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir_player : MonoBehaviour {
    //ESSA VARIÁVEL É PARA DEIXAR A CAMERA NA POSICAO CERTA EM Z, E NÃO FICAR EM CIMA DO PLAYER
    Vector3 posicao;
    //PEGA A REFERENCIA DO PLAYER
    GameObject seguir;
	// Use this for initialization
	void Start () {
        //REFERENCIA DO PLAYER
        seguir = GameObject.Find("player");
        //SETANDO O Z
        posicao = new Vector3(0.0f, 5.0f, -30.0f);
	}
	
	// Update is called once per frame
	void Update () {
        //SETA A CAMERA NA POSICAO DO PLAYER, -20F EM Z PARA ELA FILMAR ELE
        transform.position = seguir.GetComponent<Transform>().position + posicao;
	}
}
