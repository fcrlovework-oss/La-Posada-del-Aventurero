using System.Collections.Generic;
using UnityEngine;

public class AdoptandoCriaturas : MonoBehaviour
{
    //***QUEDA PENDIENTE CONDICION DE QUE LA LISTA DE DISPONIBLES ESTE VACIA, CORREGIR Y CREAR TODA LA PARTE DEL BOTON DE COMPRAR CRIATURA.***
    //Creamos la lista para las criaturas:
    List<Criaturas> criaturasDisponibles = new List<Criaturas>();
    List<Criaturas> criaturasParaCompra = new List<Criaturas>();
    static public List<Criaturas> criaturasObtenidas = new List<Criaturas>();
    Criaturas eri;
    Criaturas escorpio;
    Criaturas criaturaElegida;
    Criaturas criaturaCompraDisponible;

    //Comenzamos con el juego de adivinar su nombre:
    public bool comprarCriatura;
    public bool AdivinarLetra;
    int averiguarEspecie = 0;
    public string letraJugador;
    string palabraOculta = string.Empty;
    string palabraSecreta;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        AñadirCriaturas();
        ElegirCriaturaSecreta();
    }

    // Update is called once per frame
    void Update()
    {
        if(comprarCriatura == true)
        {
            VerCriaturasDisponiblesCompra();
            comprarCriatura = false;
        }
        
        
        if(AdivinarLetra == true)
        {
            if(averiguarEspecie == 4)
            {
                HacerCompra();
            }
            else if(HierbasMedicinales.energia <= 0)
            {
                print("No tienes energia suficiente");
            }
            else
            {
                ComprobarLetra();
            }
            AdivinarLetra = false;
        }

        if(averiguarEspecie == 1)
        {
            print("Solo te queda averiguar la especie de la criatura y podrás comprarla");
            palabraSecreta = criaturaElegida.tipoCriatura.ToLower();
            palabraOculta = new string('*', palabraSecreta.Length);
            print(palabraOculta);
            averiguarEspecie = 2;
        }

        if (averiguarEspecie == 3)
        {
            print(criaturaCompraDisponible.nombreCriatura + " cuesta " + criaturaCompraDisponible.precioCriatura);
            print("¿Quieres comprarla?, escribe si o no");
            HacerCompra();
            
        }
    }

    void AñadirCriaturas()
    {
        eri = new Criaturas();
        eri.nombreCriatura = "Eri";
        eri.tipoCriatura = "Periquito";
        eri.precioCriatura = 100;
        criaturasDisponibles.Add(eri);

        escorpio = new Criaturas();
        escorpio.nombreCriatura = "Escorpio";
        escorpio.tipoCriatura = "Grifo";
        escorpio.precioCriatura = 1000;
        criaturasDisponibles.Add(escorpio);
        print("Bienvenido a la Guardería de criaturas...");
        print("Para adoptar a una criatura nueva debes adivinar su nombre y luego su especie");
        print("Por cada error, perderás 5 puntos de energía");
    }

    void ElegirCriaturaSecreta()
    {
        //elegimos a una criatura aleatoria de la lista y añadimos su nombre a la palabra secreta.
        criaturaElegida = criaturasDisponibles[Random.Range(0, criaturasDisponibles.Count)];
        palabraSecreta = criaturaElegida.nombreCriatura.ToLower();
        palabraOculta = new string('*', palabraSecreta.Length);
        print(palabraOculta);
    }

    void ComprobarLetra()
    {
        letraJugador = letraJugador.ToLower();
        //Comprobamos que el espacio no esté vacio
        if (letraJugador == string.Empty)
        {
            print("No has escrito nada...");
        }
        //Comprobamos si escribió más de una letra
        else if (letraJugador.Length > 1)
        {
            print("Sólo puedes escribir una letra...");
        }
        //Con TryParse comprobamos si lo que el jugador escribio era un numero o una letra.
        else if (int.TryParse(letraJugador, out int resultado))
        {
            print("La palabra solo contiene letras");
        }
        //ahora comprobamos si la palabra tiene la letra y se la ponemos.
        else if (palabraSecreta.Contains(letraJugador)) //si la palabra contiene la letra.
        {
            char[] arrayPalabraOculta = palabraOculta.ToCharArray();
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (letraJugador == palabraSecreta[i].ToString())
                {
                    arrayPalabraOculta[i] = palabraSecreta[i];
                }
            }
            palabraOculta = new string(arrayPalabraOculta);
            if (palabraSecreta == palabraOculta)
            {
                if (averiguarEspecie == 2)
                {
                    print("¡Felicidades!, averiguaste la especie de la criatura");
                    print(palabraOculta);
                    criaturaCompraDisponible = criaturaElegida;
                    averiguarEspecie = 3;

                }
                else
                {
                    print("¡Felicidades!, averiguaste el nombre de la criatura");
                    print(palabraOculta);
                    averiguarEspecie = 1;
                }
            }
            else
            {
                print("¡Muy bien, encontraste una de las letras!");
                print(palabraOculta);
            }
        }
        //Esto lo hacemos si la letra no forma parte de la palabra:
        else
        {
            print("Parece que esta letra no pertenece a la palabra, perdiste cinco puntos de energía.");
            HierbasMedicinales.energia -= 5;
        }
        letraJugador = string.Empty;
    }

    //********************* METODOS PARA COMERCIAR LAS CRIATURAS ******************************
    void VerCriaturasDisponiblesCompra()
    {
        if (criaturasParaCompra == null)
        {
            print("No tienes criaturas disponibles para comprar.");
        }
        else
        {
            print("Estas son las criaturas disponibles para compra, pon el nombre de la que quieres comprar");
            //aqui deberia haber un for que recorriera la lista y diera los datos de cada criatura y registrase en la variable criaturaCompraDisponible.
        }
    }
 
    
    void HacerCompra()
    {
        averiguarEspecie = 4;
        if (letraJugador == "si")
        {
            if(Posada.saldoJugador >= criaturaCompraDisponible.precioCriatura)
            {
                print("¡Pagada!, te quedan " + Posada.saldoJugador + " monedas");
                criaturasObtenidas.Add(criaturaCompraDisponible);
                criaturasDisponibles.Remove(criaturaCompraDisponible);
                averiguarEspecie = 0;
                ElegirCriaturaSecreta();

            }
            else
            {
                print("Tu saldo es de " + Posada.saldoJugador + " monedas, no es suficiente.");
                print("Mientras ahorras puedes desbloquear a otra criatura.");
                criaturasParaCompra.Add(criaturaCompraDisponible);
                criaturasDisponibles.Remove(criaturaCompraDisponible);
                averiguarEspecie = 0;
                ElegirCriaturaSecreta();
            }
        }
        else if(letraJugador == "no")
        {
            print("De acuerdo, puedes desbloquear a otra criatura si esta no te interesa");
            criaturasParaCompra.Add(criaturaCompraDisponible);
            criaturasDisponibles.Remove(criaturaCompraDisponible);
            averiguarEspecie = 0;
            ElegirCriaturaSecreta();
        }
        else if (letraJugador != "si" && letraJugador != "no")
        {
            print("Escribe o si o no...");
        }
    }
}
