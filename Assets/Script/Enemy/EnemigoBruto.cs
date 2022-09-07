using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBruto : Enemigo
{ 
    float timeAtack = 3f;
    float timeResetAtack;
    float tiempo = 10f;
    float tiempoPatrullaje;
    public Animator animacion;
    Animator daño;
    public Transform posJugador;
    GameObject JugadorAtacado;

    public void Awake()
    {
        nombre = "Bruto";
        vidaEnemigo = 100;
        velocidadEnemigo = 8f;
    }
   
    void Start()
    {   
        JugadorAtacado = GameObject.FindGameObjectWithTag("Player");
        daño = JugadorAtacado.GetComponent<Animator>();
        ResetAtack();
        /*RutaEnemigo();*/
        ResetearTiempoPatrulla();
    }

    
    void Update()
    {
        PerseguirJugador();
        DañoRecibido();
        StopAtack();
    
    }
    /*void RutaEnemigo()
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
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recorrido")
        {
            velocidadEnemigo = 0;
            animacion.SetBool("isRun", false);


            if (other.CompareTag("Player"))
            {
                daño.SetBool("recibioImpacto", true);
            }
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
    bool isAttacking;
    void PerseguirJugador()
    {

        float distanciaJugador = Vector3.Distance(transform.position, posJugador.position);

        if (distanciaJugador <= 15 && distanciaJugador > 5 && isAttacking == false)
        {
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador.position, velocidadEnemigo * Time.deltaTime);
            
        }
        if (distanciaJugador <= 5)
                {
                    isAttacking = true;
                    velocidadEnemigo = 0;
                    animacion.SetBool("isRun", false);
                    AtackPlayer();
                }
            
        else
                {
                    isAttacking = false;
                    velocidadEnemigo = 8f;
                    animacion.SetBool("isRun", true);
                }
        
    }

    public void AtackPlayer()
    {
        float ataqueRapido = 25f;
        timeResetAtack -= Time.deltaTime;

        if (timeResetAtack <= 0)
        {
            NuevoMovientoJugador.playerLife = NuevoMovientoJugador.playerLife - ataqueRapido;
            ResetAtack();
            Debug.Log("Tu salud es de " + NuevoMovientoJugador.playerLife);
            animacion.SetTrigger("AtaqueEnemigo");
        }
      
        

    }

    void DañoRecibido()
    {
        int ataqueJugador = 25;
        float distanciaJugador = Vector3.Distance(transform.position, posJugador.position);
         if (distanciaJugador <= 4 && Input.GetButtonDown("Fire1"))
                {
                    animacion.SetTrigger("RecibiendoDaño");
                    vidaEnemigo -= ataqueJugador;
                    Debug.Log("La vida actual del enemigo es " + vidaEnemigo);
                }
    }

    void ResetAtack()
    {
        timeResetAtack = timeAtack;
    }

    void EnemigoMuerto()
    {
        if (vidaEnemigo <= 0)
        {
            animacion.SetBool("EnemigoMuerto", true);
            Destroy(gameObject, 2f);
            
           
        }
        
    }
    void StopAtack()
    {
        if(NuevoMovientoJugador.playerLife <= 0)
        {
            animacion.SetBool("AtaqueEnemigo", false);
            Debug.Log("dejo de actacar");   
        }
    }
}