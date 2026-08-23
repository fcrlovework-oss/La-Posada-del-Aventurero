using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Posada : MonoBehaviour
{
    //Variables
    ArrayList listaDeClientes = new ArrayList();
    clientes.DatosClientes datoCliente = new clientes.DatosClientes();
    public bool crearCliente = false;

    //Variable spara atender al cliente:
    public bool atenderCliente = false;
    bool contadorFinaliza;
    float contadorTiempo = 0;
    float proximoCliente;
    static public int saldoJugador;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saldoJugador = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        contadorTiempo += Time.deltaTime;

        if(contadorFinaliza == true)
        {
            if (contadorTiempo >= proximoCliente)
            {
                print(contadorTiempo);
                contadorTiempo = 0f;
                LlegaCliente();
            }
        }

        if (crearCliente == true)
        {
            CrearNuevoCliente();
            crearCliente = false;
        }

        if (atenderCliente == true)
        {
            AtenderCliente();
            atenderCliente = false;           
        }
    }

    void CrearNuevoCliente()
    {
        //Este es el cliente:
        clientes.cliente numero1 = new clientes.cliente();
               
        //Asignamos una caracteristica aleatoria de cada:
        numero1.sexo = datoCliente.sexo[Random.Range(0, 2)];
        numero1.edad = Random.Range(15, 80);
        numero1.profesion = datoCliente.Profesion[Random.Range(0, datoCliente.Profesion.Length)];
        numero1.economia = datoCliente.economia[Random.Range(0, datoCliente.economia.Length)];
        numero1.tiempoEspera = Random.Range(10, 60);

        //Le damos un nombre en base a su sexo:
        if (numero1.sexo == "Hombre")
        {
            numero1.nombre = datoCliente.nombresHombre[Random.Range(0, datoCliente.nombresHombre.Length)];
        }
        else if (numero1.sexo == "Mujer")
        {
            numero1.nombre = datoCliente.nombresMujer[Random.Range(0, datoCliente.nombresMujer.Length)];
        }

        //Con esto definimos su nivel Economico
        if (numero1.economia == "Pobre")
        {
            numero1.saldo = Random.Range(0, 2500);
        }
        else if (numero1.economia == "Clase Media")
        {
            numero1.saldo = Random.Range(3000, 8000);
        }
        else if (numero1.economia == "Adinerado")
        {
            numero1.saldo = Random.Range(8000, 10000);
        }

        //************Aqui registramos al cliente:********
        listaDeClientes.Add(numero1);
        
        //Con esto imprimirmos el numero de clientes creados
        Debug.Log("Clientes guardados: " + listaDeClientes.Count);

        //Con foreach, recorremos la lista e imprimimos los nombres que contiene cada cliente
        foreach (var valor in listaDeClientes)
        {
            clientes.cliente clientesActuales = (clientes.cliente)valor;
            Debug.Log(clientesActuales.nombre);
        }
    }

    void AtenderCliente()
    {
        proximoCliente = Random.Range(5f, 15f);
        contadorFinaliza = true;
        contadorTiempo = 0;

        print(contadorTiempo);
        print(proximoCliente);
    
    }

    void LlegaCliente()
    {
        contadorFinaliza = false;
        clientes.cliente clienteatendido = (clientes.cliente)listaDeClientes[Random.Range(0, listaDeClientes.Count)];
        //Elegimos a un cliente de nuestra lista de clientes:
        print(clienteatendido.MostrarDatos());
    }

    void RegistrarCliente()
    {

    }
}
