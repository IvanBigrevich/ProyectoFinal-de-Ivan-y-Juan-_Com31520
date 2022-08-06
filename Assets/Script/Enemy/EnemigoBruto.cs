using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBruto : Enemigo
{ 
    float timeAtack = 5f;
    float timeResetAtack;
    float tiempo = 10f;
    float tiempoPatrullaje;
    public Animator animacion;
    public Transform posJugador;

    public void Awake()
    {
        nombre = "Bruto";
        vidaEnemigo = 100;
        velocidadEnemigo = 8f;
    }
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
    {
        if (velocidadEnemigo >= 8)
        {
            transform.Translate(Vector3.forward * velocidadEnemigo * Time.deltaTime);
            animacion.SetBool("isRun", true);
        }
        else
        {
            transform.Translate(Vector3.forward * velocidadEnemigo * Time.deltaTime);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recorrido")
        {
            velocidadEnemigo = 0;
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
                velocidadEnemigo = 7f;
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
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador.position, velocidadEnemigo * Time.deltaTime);
            {
                if (distanciaJugador <= 4)
                {
                    velocidadEnemigo = 0;
                    animacion.SetBool("isRun", false);
                    AtackPlayer();
                }
                else
                {
                    velocidadEnemigo = 8f;
                    animacion.SetBool("isRun", true);
                }
            }
        }
        else { RutaEnemigo(); }
    }

    void AtackPlayer()
    {
        float ataqueRapido = 20f;
        timeResetAtack -= Time.deltaTime;

        if (timeResetAtack <= 0)
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

