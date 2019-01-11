using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScript : MonoBehaviour {

    SphereManager sm;
    

    public void Awake()
    {
        sm = GameObject.Find("SphereManager").GetComponent<SphereManager>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Entorno")
        {
            sm.tocaAmbiente(2);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            other.GetComponent<SimpleCharacterControl>().isSpeed = true;
            sm.numEsferas[2] = 0;
            Destroy(this.gameObject);
        }
    }
}