using UnityEngine;

public class DetectorCaida : MonoBehaviour
{
    MovimientoJugadorPlanetas jugador;

    [HideInInspector]
    public Vector3 posicionoriginalJugador;

    //Este bool es para anular los efectos de las propiedades.
    public bool AnulacionYreinicioPropiedades = false;

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
            AnulacionYreinicioPropiedades = true;
            Debug.Log("Se activa el reseteo de propiedades");
            jugador.vidaJugadorPlanetas -= 1;
            Debug.Log("Has perdido 1 vida, te quedan " + jugador.vidaJugadorPlanetas);
        }
    }
}
