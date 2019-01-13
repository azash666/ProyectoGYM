using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Objetivo : MonoBehaviour
{
    public GameObject siguiente;
    public bool final;
    public RawImage imagenVctoria;
    public Text texto;
    // Use this for initialization

    private void Start()
    {
        imagenVctoria.enabled = false;
        texto.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            if (final)
            {
                Victory();
            }else
                other.GetComponent<rotadorSenal>().objetivo = siguiente;
        }
    }

    void Victory()
    {
        // Set the death flag so this function won't be called again.
        imagenVctoria.enabled = true;
        texto.enabled = true;

        // Reproducimos el sonido de la muerte
        StartCoroutine(LoadLevelAfterDelay(5));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("menu");
    }
}
