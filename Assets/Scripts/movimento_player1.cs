using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento_player1 : MonoBehaviour
{

    public float velocidade;
    public Rigidbody rg;
    public float jump;
    public bool chao;
    public GameObject elevator;
    public bool teleporte;
    public bool recarregar;
    public bool chave;
    public bool pode_pular;
    public Animator animc;


    // Use this for initialization
    void Start()
    {

        animc = this.gameObject.GetComponent<Animator>();
        //PEGA O RIGIDBODY DO PROPRIO OBJETO COMO REFERENCIA
        rg = gameObject.GetComponent<Rigidbody>();
        //SETA O CHAO COMO TRUE, PARA TESTAR O PULO
        chao = true;
        recarregar = false;

        //SETAR O DRAG, QUANTO MAIOR O DRAG MAIOR A LENTIDÃO QUE O OBJETO RECEBE E NÃO DESLIZA
        rg.GetComponent<Rigidbody>().drag = 1.5f;

        //SETA VELOCIDADE DE MOVIMENTO EM X
        velocidade = 1000.0f;
        //FORCA PARA O PULO, TEM QUE SER ALTA
        jump = 1200.0f;

        teleporte = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        if (pode_pular)
        {
            chao = true;
            Physics.gravity = new Vector3(0.0f, -10.0f, 0.0f);
        }
        else
        {
            chao = false;
        }

        if (Input.GetKeyDown("w"))
        {
            animc.SetInteger("condicao", 1);
            //SE ESTIVER NO CHAO ELE PODE PULAR
            if (chao == true)
            {

                pode_pular = false;
                Physics.gravity = new Vector3(0.0f, -20.0f, 0.0f);
                //ADICIONA A FORÇA EM Y PARA PULO
                rg.AddForce(0.0f, jump * Time.deltaTime, 0.0f, ForceMode.Impulse);
            }

        }

        //SE O Y DO OBJETO FOR MENOR QUE 1 O CHAO VIRA TRUE, ASSIM ELE PODERÁ PULAR

        //SE APERTOU "D" ELE ANDARÁ PARA A DIREITA
        if (Input.GetKey("d"))
        {
            rg.AddForce(velocidade * Time.deltaTime, 0.0f, 0.0f);
        }
        //SE APERTOU A ANDA PARA A ESQUERDA
        if (Input.GetKey("a"))
        {
            rg.AddForce(-velocidade * Time.deltaTime, 0.0f, 0.0f);
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
        if (Input.GetKeyDown("s"))
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
        if (other.name == "frigorifico")
        {
            recarregar = true;
        }
        if (other.name == "chave")
        {
            GameObject key = GameObject.Find(other.name);
            Pegar_chave(key);
        }
        if (other.name == "inimigo")
        {
            gameObject.GetComponent<Vivo_player>().esta_vivo = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "elevador")
        {
            elevator = null;
            teleporte = false;
        }
        if (other.name == "frigorifico")
            recarregar = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "chao")
        {
            pode_pular = true;
        }

    }
}




////PARA AUMENTAR A GRAVIDADE E MELHORAR O PULO
//public float fallmultiplier = 2.5f;
//public float lowjump_multiplier = 2.0f;
//if(rg.velocity.y < 0)
//{
//    rg.velocity += Vector3.up * Physics.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
//}
//if(rg.velocity.y>0 && !Input.GetKey("w"))
//{
//    rg.velocity += Vector3.up * Physics.gravity.y * (lowjump_multiplier - 1) * Time.deltaTime;
//}