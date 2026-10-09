using UnityEngine;

public class ActivacionSistemaSolar : MonoBehaviour
{
    MovimientoJugadorPlanetas toqueJugador;
    RotacionPlanetas[] rotacionPlanetas; 

    private void Awake()
    {
        toqueJugador = GameObject.Find("Input Controller").GetComponent<MovimientoJugadorPlanetas>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.rigidbody == toqueJugador.jugadorRb)
        {
            
        }
    }
}
