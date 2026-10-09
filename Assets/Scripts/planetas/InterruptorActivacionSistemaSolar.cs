using UnityEngine.InputSystem;
using UnityEngine;

public class InterruptorActivacionSistemaSolar : MonoBehaviour
{
    private MovimientoJugadorPlanetas toqueJugador;
    private RotacionEstrella activacionRotacionEstrella;
    private bool activacionSistema = false;

    private void Awake()
    {
        toqueJugador = GameObject.Find("Input Controller").GetComponent<MovimientoJugadorPlanetas>();
        activacionRotacionEstrella = GameObject.Find("Estrella").GetComponent<RotacionEstrella>();

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.rigidbody == toqueJugador.jugadorRb)
        {
            Debug.Log("Activacion sistema solar");
            activacionSistema = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody == toqueJugador.jugadorRb)
        {
            Debug.Log("Desactivacion sistema solar");
            activacionSistema = false;
        }
    }

    private void Update()
    {
        if (activacionSistema & Keyboard.current.enterKey.wasPressedThisFrame) ActivacionRotaciones();
    }

    void ActivacionRotaciones()
    {
        RotacionPlanetas[] rotacionPlanetas = FindObjectsByType<RotacionPlanetas>(FindObjectsSortMode.None);
        movimientoSatelites[] rotacionSatélites = FindObjectsByType<movimientoSatelites>(FindObjectsSortMode.None);

        for (int i = 0; i < rotacionPlanetas.Length; i++)
        {
            rotacionPlanetas[i].enabled = true;
        }

        for (int i = 0; i < rotacionSatélites.Length; i++)
        {
            rotacionSatélites[i].enabled = true;
        }
        activacionRotacionEstrella.enabled = true;
    }
}
