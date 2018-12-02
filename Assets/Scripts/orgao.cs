using UnityEngine;

public class orgao : MonoBehaviour {
    public GameObject seguir;
    public float rotacao;
    
    // Use this for initialization
    void Start () {
        seguir = GameObject.Find("player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = seguir.GetComponent<Transform>().position;
        
        
    }

  
}
