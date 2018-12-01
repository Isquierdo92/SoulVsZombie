using UnityEngine;

public class movimento_player : MonoBehaviour {

    public float velocidade;
    public Rigidbody rg;
    public float jump;
    bool chao;
	// Use this for initialization
	void Start () {
        //PEGA O RIGIDBODY DO PROPRIO OBJETO COMO REFERENCIA
        rg = gameObject.GetComponent<Rigidbody>();
        //SETA O CHAO COMO TRUE, PARA TESTAR O PULO
        chao = true;
        //SETA VELOCIDADE DE MOVIMENTO EM X
        velocidade = 20.0f;
        //FORCA PARA O PULO, TEM QUE SER ALTA
        jump = 1000.0f;
	}
	
	// Update is called once per frame
	void Update () {
       
        
        if (Input.GetKey("w"))
        {
            //SE ESTIVER NO CHAO ELE PODE PULAR
            if (chao == true)
            {
                //ADICIONA A FORÇA EM Y PARA PULO
                rg.AddForce(0.0f, jump * Time.deltaTime, 0.0f, ForceMode.Force);
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
            rg.AddForce(velocidade * Time.deltaTime, 0.0f, 0.0f, ForceMode.VelocityChange);
        }
        //SE APERTOU A ANDA PARA A ESQUERDA
        if(Input.GetKey("a"))
        {
            rg.AddForce(-velocidade * Time.deltaTime, 0.0f, 0.0f, ForceMode.VelocityChange);
        }

        
	}
}
