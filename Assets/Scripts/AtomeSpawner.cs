using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomeSpawner : MonoBehaviour {


    public GameObject atome;
    public GameObject atome3D;
    Vector3 posM;
    //public RectTransform panelRectTransfom;

    // Use this for initialization
    void Start () {
        AtomeNumber();
        posM = Input.mousePosition;
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void AtomeNumber()
    {
        int atomeNumber = Random.Range(0, 4);
        Debug.Log(atomeNumber);
        Instantiate(atome, transform);
    }

   

    public void OnMouseExit()
    {
        Instantiate(atome3D, posM, Quaternion.identity);
        atome.transform.position = transform.position;
        
    }

    public void OnMouseOver()
    {
        Vector3 posM = Input.mousePosition;
        atome.transform.position = posM;
    }

}

/*  
     -	Créer une fonction qui choisi une valeur parmi 4 possibles et ce aléatoirement.
    -	Les 4 valeurs correspondent à l’identifiant des préfabs d’atomes.
    -	Instancier l’atome correspondant à l’identifiant ressortant.
    -	L’atome est instancié à la position de la box auquel est attaché ce script.     
     */