using UnityEngine;

public class MovimientoPrefab : MonoBehaviour
{
    //Atributos movimiento:
    [Header("Indica la dirección")]

    [Header("Indica la velocidad")]
    public float velocidadPrefab;

    Rigidbody prefabRb;

    private void Awake()
    {
        prefabRb = GetComponent<Rigidbody>();
        prefabRb.constraints = RigidbodyConstraints.FreezeRotationX;
        prefabRb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        transform.Translate(transform.forward * velocidadPrefab * Time.deltaTime);
    }

}
