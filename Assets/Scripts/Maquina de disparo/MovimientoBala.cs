using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoBala : MonoBehaviour
{
    public float velocidadDisparo;
    Rigidbody cuerpoBala;
    GameObject ObjetivoActual;
    MovimientoPrefab DatosPrefabActual;

    //Atributos para controlar el movimiento:
    


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
            ObjetivoActual = collision.gameObject; //Guardamos el gameobject para luego obtener la recompensa.
            Recompensas();
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    

    void Recompensas()
    {
        DatosPrefabActual = ObjetivoActual.GetComponent<MovimientoPrefab>();

        if (DatosPrefabActual.bolaDeFuego)
        {
            Posada.saldoJugador += 10;
            Debug.Log("¡Eliminaste una Bola de Fuego!, ¡Has ganado 10 monedas!");
        }

        if (DatosPrefabActual.hoja)
        {
            Posada.saldoJugador += 15;
            Debug.Log("¡Eliminaste una Hoja!, ¡Has ganado 15 monedas!");
        }

        if (DatosPrefabActual.agua)
        {
            Posada.saldoJugador += 10;
            Debug.Log("¡Eliminaste una Gota de Agua!, ¡Has ganado 10 monedas!");
        }

        if (DatosPrefabActual.veneno)
        {
            Posada.saldoJugador -= 5;
            Debug.Log("¡Tocaste el Veneno!, ¡Has perdido 5 monedas!");
        }

        if (DatosPrefabActual.pollito)
        {
            Posada.saldoJugador -= 20;
            Debug.Log("¡Mataste a un pollito!, ¡Perdiste 20 monedas!");
        }

        if (DatosPrefabActual.estrella)
        {
            Posada.saldoJugador += 15;
            Debug.Log("¡Le diste a una estrella!, ¡Ganaste 15 monedas!");
        }
        Debug.Log("Tu saldo Actual es de: " + Posada.saldoJugador);
    }
}
