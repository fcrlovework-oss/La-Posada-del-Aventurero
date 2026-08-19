using Unity.VisualScripting;
using UnityEngine;

public class HierbasMedicinales : MonoBehaviour
{
    //Haremos que para crear las pociones se necesitan unas perlas que solo se encunetran cunado consigues la misma cosa tres veces.
    
    //Primero creamos un string que contenga todas las hierbas disponibles
    string[] hierbasMedicinales = { "🌼", "🌷", "🥀", "🍀", "🌱", "🍁", "🌰", "🍄", "🌿", "🍂" };

    //Creamos una variable para cada hierba:
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

    //Este booleano es para decidir salir a buscar hierbas:
    public bool buscarHierbas;

    //Estos son los paseos totales de la salida:
    string[] paseos = new string[3];
   

    //Esta es tu energía, la gastas cada vez que sales:
    int energia;
    
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
        for(int i = 0; i < paseos.Length; i++)
        {
            if (paseos[i] == "🌼")
            {
                margarita++;
                print("Has encontrado " + margarita + (margarita > 1 ? " margaritas!" : " margarita!"));
            }   
                
            if (paseos[i] == "🌷") 
            {
                tulipan++;
                print("Has encontrado " + tulipan + (tulipan > 1 ? " tulipanes!" : " tulipán!"));
            }

            if (paseos[i] == "🥀") 
            {
                rosa++;
                print("Has encontrado " + rosa + (rosa > 1 ? " rosas!" : " rosa!"));
            }

            if (paseos[i] == "🍀") 
            {
                trebol4hojas++;
                print("Has encontrado " + trebol4hojas + (trebol4hojas > 1 ? " treboles de 4 hojas!" : " trebol de 4 hojas!"));
            }

            if (paseos[i] == "🌱") 
            {
                broteDeSoja++;
                print("Has encontrado " + broteDeSoja + (broteDeSoja > 1 ? " brotes de Soja!" : " brote de Soja!!"));
            }
            if (paseos[i] == "🍁") 
            {
                hojaDeArce++;
                print("Has encontrado " + hojaDeArce + (hojaDeArce > 1 ? " hojas de Arce!" : " hojas de Arce!"));
            }
            if (paseos[i] == "🌰") 
            {
                avellana++;
                print("Has encontrado " + avellana + (avellana > 1 ? " avellanas!" : " avellana!"));
            }
            if (paseos[i] == "🍄") 
            {
                setaRoja++;
                print("Has encontrado " + setaRoja + (setaRoja > 1 ? " setas rojas!" : " seta roja!"));
            }
            if (paseos[i] == "🌿") 
            {
                hierbaSanJuan++;
                print("Has encontrado " + hierbaSanJuan + (hierbaSanJuan > 1 ? " hierbas de San Juan!" : " hierba de San Juan!"));
            }
            if (paseos[i] == "🍂") 
            {
                hojaDeViento++;
                print("Has encontrado " + hojaDeViento + (hojaDeViento > 1 ? " hojas de viento!" : " hoja de viento!"));
            }
        }

        if(paseos[0] == paseos[1] && paseos[1] == paseos[2])
        {
            print("¡Has encontrado una perla para hacer pociones mágicas!");
        }
    }
}
