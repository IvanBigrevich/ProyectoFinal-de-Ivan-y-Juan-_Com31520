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
                StartCoroutine("ResetearVelocidad");

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

    /*private void Golpe()
    {
        Collider[] objetos = Physics.OverlapSphere(controladorGolpe.position, radioGolpe);
        foreach (Collider colision in objetos)
        {
          
        }
    }*/

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }*/

    public void AtaqueJugador()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            jugadorAtaque.SetTrigger("Ataque");
        }
       
    IEnumerator ResetearVelocidad()
    {
        yield return new WaitForSeconds(1f);
        NuevoMovientoJugador.velocidad = 4;

    }
    }
}



