using UnityEngine.InputSystem;
using UnityEngine;

public class AsignaciónDeMovimientos : MonoBehaviour
{
    public GameObject jugador;
    public GameObject mesa;
    public GameObject criatura;

    public bool sistemaAntiguo;
    public bool sistemaNuevo;

    //Para el sistema Antiguo:
    Vector3 movimientoJugadorAntiguo;
    public float velocidadJugador;
    public float velocidadCriatura;

    //Para el sistema nuevo:
    InputSystem_Actions controles;
    Vector3 movimientoJugadorNuevo;

    private void Awake()
    {
        controles = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }


    private void Start()
    {
        velocidadJugador = 5f;
        velocidadCriatura = 2f;
     


    }

    private void Update()
    {
        MascotaSigueJugador();
        if(sistemaAntiguo == true)
        {
            MovimientoJugadorAntiguo();
        }
        if (sistemaNuevo == true)
        {
            MovimientoJugadorNuevo();
        }
    }

    void MovimientoJugadorAntiguo()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movimientoJugadorAntiguo = new Vector3(-vertical, 0, horizontal);
        movimientoJugadorAntiguo.Normalize();
        jugador.transform.Translate(movimientoJugadorAntiguo * velocidadJugador * Time.deltaTime);
    }

    void MovimientoJugadorNuevo()
    {
        movimientoJugadorNuevo = controles.Player.Move.ReadValue<Vector2>();
        movimientoJugadorNuevo = new Vector3(-movimientoJugadorNuevo.y, 0, movimientoJugadorNuevo.x);
        movimientoJugadorNuevo.Normalize();
        jugador.transform.Translate(movimientoJugadorNuevo * velocidadJugador * Time.deltaTime);
    }

    void MascotaSigueJugador() 
    {
     
        Vector3 destinoMascota = jugador.transform.position - criatura.transform.position;
        float distaciaDestino = destinoMascota.magnitude;
        
        if(distaciaDestino > 4)
        {
            criatura.transform.position = Vector3.MoveTowards (criatura.transform.position, jugador.transform.position, velocidadCriatura * Time.deltaTime);
        }
        
       
    }


}
