using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementController : MonoBehaviour
{
    // Déclaration des variables
    public float hitDistance;
    private bool lockAtome = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Activation du raycast
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        { 

            Transform objectHit = hit.transform;

            // Déplacement de l'atome sur le curseur
            if (Input.GetMouseButton(0))
            {
                lockAtome = true;
            }
            else
            {
                lockAtome = false;
            }
        }

        if(lockAtome == true)
        {
            AtomeMove();
        }
    }

    void AtomeMove()
    {
        var v3 = Input.mousePosition;
        v3.z = 10f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        transform.position = v3;
    }
}
