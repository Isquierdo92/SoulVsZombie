using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento_player : MonoBehaviour {

    public float velocidade;
    public Rigidbody rg;
  
    public float jump;
    bool chao;
    public GameObject elevator;
    public bool teleporte;
    public bool recarregar;
    public bool chave;

    public Vector3 movimento;
    public float gravidade = 5;


    // Use this for initialization
    void Start () {
        //PEGA O RIGIDBODY DO PROPRIO OBJETO COMO REFERENCIA
        //rg = gameObject.GetComponent<Rigidbody>();
        //SETA O CHAO COMO TRUE, PARA TESTAR O PULO
        chao = true;
        recarregar = false;

        //SETAR O DRAG, QUANTO MAIOR O DRAG MAIOR A LENTIDÃO QUE O OBJETO RECEBE E NÃO DESLIZA
        //rg.GetComponent<Rigidbody>().drag = 1.5f;

        //SETA VELOCIDADE DE MOVIMENTO EM X
        velocidade = 7.0f;
        //FORCA PARA O PULO, TEM QUE SER ALTA
        jump = 1200.0f;

        teleporte = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (GetComponent<CharacterController>().isGrounded)
        {
            movimento.y = 0;//gravidade * Time.deltaTime;
            chao = true;
        }
        else
        {
            movimento.y -= gravidade/2 * Time.deltaTime/2;
        }

        movimento.x = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        GetComponent<CharacterController>().Move(movimento);


        if (Input.GetKey("w"))
        {
            //SE ESTIVER NO CHAO ELE PODE PULAR
            if (chao == true)
            {
                //ADICIONA A FORÇA EM Y PARA PULO
                // rg.AddForce(0.0f, jump * Time.deltaTime, 0.0f, ForceMode.Impulse);
                movimento.y += 0.32525f;
            }
            
        }
        
        //SE O Y DO OBJETO FOR MENOR QUE 1 O CHAO VIRA TRUE, ASSIM ELE PODERÁ PULAR
        if (transform.position.y < 1)
            chao = true;
        //CASO CONTRARIO ELE VIRARÁ FALSO E NÃO PODERÁ PULAR
        else
        {
            chao = false;
        }
        //SE APERTOU "D" ELE ANDARÁ PARA A DIREITA
        if (Input.GetKey("d"))
        {
           // rg.AddForce(velocidade * Time.deltaTime, 0.0f, 0.0f, ForceMode.Force);
        }
        //SE APERTOU A ANDA PARA A ESQUERDA
        if(Input.GetKey("a"))
        {
            //rg.AddForce(-velocidade * Time.deltaTime, 0.0f, 0.0f, ForceMode.Force);
        }

        if (teleporte)
        {
            Teleportar();
        }

        if (recarregar)
        {
            Carregar_orgaos();
        }
    }

    public void Carregar_orgaos()
    {
        Debug.Log("pode ativar");
        if (Input.GetKeyUp("x"))
        {
            gameObject.GetComponent<Instanciar_pedaco>().cont = 0;
            gameObject.GetComponent<Instanciar_pedaco>().Iniciar_array();
            
        }
    }

    public void AumentarVel(float x)
    {
        velocidade += x;
        
    }

    public void AumentarPulo(float x)
    {
        jump += x;
    }

    public void Elevador(float x, float y)
    {
        transform.position = new Vector3(x, y, 0.0f);

    }

    public void Teleportar()
    {
        if (Input.GetKeyUp("s")) 
        elevator.GetComponent<Prox_elevator>().Prox();
        
    }


    public void Pegar_chave(GameObject x)
    {
        Destroy(x);
        chave = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "elevador")
        { 
           elevator = GameObject.Find(other.name);
            teleporte = true;            
        }
       if(other.name == "frigorifico")
        {
            recarregar = true;
        }
       if(other.name == "chave")
        {
            GameObject key = GameObject.Find(other.name);
            Pegar_chave(key);
        }
        if(other.name == "inimigo")
        {
            gameObject.GetComponent<Vivo_player>().esta_vivo = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "elevador") {
            elevator = null;
            teleporte = false;
        }
        if (other.name == "frigorifico")
            recarregar = false;
    }
}

