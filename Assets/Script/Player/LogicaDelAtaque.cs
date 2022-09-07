using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDelAtaque : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    public Animator jugadorAtaque;


 
    void Start()
    {
        
    }

    
    void Update()
    {

       /* if (Input.GetButtonDown("Fire1"))
        {
            Golpe();
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
        }*/


    }

   /* private void Golpe()
    {
        Collider[] objetos = Physics.OverlapSphere(controladorGolpe.position, radioGolpe);
        foreach (Collider colision in objetos)
        {
            if (colision.CompareTag("Enemigo"))
            {
                colision.transform.GetComponent<EnemigoBruto>().DañoRecibido(dañoGolpe);
                colision.transform.GetComponent<EnemigoFinal>().DañoRecibido(dañoGolpe);
            }
        }
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

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



