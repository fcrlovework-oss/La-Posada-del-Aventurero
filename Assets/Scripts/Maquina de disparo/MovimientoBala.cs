using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float velocidadDisparo;
    Rigidbody cuerpoBala;
    GameObject ObjetivoActual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        cuerpoBala = GetComponent<Rigidbody>();
        cuerpoBala.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.right * Time.deltaTime * velocidadDisparo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Objetivo"))
        {
            ObjetivoActual = collision.gameObject; //Guardamos el gameobject para luego obtener la recompensa
            Recompensas();
            collision.gameObject.SetActive(false);
        }
    }

    void Recompensas()
    {

    }
}
