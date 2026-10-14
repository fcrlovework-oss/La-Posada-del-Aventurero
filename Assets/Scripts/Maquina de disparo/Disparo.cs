using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{
    //Atributos
    Vector3 coordenadasRaton; //Esto lo usaremos para apuntar con el raton
    InputSystem_Actions movimientoRaton;
     

    [Header("arrastra a aqui la bala")]
    public GameObject bala;
    public GameObject puntoDeDisparo;

    //movimientoCañon:
    [Header("arrastra a aqui el cañon")]
    public GameObject cañon;
    Vector3 movimientoCañon;
    Vector3 rotacionCañon;

    private void Awake()
    {
        movimientoRaton = new InputSystem_Actions();
    }
    private void Start()
    {
        coordenadasRaton = Mouse.current.position.ReadValue();
    }

    private void OnEnable()
    {
        movimientoRaton.Enable();
    }

    private void OnDisable()
    {
        movimientoRaton.Disable();
    }

    private void Update()
    {
        RotacionCañon();
        DisparoBala();
    }

    //Esto aun no funciona, debe hacer que el cañon rote con el movimiento del raton:
    void RotacionCañon()
    {
        movimientoCañon = movimientoRaton.Player.Look.ReadValue<Vector2>();
        movimientoCañon = new Vector3(movimientoCañon.x, movimientoCañon.y, 0);
        rotacionCañon = new Vector3 (cañon.transform.rotation.x * movimientoCañon.x, cañon.transform.rotation.y * movimientoCañon.y, 0);
    }

    void DisparoBala()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bala, puntoDeDisparo.transform.position, Quaternion.identity);
            bala.transform.Translate(coordenadasRaton);
        }
    }
}
