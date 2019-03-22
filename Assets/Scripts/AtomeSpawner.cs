using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomeSpawner : MonoBehaviour {
    
    Vector3 posM = Vector3.zero;
    int atomeNumber;


    public List<GameObject> atomeSpriteList;
    public List<GameObject> atome3DList;

    bool atomeCheck;

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
        atomeNumber = Random.Range(0, 4);
        Debug.Log(atomeNumber);
        Instantiate(atomeSpriteList[atomeNumber], GetComponentInChildren<Transform>());
    }

   

    public void OnMouseExit()
    {
        Instantiate(atome3DList[atomeNumber], posM, Quaternion.identity);
        atomeSpriteList[atomeNumber].transform.position = transform.position;
        
    }

    public void OnMouseOver()
    {
        
        Vector3 posM = Input.mousePosition;
        atomeSpriteList[atomeNumber].transform.position = posM;
    }

    



}

/*  
     -	Créer une fonction qui choisi une valeur parmi 4 possibles et ce aléatoirement.
    -	Les 4 valeurs correspondent à l’identifiant des préfabs d’atomes.
    -	Instancier l’atome correspondant à l’identifiant ressortant.
    -	L’atome est instancié à la position de la box auquel est attaché ce script.     
     */