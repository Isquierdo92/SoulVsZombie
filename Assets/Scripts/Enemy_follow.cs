using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_follow : MonoBehaviour {

    public GameObject pers; // game object do playes
    public GameObject pie; // pedaço

    enum status { seguiplay, seguipiece, comepiece, preso }; // enum q não to usando pq deu ruim sla


    public float vel = 1; // pra testar a velocidade do fantasma
    public int estado; // oq ele vai fazer agora

    public float distancia_piece; // distancia para o pedaço

    bool Comido = false;

    float Tempo =0; // tempo de comer
    public float TempoComendo = 5;

    //3 status
    //seguindo player
    //seguindo pedaço
    //consumindo pedaço
    //preso

    // Use this for initialization
    void Start () {
        //pers = GameObject.Find
        // estado = seguiplay;
        estado = 0; // começa seguindo o player
    }
	
	// Update is called once per frame
	void Update () {

        //pegar a distancia pro pedaço
        if (pie != null)
        distancia_piece = Vector3.Distance(transform.position, pie.GetComponent<Transform>().position);

        Test();//tirar isso depois

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
                    estado = FollowPiece(estado,pie);
                }
                break;
            //comendo
            case 2:
                {
                    //if(!Comido) //pie.
                    if(pie != null)
                    estado = EatPiece(estado);
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
        transform.Translate(new Vector3(0, 0, vel * Time.deltaTime));

        return estado;
    }

    int FollowPiece(int estado,GameObject p)
    {
        //pie = p; descomentar isso depoooois

       
        if(pie != null)
        {
            transform.LookAt(pie.transform.position);// olha pro cara
                                                     //zerar angulos nao desejados
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            //andar para frente
            transform.Translate(new Vector3(0, 0, vel * Time.deltaTime));
        }
       

        Comido = false;

        if (distancia_piece < 1)//tá perto comendo
        {
            estado = 2;//foi comer
        }

        return estado;
    }

    int EatPiece(int estad)
    {
        //Debug.Log("funfou caraioo");
        Tempo += Time.deltaTime;
       

        if (Tempo > TempoComendo)
        {
            estad = 0;
            Comido = true;
            if (pie != null)
            Destroy(pie);
           
        }

        return estad;
    }

    int Dead(int estado)
    {
        return estado;
    }

    void Colidiu()
    {

    }

    void SetEstado(int est)
    {
        estado = est;
    }

    void Test()
    {
        if(Input.GetKey("a"))
        {
            estado = 1;
        }
        else if (Input.GetKey("b"))
        {
            estado = 0;
        }
    }
}
