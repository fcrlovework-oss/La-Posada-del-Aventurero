using UnityEngine;

public class DetectorCaida : MonoBehaviour
{
    MovimientoJugadorPlanetas jugador;
    bool JugadorCaido;
    

    private void Awake()
    {
        jugador = GameObject.Find("Input Controller").GetComponent<MovimientoJugadorPlanetas>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.attachedRigidbody == jugador.rigidbodyJugadorSueño)
        {
            jugador.jugadorSueño.transform.position = jugador.posicionoriginalJugador;
            jugador.vidaJugadorPlanetas -= 1;
            Debug.Log("Has perdido 1 vida, te quedan " + jugador.vidaJugadorPlanetas);


        }
        
    }
}
