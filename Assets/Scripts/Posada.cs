using UnityEngine;

public class Posada : MonoBehaviour
{
    //Variables Privadas
    bool chico = true; //si el false es chica. Remedio a corto plazo

    //Variables Privadas
    public bool verHabitacionesDisponibles = false;
    public bool revisarPocionesDisponibles = false;
    public bool revisarComidasDisponibles = false;
    public bool recibirCliente = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InicioPosadero();

    }

    // Update is called once per frame
    void Update()
    {
        InicioPosadero();
    }

    void InicioPosadero()
    {
        Debug.Log("¿Que quieres hacer?");
        Debug.Log("Revisar Pociones Disponibles \nVer habitaciones disponibles \nRevisar comida disponible \nRecibir clientes");
        Debug.Log("Marca en el editor la tarea.");

        if (recibirCliente == true) { RecibirCliente(); recibirCliente = false; }
        if (verHabitacionesDisponibles == true) VerHabitacionesDisponibles();
        if (revisarPocionesDisponibles == true) Revisarpociones();
        if (revisarComidasDisponibles == true) RevisarComidas();

    }

    void Revisarpociones()
    {

    }

    void RevisarComidas()
    {

    }

    void VerHabitacionesDisponibles()
    {

    }

    void RecibirCliente()
    {
        //si chico es true dira caballero y si es false dirá señorita.
        string recibimiento = chico ? "Bienvenido a mi posada caballero" : "Bienvenida a mi posada señorita";
        Debug.Log(recibimiento);
    }

}
