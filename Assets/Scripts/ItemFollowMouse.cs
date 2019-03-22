using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            var mPos = Input.mousePosition;
            mPos.z = 10f;
            mPos = Camera.main.ScreenToWorldPoint(mPos);
            transform.position = mPos;
        }
	}
}
