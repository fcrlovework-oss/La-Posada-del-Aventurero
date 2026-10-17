using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{
    //Atributos
    Vector3 coordenadasRaton; //Esto lo usaremos para apuntar con el raton
     

    [Header("arrastra a aqui la bala")]
    public GameObject bala;
    public GameObject puntoDeDisparo;

    //movimientoCañon:
    InputSystem_Actions movimientoRaton;
    [Header("arrastra a aqui el cañon")]
    public GameObject cañon;
    Vector3 rotacionCañon;
    Quaternion rotacionOriginal;

    [Header("Escribe aqui la velocidad de rotacion del cañon")]
    public float velocidadRotacionCañon;
    

    private void Awake()
    {
        movimientoRaton = new InputSystem_Actions();
        rotacionOriginal = cañon.transform.rotation;
    }

    private void OnEnable()
    {
        movimientoRaton.Enable();
    }

    private void OnDisable()
    {
        movimientoRaton.Disable();
    }
    private void Start()
    {
        coordenadasRaton = Mouse.current.position.ReadValue(); //con esto conseguimos la posicion del raton.
    }  

    private void Update()
    {
        Debug.Log ("Posicion Ratón: " + coordenadasRaton);
        RotacionCañon();
        DisparoBala();
    }

    //Esto aun no funciona, debe hacer que el cañon rote con el movimiento del raton:
    void RotacionCañon() //Esto lo escribio chat gpt vamos a tratar d eentenderlo.
    {
        
    }

    void DisparoBala()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bala, puntoDeDisparo.transform.position, Quaternion.identity);
        }
    }
}
