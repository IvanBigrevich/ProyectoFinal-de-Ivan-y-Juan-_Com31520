using UnityEngine;

[CreateAssetMenu(fileName = "NuevaCarta", menuName = "Carta")]
public class Carta : ScriptableObject
{
    public string nombreCarta;
    public string descripcionCarta;
    public Sprite dibujoCarta;
    public int valorCarta;

}
