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
            //gameObject.SetActive(false);  //Problema: O som n�o tocar� se n�o esperarmos

            //Modo 2: Desativar o visual e a colis�o
            //Problema: Quanto mais coisas quisermos desativar, mais dif�cil ficar�
            boxCollider.enabled = false;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
