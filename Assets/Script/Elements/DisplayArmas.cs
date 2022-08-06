using UnityEngine;
using UnityEngine.UI;
public class DisplayArmas : MonoBehaviour
{

    public Sword espada;
    public Text nombreEspada;
    public Text textoDaño;
    public Image imagenEspada;

    // Start is called before the first frame update
    void Start()
    {
        espada.MostrarInfo();
        nombreEspada.text = espada.nombre;
        textoDaño.text = espada.daño;
        imagenEspada.sprite = espada.imagenSword;
    }
}
