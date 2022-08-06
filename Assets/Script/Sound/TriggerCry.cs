using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCry : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip clipCry;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clipCry = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                audioSource.Play();
                Debug.Log("Play");
            Destroy(gameObject, 2f);
        }
    }
}
