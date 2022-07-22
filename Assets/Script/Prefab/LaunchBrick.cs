using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBrick : MonoBehaviour
{
    public GameObject brick;
    public Transform spawnPoint;
    public float range = 20f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Lanzar();
        }
    }

    void Lanzar() 
    {
        GameObject copiaBrick = Instantiate(brick, spawnPoint.position, spawnPoint.rotation);
        copiaBrick.GetComponent<Rigidbody>().AddForce(transform.forward* range, ForceMode.Impulse);
    }
}
