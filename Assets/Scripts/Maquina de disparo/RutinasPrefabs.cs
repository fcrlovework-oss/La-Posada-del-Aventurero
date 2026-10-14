using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasPrefabs : MonoBehaviour
{
    [Header("Escribe aqui la frecuencia de aparicion del elemento")]
    public float tiempoRutina;

    [Header("Arrastra a aqui el prefab correspondiente")]
    public GameObject PrefabGenerador;

    [Header("Escribe el número máximo de prefabs a instanciar")]
    public int cantidadPrefab;

    [Header("Marca esta casilla si el GameObject debe desaparecer y a continuacion especifica el tiempo")]
    public bool desaparicionPrefab = false;
    public float tiempoDesaparicion;






    private void Start()
    {
        StartCoroutine(RutinaPrefab(tiempoRutina));
    }
    IEnumerator RutinaPrefab(float segundos)
    {
        List<GameObject> prefabs = new List<GameObject>();
        while (prefabs.Count < cantidadPrefab)
        {
            GameObject nuevoPrefab = Instantiate(PrefabGenerador, transform.position, transform.rotation);
            prefabs.Add(nuevoPrefab);
            yield return new WaitForSeconds(segundos);
        }
        Debug.Log("Creación de " + PrefabGenerador.name + " completada");
        
        //ahora hacemos desaparecer los gameobjects:
        if(desaparicionPrefab)
        {
            yield return new WaitForSeconds(tiempoDesaparicion);
            for (int i = 0; i < prefabs.Count; i++)
            {
                prefabs[i].SetActive(false);
            }
            Debug.Log("Todos los prefabs " + PrefabGenerador.name + " han sido eliminados");
        }

    }
}


