using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEnMano : MonoBehaviour
{
    public ToggleWeapon toggleWeapon;
    public int numeroArma;

    // Start is called before the first frame update
    void Start()
    {
        toggleWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<ToggleWeapon>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            toggleWeapon.ActivarArma(numeroArma);
            Destroy(gameObject);
        }
    }
}
