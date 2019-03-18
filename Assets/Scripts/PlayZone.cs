using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        GameManager.s_Singleton.DisplayItem();
    }

    private void OnMouseExit()
    {
        GameManager.s_Singleton.HideItem();
    }
}
