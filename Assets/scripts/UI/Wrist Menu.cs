using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WristMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public SimpleObjectController controlador;
    public TextMeshProUGUI texto;
    public Image imagen;
    // Update is called once per frame

    private void Start()
    {

    }

    public void cambiarMateria(string material)
    {
        Sprite metal = Resources.Load<Sprite>("Metal");
        Sprite ice = Resources.Load<Sprite>("Hielo");
        Sprite explosive = Resources.Load<Sprite>("TNT");
        Sprite stone = Resources.Load<Sprite>("Piedra");

        if (material == "metal")
        {
            imagen.sprite = metal;
            
        }
        else if (material == "ice")
        {
            imagen.sprite = ice;
        }
        else if (material == "explosive")
        {
            imagen.sprite = explosive;
        }
        else if (material == "stone")
        {
            imagen.sprite = stone;
        }
        texto.name = material;
    }
}
