using UnityEngine;
using UnityEngine.UI;

public class DisplayCarta : MonoBehaviour
{
    public Carta _carta;
    public Text textoNombre;
    public Text textoDescripcion;
    public Image imagenCarta;
    
    void Start()
    {
        _carta.MostrarData();
        textoNombre.text = _carta.nombreCarta;
        textoDescripcion.text = _carta.descripcionCarta;
        imagenCarta.sprite = _carta.dibujoCarta;
    }


}
