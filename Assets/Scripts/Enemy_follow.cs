using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_follow : MonoBehaviour {

    public GameObject pers;

    enum status { seguiplay, seguipiece, comepiece, preso };



    int estado;

    //3 status
    //seguindo player
    //seguindo pedaço
    //consumindo pedaço
    //preso

	// Use this for initialization
	void Start () {
        //pers = GameObject.Find
        // estado = seguiplay;
        estado = 0;
    }
	
	// Update is called once per frame
	void Update () {

        switch (estado)
        {
            //seguir player
            case 0:
                {
                   estado = FollowPlayer(estado);
                }
                break;
            //seguir pedaço
            case 1:
                {
                   // estado = FollowPlayer(estado);
                }
                break;
            //comendo
            case 2:
                {

                }
                break;
            //morto
            case 3:
                {

                }
                break;


        }
    }

    int FollowPlayer(int estado)
    {
        transform.LookAt(pers.transform.position);
        //zerar angulos nao desejados
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        //andar para frente
        transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime));

        return estado;
    }

    int FollowPiece(int estado)
    {
        return estado;
    }

    int EatPiece(int estado)
    {
        return estado;
    }

    int Dead(int estado)
    {
        return estado;
    }

    void Colidiu()
    {

    }
}
