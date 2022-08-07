using UnityEngine;
using UnityEngine.UI;
public class DisplayArmas : MonoBehaviour
{

    public Sword espada;
    public Image imagenEspada;

    // Start is called before the first frame update
    void Start()
    {
        imagenEspada.sprite = espada.imagenSword;
    }
}
