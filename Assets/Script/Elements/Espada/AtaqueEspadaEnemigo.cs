using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspadaEnemigo : MonoBehaviour
{
    public EnemigoBruto ataque;
    private GameObject jugador;
    private Animator animacion;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        animacion = jugador.GetComponent<Animator>();
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            ataque.AtackPlayer();
            animacion.SetBool("recibioImpacto", true);
        }
    }
}
