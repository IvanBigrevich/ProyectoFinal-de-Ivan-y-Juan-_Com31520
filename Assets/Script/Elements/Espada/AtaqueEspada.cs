using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspada : MonoBehaviour
{
    int daño = 30;
    GameObject enemigo;
    private GameObject jugador;
    private Animator animacion;

    private void Start()
    { jugador = GameObject.FindGameObjectWithTag("Player");
        animacion = jugador.GetComponent<Animator>();
    }

    private void Update()
    {
        Ataque();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Enemy")
        {
            enemigo = GameObject.FindGameObjectWithTag("Enemigo");
            enemigo.GetComponent<EnemigoBruto>().vidaEnemigo = enemigo.GetComponent<EnemigoBruto>().vidaEnemigo - daño;
            Debug.Log("esto fucniona");
        }
    }

    void Ataque()
    {
        if (Input.GetMouseButton(0))
        {
            animacion.SetBool("atackSword", true);
        }
    }
}
