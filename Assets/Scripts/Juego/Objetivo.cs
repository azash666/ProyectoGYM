using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
    public GameObject siguiente;
    public bool final;
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            if (final)
            {
                Debug.Log("Fin");
            }else
                other.GetComponent<rotadorSenal>().objetivo = siguiente;
        }
    }
}
