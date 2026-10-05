using UnityEngine;

public class RotacionEstrella : MonoBehaviour
{
    [Header("Arrastra a aqui al objeto aldedor del que gira la estrella")]
    public Transform nucleoGalaxia;

    [Header("Pon aqui la velocidad de rotacion")]
    public float velocidadRotacionEstrella;

    [Header("Pon aqui la velocidad de traslacion")]
    public float velocidadTraslacionEstrella;

    private void Update()
    {
        RotacionYTraslacionEstrella();
    }

    void RotacionYTraslacionEstrella()
    {
        transform.Rotate(0, velocidadRotacionEstrella * Time.deltaTime, 0);
        transform.RotateAround(nucleoGalaxia.position, Vector3.up, velocidadTraslacionEstrella * Time.deltaTime);
    }
}
