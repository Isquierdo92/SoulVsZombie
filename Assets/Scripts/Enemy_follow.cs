using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_follow : MonoBehaviour {

    public GameObject pers; // game object do playes


    public GameObject pie; // pedaço
    public GameObject pie1; // pedaço
    public GameObject pie2; // pedaço
    public GameObject pie3; // pedaço
    public GameObject pie4; // pedaço
    public GameObject pie5;

   // enum status { seguiplay, seguipiece, comepiece, preso }; // enum q não to usando pq deu ruim sla


    public float vel = 1; // pra testar a velocidade do fantasma
    public int estado; // oq ele vai fazer agora

    public float distancia_piece; // distancia para o pedaço

    bool Comido = false,test = true;

    float Tempo =0; // tempo de comer
    public float TempoComendo = 5;

    public GameObject testar;

    public GameObject[] pieces;// = new GameObject [5];

    bool PodePega = true;//testa se pode pegar o cara da fila

    //3 status
    //seguindo player
    //seguindo pedaço
    //consumindo pedaço
    //preso

    int ke =0;

    

    // Use this for initialization
    void Start () {
        //pers = GameObject.Find
        // estado = seguiplay;
        estado = 1; // começa seguindo o player
                    // pie = null;

        //só pra testar a fila

        pieces = new GameObject[5];
        pieces[0] = pie1;
        pieces[1] = pie2;
        pieces[2] = pie3;
        pieces[3] = pie4;
        pieces[4] = pie5;
               
    }



    private void FixedUpdate()
    {
        //pegar a distancia pro pedaço
        if (pie != null)
        {
            distancia_piece = Vector3.Distance(transform.position, pie.GetComponent<Transform>().position);//talvez aaui problema
        }

    }
    // Update is called once per frame
    void Update () {

        

        Test();//tirar isso depois

        TemPedaco();


        switch (estado)
        {

            //seguir player
            case 0:
                {

                    print("follow player");
                    estado = FollowPlayer(estado);
                }
                break;
            //seguir pedaço
            case 1:
                {
                    print("follow piece");
                    estado = FollowPiece(estado,pie);
                }
                break;
            //comendo
            case 2:
                {
                    print("eat piece");
                    //if(!Comido) //pie.
                    if (pie != null)
                    {
                        FollowPiece(estado, pie);
                    }
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
       // pieces.Enqueue(p);
       
        if(pie != null)
        {
            transform.LookAt(pie.transform.position);// olha pro cara
                                                     //zerar angulos nao desejados
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            //andar para frente
            //transform.Translate(new Vector3(0, 0, vel * Time.deltaTime));
            transform.position = Vector3.MoveTowards(transform.position, pie.transform.position, vel * Time.deltaTime);

        }


        // Comido = false;

        if (distancia_piece < 1)//tá perto comendo
        {
            print("Distancia" + distancia_piece);
            EatPiece(2);
        }

        return estado;
    }

    void SetPieces(GameObject p,int tipo)
    {
        pieces[tipo] = p;
    }

    void EatPiece(int estad)
    {
        //Debug.Log("funfou caraioo");
        Tempo += Time.deltaTime;

        if (Tempo > TempoComendo)
        {
            print("Tempo: " + Tempo);
            print("Tempo comendo: " + TempoComendo);

            estado = 0;

            // Comido = true;
            if (pie != null)
            {
                Destroy(pie);
                PodePega = true;
            }
            Tempo = 0;

        }
        
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
           
            if(pieces[ke] != null)
            {
                pie = pieces[ke];
            }
            
            ke++;

        }
        else if (Input.GetKey("b"))
        {
            estado = 0;
        }
    }

    void TemPedaco()
    {
        if(PodePega)
        {
            for(int i =0;i <5; i++)
            {
                if (pieces[i] != null)
                {
                    //Debug.Log("oq diabos happing"+ i);
                    pie = pieces[i];
                    pie.transform.position = pieces[i].transform.position;
                    PodePega = false;
                    estado = 1;//perseguir pedaco
                    break;
                }
            }
           
        }
    }
}
