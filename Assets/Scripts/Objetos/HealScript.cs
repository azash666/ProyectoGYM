using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour {

    SphereManager sm;
    PlayerHealth heal;

    public void Awake()
    {
        sm = GameObject.Find("SphereManager").GetComponent<SphereManager>();
        heal = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Entorno")
        {
            sm.tocaAmbiente(1);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            heal.isHeal = true;
            sm.numEsferas[1] = 0;
            Destroy(this.gameObject);
        }
    }
}