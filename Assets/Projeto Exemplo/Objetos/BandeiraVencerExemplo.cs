using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjetoTutorial
{
    public class BandeiraVencerExemplo : MonoBehaviour
    {
        public string proximaFase;
        AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                audioSource.Play();
                StartCoroutine(CarregarProximaFase());

                //Carregar a fase direto. Por�m o som n�o tocar�
                //SceneManager.LoadScene(proximaFase);  
            }
        }

        //Fun��o para esperar um tempo e depois carregar a proxima fase
        private IEnumerator CarregarProximaFase()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(proximaFase);
        }
    }
}