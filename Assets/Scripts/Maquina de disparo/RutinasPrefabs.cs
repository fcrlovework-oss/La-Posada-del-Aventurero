using System.Collections;
using UnityEngine;

public class RutinasPrefabs : MonoBehaviour
{
    [Header("Escribe aqui la frecuencia de aparicion del elemento")]
    public float tiempoRutina;

    [Header("Arrastra a aqui el prefab correspondiente")]
    public GameObject PrefabGenerador;


    private void Start()
    {
        StartCoroutine(RutinaPrefab(tiempoRutina));
    }
    IEnumerator RutinaPrefab(float segundos)
    {
        while (true)
        {
            Instantiate(PrefabGenerador, transform.position, transform.rotation);
            yield return new WaitForSeconds(segundos);
        }
    }
}


