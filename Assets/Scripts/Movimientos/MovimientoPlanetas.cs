using UnityEngine;

public class MovimientoPlanetas : MonoBehaviour
{
    /*¿Que vamos a hacer aqui?
    1. Configurar el movimiento normal del jugador (adelante, atras y a los lados) // ¡HECHO!//
    2. rotacion sobre si mismo de todos losplanetas y la estrella. // ¡¡HECHO!! //
    3. Hacer que todos los planetas giren alrededor de la estrella. // ¡¡HECHO!! //
    4. Haremos que la camara mire y siga al jugador. Y pueda controlarse con el raton.
     */

    //camara:
    public Camera camaraJugador;
    public float velocidadCamara;
    Vector3 rotacionCamara;
    public Vector3 posicionamientoCamara;
    public float sensibilidadCamara;


    //GameObjects con movimiento de la escena:
    public GameObject jugadorSueño;
    public GameObject estrella;
    public GameObject planeta1;
    public GameObject planeta2;
    public GameObject planeta3;
    public GameObject planeta4;
    public GameObject plataformaInicial;

    //Movimineto jugador:
    Vector3 movimientoJugadorPlanetas;
    InputSystem_Actions controlesPlanetas;
    public bool movimientoDesdeOtroScript;
    public float velocidadJugadorSueño;

    //Velocidades:
    float velocidadEstrella;
    float velocidadPlaneta1;
    float velocidadPlaneta2;
    float velocidadPlaneta3;
    float velocidadPlaneta4;

    private void Awake()
    {
        controlesPlanetas = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        controlesPlanetas.Enable();
    }

    private void OnDisable()
    {
        controlesPlanetas.Disable();
    }

    void Start()
    {
        sensibilidadCamara = 4f;
        velocidadJugadorSueño = 5f;
        velocidadEstrella = 5f;
        velocidadPlaneta1 = 8f;
        velocidadPlaneta2 = 5f;
        velocidadPlaneta3 = 10f;
        velocidadPlaneta4 = 4f;
        estrella.transform.rotation = Quaternion.Euler(30f, 0f, 0f);
        planeta1.transform.rotation = Quaternion.Euler(50f, 0f, 0f);
        planeta2.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        CamaraEscena();
        Rotaciones();
        if (movimientoDesdeOtroScript == true)
        {
            //aqui tratariamos de crear el movimiento desde el otro script, pero habría que modificar un objeto desde aqui(el del jugador), todavía no sabemos.
        }
        else
        {
            MovimientoJugadorPlanetas();
        }
    }

    void MovimientoJugadorPlanetas()
    {
        movimientoJugadorPlanetas = controlesPlanetas.Player.Move.ReadValue<Vector2>();
        movimientoJugadorPlanetas = new Vector3(-movimientoJugadorPlanetas.y, 0, movimientoJugadorPlanetas.x);
        movimientoJugadorPlanetas.Normalize();
        jugadorSueño.transform.Translate(movimientoJugadorPlanetas * velocidadJugadorSueño * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        //Dibujamos un Gizmo, una raya del eje y)
        Gizmos.DrawLine(estrella.transform.position + Vector3.down * 7, estrella.transform.position + Vector3.up * 7);
        
    }

    void Rotaciones()
    {
        estrella.transform.Rotate(0, velocidadEstrella * Time.deltaTime, 0);
        planeta1.transform.Rotate(velocidadPlaneta1 * Time.deltaTime, 0, 0);
        planeta2.transform.Rotate(0, 0, velocidadPlaneta2 * Time.deltaTime);
        planeta3.transform.Rotate(0, velocidadPlaneta3 * Time.deltaTime, 0);
        planeta4.transform.Rotate(velocidadPlaneta4 * Time.deltaTime, 0, 0);
        Translaciones();
    }

    void Translaciones()
    {
        planeta1.transform.RotateAround(estrella.transform.position, Vector3.up, 9f * Time.deltaTime);
        planeta2.transform.RotateAround(estrella.transform.position, Vector3.up, 10f * Time.deltaTime);
        planeta3.transform.RotateAround(estrella.transform.position, Vector3.up, 8f * Time.deltaTime);
        planeta4.transform.RotateAround(estrella.transform.position, Vector3.up, 7f * Time.deltaTime);
    }

    void CamaraEscena()
    {
        rotacionCamara = controlesPlanetas.Player.Look.ReadValue<Vector2>();
        camaraJugador.transform.position = jugadorSueño.transform.position + posicionamientoCamara;
        camaraJugador.transform.LookAt(jugadorSueño.transform);


    }


}
