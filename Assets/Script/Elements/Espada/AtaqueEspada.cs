using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspada : MonoBehaviour
{
    int daño = 30;
    GameObject enemigo;
    private GameObject jugador;
    private Animator animacion;
    private Animator animacionEnemigo;


    private void Start()
    {   jugador = GameObject.FindGameObjectWithTag("Player");
        animacion = jugador.GetComponent<Animator>();
        enemigo = GameObject.FindGameObjectWithTag("Enemigo");
        animacionEnemigo = enemigo.GetComponent<Animator>();

    }

    private void Update()
    {
        Ataque();
    }
    private void OnColissionExit(Collider other)
    {
        if (other.transform.name == "Enemy")
        {
            enemigo = GameObject.FindGameObjectWithTag("Enemigo");
            enemigo.GetComponent<EnemigoBruto>().vidaEnemigo = enemigo.GetComponent<EnemigoBruto>().vidaEnemigo - daño;
            animacionEnemigo.SetBool("Daño",true);

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
