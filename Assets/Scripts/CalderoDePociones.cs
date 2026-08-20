using UnityEngine;

public class CalderoDePociones : MonoBehaviour
{
    //Creamos los botones para hacer la pocion:
    public bool crearPoción = false;
    public int ingredientes;

    //Vamos a crear un array con todas las hierbas que podemos tener:
    int[] hierbasDisponibles = new int[11];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (crearPoción)
        {
            if(ingredientes == 0)
            {
                print("Elige cuantos ingredientes quieres mezclar");
            }
            else if(ingredientes > 1 && ingredientes <= 3)
            {
                CreandoPoción();
            }
            else if( ingredientes > 3)
            {
                print("Por ahora solo puedes mezclar un máximo de tres ingredientes");
            }



        }
    }

    void CreandoPoción()
    {
        if (ingredientes == 0)
        {

        }
    }
}
