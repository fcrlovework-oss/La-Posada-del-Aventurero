using System.Collections;
using UnityEngine;

public class ControladorTiempoDeJuego : MonoBehaviour
{
    //Atributos para medir el tiempo de juego:
    [Header("Escribe aquí el tiempo de juego")]
    public float tiempoTotal;
    Disparo controladorDisparo;

    private void Awake()
    {
        controladorDisparo = GetComponent<Disparo>();
    }

    private void Start()
    {
        StartCoroutine(PasoDeTiempo());
    }

    IEnumerator PasoDeTiempo()
    {
        while (tiempoTotal > 0)
        {
            yield return new WaitForSeconds(1);
            tiempoTotal -= 1;
            Debug.Log("Tiempo de juego:" + tiempoTotal);
        }
        yield return new WaitForSeconds(1);
        Debug.Log("Se acabó el juego" + tiempoTotal);
        controladorDisparo.enabled = false;
        Time.timeScale = 0;
    }

   
}
