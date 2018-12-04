using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmuneScript : MonoBehaviour {

    float time = 10.0f;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        time -= Time.deltaTime;

        while (time != 0.0)
        {
            
        }

    }
}
