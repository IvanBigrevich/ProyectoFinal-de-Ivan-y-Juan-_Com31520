using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objetos : MonoBehaviour
{
    public GameObject Scriptable;
    public GameObject sword;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject copiaScriptable = Instantiate(Scriptable, transform.position, transform.rotation);
            copiaScriptable.SetActive(true);
            Destroy(copiaScriptable,5f);
            sword.SetActive(false);
        }
    }
    
}
