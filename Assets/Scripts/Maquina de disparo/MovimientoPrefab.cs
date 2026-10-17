using UnityEngine;

public class MovimientoPrefab : MonoBehaviour
{
    //Atributos movimiento:
    [Header("Indica el tipo del prefab")]
    public bool bolaDeFuego;
    public bool veneno;
    public bool agua;
    public bool hoja;
    public bool estrella;
    public bool pollito;

    
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
        transform.Translate(transform.forward * velocidadPrefab * Time.deltaTime, Space.Self);
    }

}
