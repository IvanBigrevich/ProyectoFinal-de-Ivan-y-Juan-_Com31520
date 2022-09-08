using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoMovientoJugador : MonoBehaviour
{
    private CharacterController controller;
    private GameObject camara;
    public static float playerLife = 100f;
    public Vector3 posInicial;
    private float velocidadGiro;
    public Animator animacion;
    public AudioSource sonidoMuerte;
    public AudioClip sonidoMuertejugador;
    public AudioClip sonidoDañoJugador;
  
    bool death;
    bool isDead;

    [Header("Estadisticas Normales")]
    public static float velocidad = 4;
    [SerializeField] private float tiempoAlGirar;

 
    private void Start()
    {   
        
        controller = GetComponent<CharacterController>();
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        animacion = GetComponent<Animator>();
       
        posInicial = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    private void Update()
    {
        if(death==false)Movimiento();
        
        
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
        }

        if (direccion.magnitude >= 0.1f)
            {
                float objetivoAngulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.transform.eulerAngles.y;
                float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, objetivoAngulo, ref velocidadGiro, tiempoAlGirar);
                transform.rotation = Quaternion.Euler(0, angulo, 0);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    velocidad = 10;
                    Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
                    controller.Move(mover.normalized * velocidad * Time.deltaTime);
                    animacion.SetFloat("Movimientos", 1f, 0.1f, Time.deltaTime);
                }
                else
                {
                    velocidad = 4;
                    Vector3 mover = Quaternion.Euler(0, objetivoAngulo, 0) * Vector3.forward;
                    controller.Move(mover.normalized * velocidad * Time.deltaTime);
                    animacion.SetFloat("Movimientos", 0.3f, 0.1f, Time.deltaTime);
                }
            }
        }

    void MuerteJugador()
    {
        if (playerLife <= 0 && !isDead)
        {
            isDead=true;
            death=true;
            sonidoMuerte.PlayOneShot(sonidoMuertejugador, 0.5f);
            StartCoroutine("tiempoRespawn");
        }
    }  
    IEnumerator tiempoRespawn()
    {
        animacion.SetBool("JugadorMuerto",true);
        controller.enabled=false;
        yield return new WaitForSeconds(15f);
        Respawn();
        
    }
    void Respawn()
    {
        isDead=false;
        transform.position = posInicial;
        playerLife = 100f;
        animacion.SetBool("JugadorMuerto", false);
        controller.enabled=true;
        death=false;
    }

    private void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "FirstAid")
        {
            playerLife = 100f;
        }
        if(col.CompareTag("arma"))
        {
            playerLife -= 5;
            sonidoMuerte.PlayOneShot(sonidoDañoJugador, 0.5f);
            animacion.SetTrigger("ReciboAtaque");
        }
        if(col.CompareTag("arma2"))
        {
            playerLife -= 10;
            sonidoMuerte.PlayOneShot(sonidoDañoJugador, 0.5f);
            animacion.SetTrigger("ReciboAtaque");
        }
    }
}