using UnityEngine;

public class DetectorCaida : MonoBehaviour
{
    MovimientoJugadorPlanetas jugador;
    Vector3 posicionoriginalJugador;

    private void Awake()
    {
        jugador = GameObject.Find("Input Controller").GetComponent<MovimientoJugadorPlanetas>();
    }

    private void Start()
    {
        posicionoriginalJugador = jugador.jugadorSueño.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == jugador.jugadorRb)
        {
            jugador.jugadorSueño.transform.position = posicionoriginalJugador;
            jugador.vidaJugadorPlanetas -= 1;
            Debug.Log("Has perdido 1 vida, te quedan " + jugador.vidaJugadorPlanetas);
        }
    }
}
