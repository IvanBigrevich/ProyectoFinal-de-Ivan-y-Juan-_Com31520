using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDelAtaque : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    public Animator jugadorAtaque;
    public AudioSource sonidoEspada;
    public AudioClip sonidoChoque;
 
    void Start()
    {
       
    }
   
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                AtaqueJugador();
            }
            else
            {
                jugadorAtaque.SetTrigger("Ataque");
                NuevoMovientoJugador.velocidad = 0;
                
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
          if (col.CompareTag("Enemigo"))
            {
                EnemigoBruto.vidaEnemigo -= 25;
                sonidoEspada.PlayOneShot(sonidoChoque, 1f);
            }
            if (col.CompareTag("EnemigoFinal"))
            {
                EnemigoFinal.vidaFinal -= 25;
                sonidoEspada.PlayOneShot(sonidoChoque, 1f);
            }
    }

    public void AtaqueJugador()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            jugadorAtaque.SetTrigger("Ataque");
        }
    }
}