using UnityEngine;

public class MovimientoJugadorPlanetas : MonoBehaviour
{
    //GameObjects con movimiento de la escena:
    public GameObject jugadorSueño;

    //elementos para el salto:
    [Header("Indica aquí el impulso del salto")]
    public float impulsoSalto;
    Rigidbody rigidbodyJugadorSueño;
    private bool jugadorpuedeSaltar;

    //Movimiento jugador:
    Vector3 movimientoJugadorPlanetas;
    InputSystem_Actions controlesMovimiento;
    public float velocidadJugadorSueño;

    private void Awake()
    {
        controlesMovimiento = new InputSystem_Actions();
        rigidbodyJugadorSueño = jugadorSueño.GetComponent<Rigidbody>();
        
    }
    private void OnEnable()
    {
        controlesMovimiento.Enable();
    }

    private void OnDisable()
    {
        controlesMovimiento.Disable();
    }

    void Start()
    {
        Debug.Log("Inicio MouseX" + Input.GetAxis("Mouse X"));
        velocidadJugadorSueño = 5f;

        //Esto guarda la rotacion inicial de la camara:
        //rotacioninicialCamara = camaraplanetas.transform.localRotation;
    }


    private void OnCollisionStay(Collision collision)
    {
        jugadorpuedeSaltar = true;
        
    }
    private void OnCollisionExit(Collision collision)
    {
        jugadorpuedeSaltar = false;
    }
    // Update is called once per frame
    void Update()
    {
        MovimientoJugador();
        //if (controlesMovimiento.Player.Jump.triggered & jugadorpuedeSaltar) Saltar();
        Saltar();
    }



    void MovimientoJugador()
    {
        //Con esto se mueve:
        movimientoJugadorPlanetas = controlesMovimiento.Player.Move.ReadValue<Vector2>();
        movimientoJugadorPlanetas = new Vector3(-movimientoJugadorPlanetas.y, 0, movimientoJugadorPlanetas.x);
        movimientoJugadorPlanetas.Normalize();
        jugadorSueño.transform.Translate(movimientoJugadorPlanetas * velocidadJugadorSueño * Time.deltaTime);    
    }

    public void Saltar()
    {
        if (controlesMovimiento.Player.Jump.triggered) 
        rigidbodyJugadorSueño.AddForce(Vector3.up * impulsoSalto);
    }


   
}
