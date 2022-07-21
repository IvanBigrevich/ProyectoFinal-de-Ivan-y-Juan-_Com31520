using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{   
    float timeAtack = 5f;
    float timeResetAtack;
    float tiempo = 10f;
    float tiempoPatrullaje;
    private float enemySpeed = 8f;
    public Animator animacion;
    public Transform posJugador;

    // Start is called before the first frame update
    void Start()
    {
        ResetAtack();
        RutaEnemigo();
        ResetearTiempoPatrulla();
    }

    // Update is called once per frame
    void Update()
    {
        PerseguirJugador();
    }
    void RutaEnemigo()
    { if(enemySpeed >=8)
        {
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
            animacion.SetBool("isRun", true);
        }
        else
        {
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);

        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recorrido")
        {
            enemySpeed = 0;
            animacion.SetBool("isRun", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            tiempoPatrullaje -= Time.deltaTime;
            if (tiempoPatrullaje <= 7)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                animacion.SetBool("isRun", true);
                ResetearTiempoPatrulla();
                enemySpeed = 7f;
            }
        }
    }
    void ResetearTiempoPatrulla()
    {
        tiempoPatrullaje = tiempo;
    }
    void PerseguirJugador()
    {
        float distanciaJugador = Vector3.Distance(transform.position, posJugador.position);

        if (distanciaJugador <= 15)
        {
            transform.position = Vector3.MoveTowards(transform.position, posJugador.position, enemySpeed * Time.deltaTime);
            {
                if (distanciaJugador <= 4)
                {
                    enemySpeed = 0;
                    animacion.SetBool("isRun", false);
                    AtackPlayer();
                    }
            }
        }
        else { RutaEnemigo(); }
         
    }

         void AtackPlayer()
    {
        int ataqueRapido = 20;
        int ataqueFuerte = 30;
        timeResetAtack -= Time.deltaTime;

        if(timeResetAtack <= 0)
        {
            MovJugador.playerLife = MovJugador.playerLife - ataqueRapido;
            ResetAtack();
            Debug.Log("Tu salud es de " + MovJugador.playerLife);
        }
        
    }

    void ResetAtack()
    {
         timeResetAtack = timeAtack;
    }
}
    
