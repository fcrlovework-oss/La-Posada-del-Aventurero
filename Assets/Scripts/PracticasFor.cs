using UnityEngine;

public class PracticasFor : MonoBehaviour
{
    //variables publicas
    public bool enumerar;
    public bool sumarMonedas;
    public bool objetosMochila;
    public bool buscar;
    public string tuNombre;

    //variables privadas
    int monedas = 0;
    string[] objetos = {"Poción", "Espada", "Mapa"};
    string[] nombres = { "Melisa", "Fatima", "Alejandro", "Gerardo", "Daniel", "Elvira", "Lupita" };
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enumerar = false;
        sumarMonedas = false;
        objetosMochila = false;
        buscar = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (enumerar == true)
        {
            Enumerar();
            enumerar = false;
        }

        if (sumarMonedas == true)
        {
            SumarMonedas();
            sumarMonedas = false;
        }

        if (objetosMochila == true)
        {
            ObjetosMochila();
            objetosMochila = false;
        }

        if (buscar == true)
        {
            Buscar();
            buscar = false;
        }
    }

    //Usa un for para imprimir: nivel 1, nivel 2, nivel 3, nivel 4, nivel 5, 
    void Enumerar()
    {
        for (int i = 1; i < 6; i++)
        {
            Debug.Log("nivel " + i);
        }
    }

    //Usa un for para sumar 10 monedas cinco veces. Al final debes imprimir 50 monedas.
    void SumarMonedas()
    {
        for(int i = 10; i < 51; i +=10)
        {
            monedas += 10;
            Debug.Log(monedas + " monedas");
        }
    }

    //Tienes un array con una espada, un mapa y una pocion, imprimelos con un for.
    void ObjetosMochila()
    {
        for(int i = 0; i < objetos.Length; i++)
        {
            Debug.Log(objetos[i]);
        }
    }

    //Crea un array con distintos nombres de personas, que el jugador ponga su nombre y le diga si esta o no en esa lista.
    void Buscar()
    {
        
        bool estasEnLaLista = false;
        for(int i = 0; i< nombres.Length; i++)
        {
            if(tuNombre == nombres[i])
            {
                Debug.Log("Tu nombre está en la lista, estás en la posición" + i);
                estasEnLaLista = true;
                break;
            }
        }
        if (estasEnLaLista == false)
        {
            Debug.Log("No estás en la lista");
        }
        tuNombre = null;
    }

}
