using UnityEngine;

public class GravedadPlanetas : MonoBehaviour
{
    [Header("Escribe aqui el radio de deteccion del planeta")]
    public float radioDeteccion;

    [Header("Fuerza de gravedad del planeta")]
    public float gravedadPlaneta;
    Rigidbody playerbody;
    Vector3 direccionGravedad;

    private void Awake()
    {
        playerbody = GameObject.Find("Jugador").GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Collider[] objetos = Physics.OverlapSphere(transform.position, radioDeteccion);
        for (int i = 0; i < objetos.Length; i++)
        {
            Debug.Log("Entra en el bucle de gravedad");
            Rigidbody rbObjeto = objetos[i].GetComponent<Rigidbody>();
            if(rbObjeto == playerbody)
            {
                Debug.Log("Jugador Gravedad");
                direccionGravedad = transform.position - playerbody.transform.position;
                playerbody.AddForce(direccionGravedad.normalized * gravedadPlaneta);

                //queda pendiente arreglar esto:
                if (MovimientoJugadorPlanetas.fueraGravedad == true) return;
            }
        }
        
    }
}
