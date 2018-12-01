using UnityEngine;
using System.Collections;

public class Instanciar_pedaco : MonoBehaviour {

    public GameObject coracao;
    public GameObject pulmao;
    public GameObject figado;
    public GameObject rim;
    public GameObject intestino;
    public GameObject jogador;

    public GameObject Fantasma;

    public int cont;
    public bool desprender;

    public float mudar_vel;
    public float mudar_pulo;


    //ARRAY PARA INSTANTIATE
    public GameObject[] array_orgaos;

	// Use this for initialization
	void Start () {

        Fantasma = GameObject.Find("inimigo");

        cont = 0;
        desprender = true;
        array_orgaos = new GameObject[5];

        rim = GameObject.Find("piece");
        figado = GameObject.Find("piece (1)");
        pulmao = GameObject.Find("piece (2)");
        intestino = GameObject.Find("piece (3)");
        coracao = GameObject.Find("piece (4)");
        jogador = GameObject.Find("player");
        Iniciar_array();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            Debug.Log("ativou");
            Debug.Log(cont.ToString());

            if (desprender)
            {
                array_orgaos[cont].GetComponent<orgao>().enabled = false;
                Fantasma.GetComponent<Enemy_follow>().SetPieces(array_orgaos[cont], cont);
                array_orgaos[cont] = null;
                cont++;
            }
        }
        if(cont >= 5)
        {
            desprender = false;
        }
        if (cont < 5)
            desprender = true;
      
    }

    public void Iniciar_array()
    {
        
        array_orgaos[0] = Instantiate(GameObject.Find("piece"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
        
        array_orgaos[1] = Instantiate(GameObject.Find("piece (1)"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
        
        array_orgaos[2] = Instantiate(GameObject.Find("piece (2)"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
       
        array_orgaos[3] = Instantiate(GameObject.Find("piece (3)"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
        
        array_orgaos[4] = Instantiate(GameObject.Find("piece (4)"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
       
    }
    //DESATIVA SCRIPTS DOS PREFABS
    public void Desativar_script()
    {
        pulmao.GetComponent<orgao>().enabled = false;
        rim.GetComponent<orgao>().enabled = false;
        figado.GetComponent<orgao>().enabled = false;
        intestino.GetComponent<orgao>().enabled = false;
        coracao.GetComponent<orgao>().enabled = false;
    }
}


                //    if(cont == 0)
                //    {
                //        rim.GetComponent<orgao>().enabled = false;
                //    }
                //    if(cont == 1)
                //    {
                //        figado.GetComponent<orgao>().enabled = false;
                //    }
                //    if(cont == 2)
                //    {
                //        pulmao.GetComponent<orgao>().enabled = false;
                //    }
                //    if(cont == 3)
                //    {
                //        intestino.GetComponent<orgao>().enabled = false;
                //    }
                //    if(cont == 4)
                //    {
                //        coracao.GetComponent<orgao>().enabled = false;
                //    }
                //    jogador.GetComponent<movimento_player>().AumentarVel(mudar_vel);
                //    jogador.GetComponent<movimento_player>().AumentarPulo(mudar_pulo);
                //    cont++;
                //}