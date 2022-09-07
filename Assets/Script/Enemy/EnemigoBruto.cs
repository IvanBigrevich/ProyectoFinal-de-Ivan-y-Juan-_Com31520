using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBruto : MonoBehaviour
{ 
    /*float timeAtack = 3f;
    float timeResetAtack;
    float tiempo = 10f;
    float tiempoPatrullaje;
    public Animator animacion;
    Animator daño;
    public Transform posJugador;
    GameObject JugadorAtacado;*/
    public static float vidaEnemigo = 100;
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;
    public AudioSource sonidoMuerte;
    public AudioClip sonidoMuerteenemigo;
    


  
   
    void Start()
    {   
        ani = GetComponent<Animator>();
        target = GameObject.Find("Godwin");
       /* JugadorAtacado = GameObject.FindGameObjectWithTag("Player");
        daño = JugadorAtacado.GetComponent<Animator>();
        ResetAtack();
        RutaEnemigo();
        ResetearTiempoPatrulla();*/
    }

    
    void Update()
    {
      Comportamiento_Enemigo();
      /*  PerseguirJugador();*/
        EnemigoMuerto();
       /* StopAtack();*/
    
    }

    public void Comportamiento_Enemigo()
    {   if(Vector3.Distance(transform.position, target.transform.position) > 5)
        {
        ani.SetBool("run", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >=4)
        {
            rutina = Random.Range (0, 2);
            cronometro = 0;
        }
        switch(rutina)
        {
            case 0:
                ani.SetBool("walk", false);
                break;
            case 1:
                grado = Random.Range(0,360);
                angulo = Quaternion.Euler(0,grado,0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                ani.SetBool("walk", true);
                break;
        }
        }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position) > 5 && !atacando)
            {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            ani.SetBool("walk", false);
            ani.SetBool("run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            ani.SetBool("attack", false);
            }
            else
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
                atacando = true;
            }
        }
    }

    public void Final_ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
    }

      private void OnTriggerEnter(Collider col)
    {
    
        if(col.CompareTag("sword"))
        {
            print("daño");
            vidaEnemigo -= 25;
        }
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
    }
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
    }*/

    void EnemigoMuerto()
    {
        if (vidaEnemigo <= 0)
        {
            sonidoMuerte.PlayOneShot(sonidoMuerteenemigo, 0.5f);
            ani.SetBool("enemigoMuerto", true);
            Destroy(gameObject, 2f);
            
           
        }
        
    }
   /* void StopAtack()
    {
        if(NuevoMovientoJugador.playerLife <= 0)
        {
            animacion.SetBool("AtaqueEnemigo", false);
            Debug.Log("dejo de actacar");   
        }
    }*/
}