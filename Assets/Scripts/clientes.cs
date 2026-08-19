using UnityEngine;

namespace clientes
{
    class DatosClientes
    {
    public string[] nombresMujer = { "Elena", "María", "Elisa", "Fátima", "Alejandra", "Clara", "Elvira", "Delfina", "Estela", "Laura" };
    public string[] nombresHombre = { "David", "Daniel", "Alejandro", "Miguel", "Ricardo", "Alexis", "Zeus", "Petroclo", "Dioniso", "Nico" };
    public string[] sexo = { "Hombre", "Mujer"};
    public string[] Profesion = { "Mago", "Ladrón", "Caballero", "Bruja", "Ninja", "Estudiante", "Jubilado", "Normal"};
    public string[] economia = { "Pobre", "Clase Media", "Adinerado"};

    }
    class cliente
    {
        public string nombre;
        public string sexo;
        public string profesion;
        public int edad;
        public string economia;
        public int saldo;
        public int tiempoEspera;
        //public string caracter;

        public string MostrarDatos()
        {
            return "Nombre: " + nombre +
                   "\nEdad: " + edad +
                   "\nSexo: " + sexo +
                   "\nProfesión: " + profesion +
                   "\nEconomía: " + economia +
                   "\nSaldo: " + saldo +
                   "\nTiempo de espera: " + tiempoEspera;
        }
    }
}  