using UnityEngine;

public class MovimientoPrefab : MonoBehaviour
{
    //Atributos movimiento:
    [Header("Indica la dirección")]
    public Vector3 direccionPrefab;

    [Header("Indica la velocidad")]
    public float velocidadPrefab;

    Rigidbody prefabRb;

    private void Awake()
    {
        prefabRb = GetComponent<Rigidbody>();
        prefabRb.constraints = RigidbodyConstraints.FreezeRotationY;
    }

    private void Update()
    {
        transform.Translate(direccionPrefab.normalized * velocidadPrefab * Time.deltaTime);
    }

}
