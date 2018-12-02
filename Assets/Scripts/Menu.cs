using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject dif;
    
    public GameObject b;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;

    bool ir = true;

	public void PlayGame()
    {
        //Application.LoadLevel("Jogo");
        if(ir)
        {
            b.transform.position += new Vector3(43.9499989f, 0, 0);
            b1.transform.position += new Vector3(43.9499989f, 0, 0);
            b2.transform.position += new Vector3(43.9499989f, 0, 0);
            b3.transform.position += new Vector3(43.9499989f, 0, 0);
            b4.transform.position += new Vector3(43.9499989f, 0, 0);
            ir = false;
        }
        else
        {
            b.transform.position  -= new Vector3(43.9499989f, 0, 0);
            b1.transform.position -= new Vector3(43.9499989f, 0, 0);
            b2.transform.position -= new Vector3(43.9499989f, 0, 0);
            b3.transform.position -= new Vector3(43.9499989f, 0, 0);
            b4.transform.position -= new Vector3(43.9499989f, 0, 0);
            ir = true;
        }
        
    }

    public void VeryEasy()
    {
        GameObject.Find("Dificuldade").GetComponent<ManyOrgao>().dif = 5;
        Application.LoadLevel("Jogo");
    }

    public void Easy()
    {
        GameObject.Find("Dificuldade").GetComponent<ManyOrgao>().dif = 4;
        Application.LoadLevel("Jogo");
    }

    public void Normal()
    {
        GameObject.Find("Dificuldade").GetComponent<ManyOrgao>().dif = 3;
        Application.LoadLevel("Jogo");
    }

    public void Hard()
    {
        GameObject.Find("Dificuldade").GetComponent<ManyOrgao>().dif = 2;
        Application.LoadLevel("Jogo");
    }

    public void VeryHard()
    {
        GameObject.Find("Dificuldade").GetComponent<ManyOrgao>().dif = 1;
        Application.LoadLevel("Jogo");
    }

    public void voltar()
    {
        Application.LoadLevel("Menu");
    }
    public void Creditos()
    {
        Application.LoadLevel("Creditos");
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}

