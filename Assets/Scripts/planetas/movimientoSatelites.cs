using UnityEngine;

public class movimientoSatelites : MonoBehaviour
{
    //Distintos ejes de rotacion de los satelites:
    private Vector3 ejeRotacion;

    //Bools para elegir el eje de rotacion:
    [Header("Elige el eje de rotacion del Satélite")]
    public bool right;
    public bool up;
    public bool forward;

    //Velocidad rotacion:
    [Header("Elige la velocidad de rotacion del Satélite")]
    public float velocidadRotacion;

    // Update is called once per frame
    void Update()
    {
        ConfigurarRotacion();
        transform.RotateAround(transform.parent.position, ejeRotacion, velocidadRotacion * Time.deltaTime);
    }

    //Este método configura una rotación:
    void ConfigurarRotacion()
    {
        if(right == true) ejeRotacion = transform.parent.right;
        if (up == true) ejeRotacion = transform.parent.up;
        if (forward == true) ejeRotacion = transform.parent.forward;     
    }
}
