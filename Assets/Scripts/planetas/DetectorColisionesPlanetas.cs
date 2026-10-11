using UnityEngine;

public class DetectorColisionesPlanetas : MonoBehaviour
{

    //Esto lo creamos para captar el rigidbody del player:
    public MovimientoJugadorPlanetas movimientoJugador;

    [HideInInspector]
    public static bool jugadorPuedeSaltar; //Creamos esta variable para indicarle al InputControler que active el salto.

    [HideInInspector]
    public bool jugadorAfectadoPropiedades = false;

    GameObject planoinicial;

    private void Awake()
    {
        planoinicial = GameObject.Find("Plane");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == movimientoJugador.jugadorRb)
        {
            if (gameObject != planoinicial)
            {
                Debug.Log("Jugador Propiedades Detectado");
                jugadorAfectadoPropiedades = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.rigidbody == movimientoJugador.jugadorRb)
        {
            Debug.Log("Jugador Detectado");
            jugadorPuedeSaltar = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody == movimientoJugador.jugadorRb)
        {
            Debug.Log("Jugador Sale");
            jugadorPuedeSaltar = true;
        }
    }

    

}
