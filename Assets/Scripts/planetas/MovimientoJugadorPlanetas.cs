using UnityEngine;

public class MovimientoJugadorPlanetas : MonoBehaviour
{
    //GameObjects con movimiento de la escena:
    public GameObject jugadorSueño;
    [HideInInspector]
    public int vidaJugadorPlanetas;

    //elementos para el salto:
    [Header("Indica aquí el impulso del salto")]
    public float impulsoSalto;
    [HideInInspector]
    public Rigidbody rigidbodyJugadorSueño;
    private bool jugadorpuedeSaltar;

    //Movimiento jugador:
    Vector3 movimientoJugadorPlanetas;
    InputSystem_Actions controlesMovimiento;
    public float velocidadJugadorSueño;

    //esto luego se borra:
    [HideInInspector]
    public Vector3 posicionoriginalJugador;

    private void Awake()
    {
        controlesMovimiento = new InputSystem_Actions();
        rigidbodyJugadorSueño = jugadorSueño.GetComponent<Rigidbody>();


        //Con esto evitamos que le afecte la rotacion en todos los angulos.
        rigidbodyJugadorSueño.constraints = RigidbodyConstraints.FreezeRotation;

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
        velocidadJugadorSueño = 5f;
        posicionoriginalJugador = jugadorSueño.transform.position;
        vidaJugadorPlanetas = 10;

        //Esto guarda la rotacion inicial de la camara:
        //rotacioninicialCamara = camaraplanetas.transform.localRotation;
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
