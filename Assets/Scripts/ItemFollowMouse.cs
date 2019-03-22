using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowMouse : MonoBehaviour {

    private bool doOnce = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && doOnce == false)
        {
            var mPos = Input.mousePosition;
            mPos.z = 10f;
            mPos = Camera.main.ScreenToWorldPoint(mPos);
            transform.position = mPos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("C'est fini maintenant!");
            doOnce = true;
            GetComponent<MouvementController>().moving = true;
        }
	}
}
