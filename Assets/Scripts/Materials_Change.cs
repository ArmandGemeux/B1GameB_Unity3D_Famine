using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials_Change : MonoBehaviour {

    public List<Material> Oxygene;
    public List<Material> Carbon;
    public List<Material> Azote;
    public List<Material> Hydrogène;
   


    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.G))
        {
           gameObject.GetComponent<Renderer>().material = Oxygene[1];
           
        }
	}
}
