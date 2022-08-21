using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDelAtaque : MonoBehaviour
{
    [SerializeField] private Transform controladroGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    private Animator jugadorAtaque;


    // Start is called before the first frame update
    void Start()
    {
        jugadorAtaque = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Golpe();
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
            }
            else
            {
                jugadorAtaque.SetTrigger("Ataque");
                NuevoMovientoJugador.velocidad = 0;
                StartCoroutine("ResetearVelocidad");

            }
        }


    }

    private void Golpe()
    {
        Collider[] objetos = Physics.OverlapSphere(controladroGolpe.position, radioGolpe);
        foreach (Collider colision in objetos)
        {
            if (colision.CompareTag("Enemigo"))
            {
                colision.transform.GetComponent<EnemigoNuevo>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladroGolpe.position, radioGolpe);
    }
    //public void AtaqueJugador()
    //{
    //      if(Input.GetButtonDown("Fire1"))
    //    {
    //        jugadorAnim.SetTrigger("Ataque");

    //    }/*else
    //    {
    //        jugadorAnim.SetBool("Ataque", false);
    //    }*/
    //}

    IEnumerator ResetearVelocidad()
    {
        yield return new WaitForSeconds(1f);
        NuevoMovientoJugador.velocidad = 5;

    }
}



