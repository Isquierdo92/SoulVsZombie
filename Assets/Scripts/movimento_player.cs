using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimento_player : MonoBehaviour {

    public float velocidade;
    public Rigidbody rg;
  
    public float jump;
    public  bool chao;
    public GameObject elevator;
    public bool teleporte;
    public bool recarregar;
    public bool chave;

    bool comeco = false;

    public float direcao;

    public Vector3 movimento;
    public float gravidade = 10;
    public Animator anim;
    public CharacterController cc;

    public AudioSource som;

    bool rotate = false;

    // Use this for initialization
    void Start () {
        //PEGA O RIGIDBODY DO PROPRIO OBJETO COMO REFERENCIA
        //rg = gameObject.GetComponent<Rigidbody>();
        //SETA O CHAO COMO TRUE, PARA TESTAR O PULO
        chao = true;
        recarregar = false;
        direcao = 1.0f;
        som = gameObject.GetComponentInChildren<AudioSource>();

        //SETAR O DRAG, QUANTO MAIOR O DRAG MAIOR A LENTIDÃO QUE O OBJETO RECEBE E NÃO DESLIZA
        //rg.GetComponent<Rigidbody>().drag = 1.5f;

        //SETA VELOCIDADE DE MOVIMENTO EM X
        velocidade = 7.0f;
        //FORCA PARA O PULO, TEM QUE SER ALTA
        jump = 33.0f;

        teleporte = false;
        anim = this.GetComponent<Animator>();

        cc = this.GetComponent<CharacterController>();
	}

    private void Update()
    {
        if(movimento.y < -5)
        {
            movimento.y = -5;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {




        if (cc.isGrounded)
        {

            chao = true;
        }
        else
        {
            movimento.y -= gravidade * Time.deltaTime;
            chao = false;

        }

        /*if (chao)
        {
            movimento.y += gravidade / 2 * Time.deltaTime;
        }
        else if (!chao)
        {
            movimento.y -= gravidade / 2 * Time.deltaTime;
        }*/


        movimento.x = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        
        cc.Move(movimento);
        


        //if (Input.GetKey("w"))
        //{
        //    //SE ESTIVER NO CHAO ELE PODE PULAR
        //     if (cc.isGrounded)
        //    {
        //        //ADICIONA A FORÇA EM Y PARA PULO
        //        // rg.AddForce(0.0f, jump * Time.deltaTime, 0.0f, ForceMode.Impulse);
        //        movimento.y -= gravidade / 2 * Time.deltaTime ;
        //     //   anim.SetInteger("condicao", 1);
        //        movimento.y += jump *Time.deltaTime;
        //       // chao = false;
        //    }

            
        //}

        //SE O Y DO OBJETO FOR MENOR QUE 1 O CHAO VIRA TRUE, ASSIM ELE PODERÁ PULAR
        //if (transform.position.y < 1)
        //    chao = true;
        ////CASO CONTRARIO ELE VIRARÁ FALSO E NÃO PODERÁ PULAR
        //else
        //{
        //    chao = false;
        //}
        //SE APERTOU "D" ELE ANDARÁ PARA A DIREITA
        if (Input.GetKeyDown("d"))
        {
            
            if (!som.isPlaying)
                som.Play();
           // anim.SetInteger("condicao", 2);
            // rg.AddForce(velocidade * Time.deltaTime, 0.0f, 0.0f, ForceMode.Force);

            if (rotate)
            {
                //this.transform.rotation = transform.Rotate(0.0f,00.0f,00.0f);
                this.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));// = new Quaternion( 0.0f); //89.982f
                rotate = false;
                //this.transform.eulerAngles(0.0f,90.0f,0.0f);
            }
            anim.SetInteger("Test", 2);
        } else
        //SE APERTOU A ANDA PARA A ESQUERDA
        if (Input.GetKeyDown("a"))
        {
            
            if (!som.isPlaying)
               som.Play();
            // anim.SetInteger("condicao", 3);
            //rg.AddForce(-velocidade * Time.deltaTime, 0.0f, 0.0f, ForceMode.Force);

            //this.transform.rotation = new Quaternion(0.0f, 268.758f, 0.0f, 0.0f);

            if (!rotate)
            {
                this.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));// = new Quaternion( 0.0f); //89.982f
                rotate = true;
            }
            anim.SetInteger("Test", 1);
        } else
            anim.SetInteger("condicao", 0);
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            som.Stop();
            anim.SetInteger("Test", 0);
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

    public void Zerou_vel(float x)
    {
        velocidade -= x * 5;
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
        if(other.name == "trigger")
        {
            GameObject.Find("inimigo").GetComponent<Enemy_follow>().vivo = true;
            GameObject.Find("player").GetComponent<Instanciar_pedaco>().comeco = true;
        }
        if (other.name == "Collider")
        {
            GameObject.Find("inimigo").GetComponent<Enemy_follow>().vivo = false;
            // GameObject.Find("player").GetComponent<Instanciar_pedaco>().comeco = true;
            Application.LoadLevel("Vitoria");
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

