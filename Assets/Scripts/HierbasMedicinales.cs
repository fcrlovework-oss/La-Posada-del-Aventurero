using System.Collections.Generic; //esto lo creamos para poder usar dictionary.
using UnityEngine;

public class HierbasMedicinales : MonoBehaviour
{
    //Haremos que para crear las pociones se necesitan unas perlas que solo se encunetran cunado consigues la misma cosa tres veces.
    
    //Primero creamos un string que contenga todas las hierbas disponibles
    string[] hierbasMedicinales = { "🌼", "🌷", "🥀", "🍀", "🌱", "🍁", "🌰", "🍄", "🌿", "🍂" };

    //Creamos una variable para cada hierba:
    List<hierbas> inventario = new List<hierbas>();
    int margarita;
    int tulipan;
    int rosa;
    int trebol4hojas;
    int broteDeSoja;
    int hojaDeArce;
    int avellana;
    int setaRoja;
    int hierbaSanJuan;
    int hojaDeViento;
    int perlaMágica;

    //Este booleano es para decidir salir a buscar hierbas:
    public bool buscarHierbas;

    //Estos son los paseos totales de la salida:
    string[] paseos = new string[3];
   

    //Esta es tu energía, la gastas cada vez que sales:
    static public int energia;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        energia = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (buscarHierbas)
        {
            if (energia < 10)
            {
                print("Estas demasiado cansado para salir, recupera energia primero");
                buscarHierbas = false;
                return;
            }
            else
            {
                energia -= 10;
            }
            JardinPosada();
            paseos[0] = string.Empty;
            paseos[1] = string.Empty;
            paseos[2] = string.Empty;
            print("Has gastado 10 puntos de energia, te quedan " + energia);
            buscarHierbas = false;
        }
    }

    void JardinPosada()
    {
        

        paseos[0] = hierbasMedicinales[Random.Range(0, hierbasMedicinales.Length)];
        paseos[1] = hierbasMedicinales[Random.Range(0, hierbasMedicinales.Length)];
        paseos[2] = hierbasMedicinales[Random.Range(0, hierbasMedicinales.Length)];

        print(paseos[0] + ", " + paseos[1] + ", " + paseos[2]);
        HierbasEncontradasJardin();

    }

    void HierbasEncontradasJardin() //{ "🌼", "🌷", "🥀", "🍀", "🌱", "🍁", "🌰", "🍄", "🌿", "🍂" };
    {
        int margaritacontabilidad = 0;
        int tulipancontabilidad = 0;
        int rosacontabilidad = 0;
        int trebol4hojascontabilidad = 0;
        int broteDeSojacontabilidad = 0;
        int hojaDeArcecontabilidad = 0;
        int avellanacontabilidad = 0;
        int setaRojacontabilidad = 0;
        int hierbaSanJuancontabilidad = 0;
        int hojaDeVientocontabilidad = 0;

        //Aqui registramos lo encontrado en los tres paseos:
        for (int i = 0; i < paseos.Length; i++)
        {
            if (paseos[i] == "🌼") margaritacontabilidad++;
            if (paseos[i] == "🌷") tulipancontabilidad++;
            if (paseos[i] == "🥀") rosacontabilidad++;
            if (paseos[i] == "🍀") trebol4hojascontabilidad++;
            if (paseos[i] == "🌱") broteDeSojacontabilidad++;
            if (paseos[i] == "🍁") hojaDeArcecontabilidad++;
            if (paseos[i] == "🌰") avellanacontabilidad++;
            if (paseos[i] == "🍄") setaRojacontabilidad++;
            if (paseos[i] == "🌿") hierbaSanJuancontabilidad++;
            if (paseos[i] == "🍂") hojaDeVientocontabilidad++;
        }

        //Ahora anunciamos lo encontrado y lo sumamos a la variable general:
        if(margaritacontabilidad > 0)
        {
            print("Has encontrado " + margaritacontabilidad + (margaritacontabilidad !=1 ? " margaritas" : " margarita"));
            margarita += margaritacontabilidad;
        }
        if (tulipancontabilidad > 0)
        {
            print("Has encontrado " + tulipancontabilidad + (tulipancontabilidad != 1 ? " tulipanes" : " tulipan"));
            tulipan += tulipancontabilidad;
        }
        if (rosacontabilidad > 0)
        {
            print("Has encontrado " + rosacontabilidad + (rosacontabilidad != 1 ? " rosas" : " rosa"));
            rosa += rosacontabilidad;
        }
        if (trebol4hojascontabilidad > 0)
        {
            print("Has encontrado " + trebol4hojascontabilidad + (trebol4hojascontabilidad != 1 ? " tréboles de 4 hojas" : " trébol de 4 hojas"));
            trebol4hojas += trebol4hojascontabilidad;
        }
        if (broteDeSojacontabilidad > 0)
        {
            print("Has encontrado " + broteDeSojacontabilidad + (broteDeSojacontabilidad != 1 ? " brotes de Soja" : " brote de Soja"));
            broteDeSoja += broteDeSojacontabilidad;
        }
        if (hojaDeArcecontabilidad > 0)
        {
            print("Has encontrado " + hojaDeArcecontabilidad + (hojaDeArcecontabilidad != 1 ? " hojas de Arce" : " hoja de Arce"));
            hojaDeArce += hojaDeArcecontabilidad;
        }
        if (avellanacontabilidad > 0)
        {
            print("Has encontrado " + avellanacontabilidad + (avellanacontabilidad != 1 ? " avellanas" : " avellana"));
            avellana += avellanacontabilidad;
        }
        if (setaRojacontabilidad > 0)
        {
            print("Has encontrado " + setaRojacontabilidad + (setaRojacontabilidad != 1 ? " setas roja" : " seta roja"));
            setaRoja += setaRojacontabilidad;
        }
        if (hierbaSanJuancontabilidad > 0)
        {
            print("Has encontrado " + hierbaSanJuancontabilidad + (hierbaSanJuancontabilidad != 1 ? " hierbas de San Juan" : " hierba de San Juan"));
            hierbaSanJuan += hierbaSanJuancontabilidad;
        }
        if (hojaDeVientocontabilidad > 0)
        {
            print("Has encontrado " + hojaDeVientocontabilidad + (hojaDeVientocontabilidad != 1 ? " hojas de Viento" : " hoja de Viento"));
            hojaDeViento += hojaDeVientocontabilidad;
        }

        if (paseos[0] == paseos[1] && paseos[1] == paseos[2])
        {
            print("¡Has encontrado una perla para hacer pociones mágicas!");
            perlaMágica++;
        }
    }
}
