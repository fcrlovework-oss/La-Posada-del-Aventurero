using UnityEngine;

public class Posada : MonoBehaviour
{
    //Variables Privadas
    bool chico = true; //si el false es chica. Remedio a corto plazo
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //si chico es true dira caballero y si es false dirá señorita.
        string recibimiento = chico? "Bienvenido a mi posada caballero" : "Bienvenida a mi posada señorita";
        Debug.Log(recibimiento);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
