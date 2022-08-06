using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName ="Nueva Arma", menuName ="Armas")]
public class Sword : ScriptableObject
{
    public string nombre = "Sword";
    public Sprite imagenSword;
    public string daño = "30";
    


    public void MostrarInfo()
    {
        Debug.Log(nombre + ": ");
    }
}
