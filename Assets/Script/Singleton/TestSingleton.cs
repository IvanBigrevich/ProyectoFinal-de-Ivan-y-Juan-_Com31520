using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSingleton : MonoBehaviour
{
    public static TestSingleton unicaInstancia;

    private void Awake()
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
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }
    }
}
