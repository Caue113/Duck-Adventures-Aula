using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rigidBody;

    //Modelo 3D do personagem
    public GameObject modeloPato;

    //Movimentação do personagem
    public float forcaAndar = 6f;
    public float forcaPulo = 8f;

    bool estaChao = true;

    //Bandeira para teletransportar personagem
    public GameObject BandeiraReviver;

    void Start()
    { 
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Mover o pato
        rigidBody.velocity = new Vector3(forcaAndar * Input.GetAxis("Horizontal"), rigidBody.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && estaChao == true) 
        {
            estaChao = false;
            rigidBody.AddForce(0, forcaPulo, 0, ForceMode.Impulse);
        }

        //Girar pato para onde olha
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            modeloPato.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            modeloPato.transform.localRotation = Quaternion.Euler(0, 270, 0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Se enconstar em inimigo, teletransportar para inicio da fase
        if(collision.collider.gameObject.CompareTag("Enemy"))
        {
            transform.position = BandeiraReviver.transform.position;
        }
        else if (collision.collider.gameObject.layer == 6)  //A camada na colisão traz um número, e não seu nome
        {
            estaChao = true;
        }
    }
}
