using UnityEngine;

public class RotacionPlanetas : MonoBehaviour
{
    [Header("Velocidad de rotacion")]
    public float velocidadRotación;

    [Header("Velocidad de Traslación")]
    public float velocidadTraslacion;

    [Header("Ángulo de Rotacion X (Rotation / Quaternion")]
    public float rotacionX;

    [Header("¿Alrededor de que eje propio quieres que gire el planeta?")]
    public bool ejeX;
    public bool ejeY;
    public bool ejeZ;
   
    private void Update()
    {
        RotacionesPlaneta();
        TraslacionPlanetas();
    }

    private void RotacionesPlaneta()
    {
        //Rotacion
        if(ejeX == true)
        {
            transform.Rotate(velocidadRotación * Time.deltaTime, 0, 0);
            ejeY = false;
            ejeZ = false;
        }
        if (ejeY == true)
        {
            transform.Rotate(0, velocidadRotación * Time.deltaTime, 0);
            ejeX = false;
            ejeZ = false;
        }
        if (ejeZ == true)
        {
            transform.Rotate(0, 0, velocidadRotación * Time.deltaTime);
            ejeX = false;
            ejeY = false;
        }
        
        
    }

    void TraslacionPlanetas()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, velocidadTraslacion * Time.deltaTime);
    }
}
