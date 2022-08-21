using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovJugador2 : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody rb;

    
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        Movimiento();
    }

    void Movimiento()
        {
           float MovHorizontal = Input.GetAxis("Horizontal");
           float MovVertical = Input.GetAxis("Vertical");
           Vector3 direccion = new Vector3(MovHorizontal,0,MovVertical);
           
           rb.AddForce(direccion * speed, ForceMode.Acceleration);
            
        }
}
