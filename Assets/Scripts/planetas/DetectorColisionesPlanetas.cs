using UnityEngine;

public class DetectorColisionesPlanetas : MonoBehaviour
{
    
    //Esto lo creamos para captar el rigidbody del player:
    private Rigidbody playerbody;

    
    //Esta variable es accesible desde el hijo para saber si el jugador esta sobre el planeta.
    [HideInInspector] 
    public bool jugadorDentro;

    private void Awake()
    {
        playerbody = GameObject.Find("Jugador").GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == playerbody)
        {
            jugadorDentro = true;
        }
    }
}
