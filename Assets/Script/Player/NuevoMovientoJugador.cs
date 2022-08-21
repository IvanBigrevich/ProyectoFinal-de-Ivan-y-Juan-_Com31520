﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoMovientoJugador : MonoBehaviour
{
    private CharacterController controller;
    private GameObject camara;
    public static float playerLife = 20f;
    public static float playerStamina = 100f;
    private Vector3 posInicial;
    private float velocidadGiro;
    private Animator animacion;

    [Header("Estadisticas Normales")]
    public static float velocidad = 5;
    [SerializeField] private float velCorriendo;
    [SerializeField] private float tiempoAlGirar;

 
    private void Start()
    {   
        controller = GetComponent<CharacterController>();
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        animacion = GetComponent<Animator>();
        posInicial = transform.position;
    }

    private void Update()
    {
        Movimiento();
        MuerteJugador();
    }
       

      public void Movimiento()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direccion = new Vector3(horizontal, 0, vertical).normalized;

        if (direccion.magnitude <= 0)
            {
                animacion.SetFloat("Movimientos", 0, 0.1f, Time.deltaTime);
                animacion.SetBool("recibioImpacto", false);
                animacion.SetBool("atackSword", false);
        }


        if (direccion.magnitude >= 0.1f)
            {
                float objetivoAngulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.transform.eulerAngles.y;
                float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, objetivoAngulo, ref velocidadGiro, tiempoAlGirar);
                transform.rotation = Quaternion.Euler(0, angulo, 0);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
                    controller.Move(mover.normalized * velCorriendo * Time.deltaTime);
                    animacion.SetFloat("Movimientos", 1f, 0.1f, Time.deltaTime);

                }
                else
                {
                    Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
                    controller.Move(mover.normalized * velocidad * Time.deltaTime);
                    animacion.SetFloat("Movimientos", 0.3f, 0.1f, Time.deltaTime);
                }
            }
        }

    void MuerteJugador()
    {

        if (playerLife <= 0)
        {
            animacion.SetBool("JugadorMuerto", true);
            StartCoroutine("tiempoRespwan");

        }
    }  
    IEnumerator tiempoRespwan()
    {
        yield return new WaitForSeconds(4f);
        Respawn();
    }
    void Respawn()
    {
        transform.position = posInicial;
        playerLife = 100f;
        animacion.SetBool("JugadorMuerto", false);
    }

}
