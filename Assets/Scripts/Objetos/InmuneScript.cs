using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmuneScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().isInmune = true;
            Destroy(this.gameObject);
        }
    }
}
