using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrela : MonoBehaviour
{
    
    BoxCollider boxCollider;
    AudioSource audioSource;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.Play();


            //Modo 1: desativar objeto direto
            //gameObject.SetActive(false);  //Problema: O som não tocará se não esperarmos

            //Modo 2: Desativar o visual e a colisão
            //Problema: Quanto mais coisas quisermos desativar, mais difícil ficará
            boxCollider.enabled = false;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
