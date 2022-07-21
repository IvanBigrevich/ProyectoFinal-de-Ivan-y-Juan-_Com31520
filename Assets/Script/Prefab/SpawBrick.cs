using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawBrick : MonoBehaviour
{
    float tiempo = 20;
    float tiempoSpawnLadrillo;
    public GameObject brick;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(brick,transform.position, transform.rotation);
       
    }

    // Update is called once per frame
    void Update()
    {
        spawnBrick();

    }

    void spawnBrick()
    { 
        tiempoSpawnLadrillo -= Time.deltaTime;
        if (tiempoSpawnLadrillo <= 0)
        {
            Instantiate(brick, transform.position, transform.rotation);
            ResetSpawnBrickTime();
        }
    }
    void ResetSpawnBrickTime()
    {
        tiempoSpawnLadrillo = tiempo;
    }
  
}
