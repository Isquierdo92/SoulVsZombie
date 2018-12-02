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

    public bool comeco;

    public int org = 5;
    


    //ARRAY PARA INSTANTIATE
    public GameObject[] array_orgaos;

    private void Awake()
    {
        array_orgaos = new GameObject[5];

        org = GameObject.Find("Dificuldade").GetComponent<ManyOrgao>().dif;

        rim = GameObject.Find("piece");
        figado = GameObject.Find("piece (1)");
        pulmao = GameObject.Find("piece (2)");
        intestino = GameObject.Find("piece (3)");
        coracao = GameObject.Find("piece (4)");
        Desativar_script();
    }

    // Use this for initialization
    void Start () {

        Fantasma = GameObject.Find("inimigo");

        cont = 0;
        desprender = true;
        
        jogador = GameObject.Find("player");
        Iniciar_array();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(comeco)
        {
            if (Input.GetKeyUp("space"))
            {
                Debug.Log("ativou");
                Debug.Log(cont.ToString());

                if (desprender)
                {
                    array_orgaos[cont].GetComponent<orgao>().enabled = false;
                    array_orgaos[cont].GetComponent<MeshRenderer>().enabled = true;
                    array_orgaos[cont].transform.position += new Vector3(0.0f, 2.5f, 0.0f);
                    Fantasma.GetComponent<Enemy_follow>().SetPieces(array_orgaos[cont], cont);
                    array_orgaos[cont] = null;
                    cont++;
                    jogador.GetComponent<movimento_player>().AumentarVel(mudar_vel);
                }
            }
            if (cont >= org)
            {
                desprender = false;
            }
            if (cont < org)
                desprender = true;
        }
       
      
    }

    public void Iniciar_array()
    {
        
        array_orgaos[0] = Instantiate(GameObject.Find("piece"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
        array_orgaos[0].GetComponent<MeshRenderer>().enabled = false;
        array_orgaos[1] = Instantiate(GameObject.Find("piece (1)"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
        array_orgaos[1].GetComponent<MeshRenderer>().enabled = false;
        array_orgaos[2] = Instantiate(GameObject.Find("piece (2)"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
        array_orgaos[2].GetComponent<MeshRenderer>().enabled = false;
        array_orgaos[3] = Instantiate(GameObject.Find("piece (3)"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
        array_orgaos[3].GetComponent<MeshRenderer>().enabled = false;
        array_orgaos[4] = Instantiate(GameObject.Find("piece (4)"), jogador.GetComponent<Transform>().position, jogador.GetComponent<Transform>().rotation);
        array_orgaos[4].GetComponent<MeshRenderer>().enabled = false;
    }
    //DESATIVA SCRIPTS DOS PREFABS
    public void Desativar_script()
    {
        
        pulmao.GetComponent<MeshRenderer>().enabled = false;
        
        rim.GetComponent<MeshRenderer>().enabled = false;
       
        figado.GetComponent<MeshRenderer>().enabled = false;
        
        intestino.GetComponent<MeshRenderer>().enabled = false;
        
        coracao.GetComponent<MeshRenderer>().enabled = false;
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