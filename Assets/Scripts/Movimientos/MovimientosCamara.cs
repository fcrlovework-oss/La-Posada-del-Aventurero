using UnityEngine;

public class MovimientosCamara : MonoBehaviour
{
    //Atributos:
    InputSystem_Actions camaraActions;
    MovimientoJugadorPlanetas jugadorEscenaPlanetas;
    public Transform camaraplanetas;
    public float velocidadRotacionCamara = 200;
    public float velocidadZoom = 50;
    float anguloVerticalCamara;
    float anguloVerticalCamaraNueva;
    Vector3 rotacionInicialCamara;
    Vector3 movimientosCamara;
    float lectorZoom;

    public bool metodoAntiguo;
    public bool metodoNuevo;

    private void Awake()
    {
        camaraActions = new InputSystem_Actions();
        jugadorEscenaPlanetas = GetComponent<MovimientoJugadorPlanetas>();
    }

    private void OnEnable()
    {
        camaraActions.Enable();
    }

    private void OnDisable()
    {
        camaraActions.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotacionInicialCamara = camaraplanetas.transform.localEulerAngles; //guardamos angulos iniciales
    }

    // Update is called once per frame
    void Update()
    {
        if(metodoAntiguo)
        {
            ConfiguracionCamaraAntigua();
            metodoNuevo = false;
        }

        if (metodoNuevo)
        {
            ConfiguracionCamaraNueva();
            metodoAntiguo = false;
        }
    }

    void ConfiguracionCamaraAntigua()
    {
        //rotacion Horizontal camara:
        jugadorEscenaPlanetas.jugadorSueño.transform.Rotate(jugadorEscenaPlanetas.jugadorSueño.transform.up * Input.GetAxis("Mouse X") * Time.deltaTime * velocidadRotacionCamara);

        //Rotacion Vertical Camara:
        anguloVerticalCamara += Input.GetAxis("Mouse Y") * Time.deltaTime * velocidadRotacionCamara; //guardamos el movimiento vertical del raton en una variable para luego asociarlo a la rotacion vertical de la camara.
        anguloVerticalCamara = Mathf.Clamp(anguloVerticalCamara, -30, 30); //ponemos limites a las rotaciones verticales para que no gire sobre si mismo.
        camaraplanetas.transform.localRotation = Quaternion.Euler(rotacionInicialCamara.x - anguloVerticalCamara, rotacionInicialCamara.y, rotacionInicialCamara.z); //ponemos los angulos iniciales que registramos y al de x le restamos(porque esta invertido) el movimineto del raton vertical.

        //Zoom Camara:
        float distanciaJugadorCamara = Vector3.Distance(jugadorEscenaPlanetas.jugadorSueño.transform.position, camaraplanetas.transform.position);
        float zoomTrasero = Input.GetAxis("Mouse ScrollWheel");

        if (distanciaJugadorCamara > 4.37f || zoomTrasero < 0)
        {
            camaraplanetas.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * velocidadZoom * Time.deltaTime);
        }

    }
    void ConfiguracionCamaraNueva()
    {
        movimientosCamara = camaraActions.Player.Look.ReadValue<Vector2>();
        movimientosCamara = new Vector3(movimientosCamara.x, movimientosCamara.y, 0); 

        //Rotacion Horizontal:
        jugadorEscenaPlanetas.jugadorSueño.transform.Rotate(jugadorEscenaPlanetas.jugadorSueño.transform.up * movimientosCamara.x * Time.deltaTime * velocidadRotacionCamara);

        //Rotacion Vertical:
        anguloVerticalCamaraNueva += movimientosCamara.y * Time.deltaTime * velocidadRotacionCamara;
        anguloVerticalCamara = Mathf.Clamp(anguloVerticalCamaraNueva, -30, 30);
        camaraplanetas.transform.localRotation = Quaternion.Euler(rotacionInicialCamara.x - anguloVerticalCamaraNueva, rotacionInicialCamara.y, rotacionInicialCamara.z);

        //zoom
        lectorZoom = camaraActions.Player.Zoom.ReadValue<float>();
        float distanciaJugadorCamara = Vector3.Distance(jugadorEscenaPlanetas.jugadorSueño.transform.position, camaraplanetas.transform.position);

        if(distanciaJugadorCamara > 4.37f || lectorZoom < 0)
        camaraplanetas.transform.Translate(Vector3.forward * lectorZoom * Time.deltaTime * velocidadZoom);
    }
}
