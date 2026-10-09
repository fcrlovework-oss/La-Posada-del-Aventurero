using System.Collections;
using UnityEngine;

public class MovimientoJugadorPlanetas : MonoBehaviour
{
    //Atributos necesarios para movimiento y salto del jugador:
    public GameObject jugadorSueño;
    Vector3 movimientoJugadorPlanetas;
    public float velocidadJugadorSueño;
    [HideInInspector] public static bool GravedadActiva;

    [Header("Indica aquí el impulso del salto")]
    public float impulsoSalto = 1000;

    [HideInInspector] public InputSystem_Actions controlesMovimiento;
    [HideInInspector] public Rigidbody jugadorRb;

    //Vida del jugador:
    [HideInInspector] public int vidaJugadorPlanetas = 10;

    private void Awake()
    {
        //Aactivamos los sistemas de movimiento:
        controlesMovimiento = new InputSystem_Actions();

        //Buscamos el Rigidbody del jugador:
        jugadorRb = jugadorSueño.GetComponent<Rigidbody>();

        //Con esto evitamos que al jugador le afecte la rotacion en todos los angulos.
        jugadorRb.constraints = RigidbodyConstraints.FreezeRotation;

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
        vidaJugadorPlanetas = 10;
        velocidadJugadorSueño = 10f;
        Debug.Log("Tienes: " + vidaJugadorPlanetas + " vidas");
        //Esto guarda la rotacion inicial de la camara:
        //rotacioninicialCamara = camaraplanetas.transform.localRotation;
    }
    
    // Update is called once per frame
    void Update()
    {
        MovimientoJugador();
        if (DetectorColisionesPlanetas.jugadorPuedeSaltar == true) Saltar();
    }

    void MovimientoJugador()
    {
        //Con esto se mueve:
        movimientoJugadorPlanetas = controlesMovimiento.Player.Move.ReadValue<Vector2>();
        movimientoJugadorPlanetas = new Vector3(-movimientoJugadorPlanetas.y, 0, movimientoJugadorPlanetas.x);
        movimientoJugadorPlanetas.Normalize();
        jugadorSueño.transform.Translate(movimientoJugadorPlanetas * velocidadJugadorSueño * Time.deltaTime);    
    }

    void Saltar()
    {
        if (controlesMovimiento.Player.Jump.triggered)
        {
            GravedadActiva = false; //Desactivamos la gravedad del planeta o no podremos saltar.
            Debug.Log("Comienza salto");
            DetectorColisionesPlanetas.jugadorPuedeSaltar = false;
            jugadorRb.AddForce(Vector3.up * impulsoSalto);
            StartCoroutine(ControlGravedad());
        }
    }

    IEnumerator ControlGravedad()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Activo Gravedad con corrutina");
        MovimientoJugadorPlanetas.GravedadActiva = true;

    }

}
