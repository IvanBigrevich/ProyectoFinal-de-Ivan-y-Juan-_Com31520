using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador2 : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovimientoJugador();
    }
    void MovimientoJugador()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 Mov = new Vector3(hor, 0, ver);

        RB.AddForce(Mov * speed, ForceMode.Acceleration);
    }
}
