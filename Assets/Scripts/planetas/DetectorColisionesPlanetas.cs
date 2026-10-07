using UnityEngine;

public class DetectorColisionesPlanetas : MonoBehaviour
{

    //Esto lo creamos para captar el rigidbody del player:
    public MovimientoJugadorPlanetas movimientoJugador;

    [HideInInspector]
    public static bool jugadorPisaTierra;
        
    
    private void OnCollisionStay(Collision collision)
    {
        if(collision.rigidbody == movimientoJugador.jugadorRb)
        {
            Debug.Log("Jugador Detectado");
            jugadorPisaTierra = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody == movimientoJugador.jugadorRb)
        {
            Debug.Log("Jugador Sale");
            jugadorPisaTierra = true;
        }
    }

    

}
