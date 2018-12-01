using UnityEngine;
using System.Collections;

public class Instanciar_pedaco : MonoBehaviour {

    public GameObject coracao;
    public GameObject pulmao;
    public GameObject figado;
    public GameObject rim;
    public GameObject intestino;
    public int cont;
    public bool desprender;
    
	// Use this for initialization
	void Start () {
        cont = 0;
        desprender = true;
        coracao = GameObject.Find("coracao");
        pulmao = GameObject.Find("pulmao");
        figado = GameObject.Find("figado");
        rim = GameObject.Find("rim");
        intestino = GameObject.Find("intestino");
    
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
                if(cont == 0)
                {
                    rim.GetComponent<orgao>().enabled = false;
                }
                if(cont == 1)
                {
                    figado.GetComponent<orgao>().enabled = false;
                }
                if(cont == 2)
                {
                    pulmao.GetComponent<orgao>().enabled = false;
                }
                if(cont == 3)
                {
                    intestino.GetComponent<orgao>().enabled = false;
                }
                if(cont == 4)
                {
                    coracao.GetComponent<orgao>().enabled = false;
                }
                cont++;
            }
        }
        if(cont >= 5)
        {
            desprender = false;
        }
    }
}
