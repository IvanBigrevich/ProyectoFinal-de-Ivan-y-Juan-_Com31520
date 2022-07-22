using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestSingleton : MonoBehaviour
{
    public static TestSingleton unicaInstancia;


    private void Awake() //=null significa que no hay ningun objeto que tenga la clase asignada, algun objeto es de tipo manager sonido o l oesta usando
    {
        if (TestSingleton.unicaInstancia == null)
        {
            TestSingleton.unicaInstancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }
    }
}
