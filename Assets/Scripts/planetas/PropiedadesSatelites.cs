using UnityEngine;

public class PropiedadesSatelites : MonoBehaviour
{
    // Atributos -----------------------------------------------------------------
    
    [Header ("Propiedad Actual de este Satélite")]
    public string propiedadActual;

    //Atributos para gestionar los colores de los planetas:
    InterruptorActivacionSistemaSolar reinicioColores;
    private Renderer variacionColor;
    private Color colorOriginal;

    private MovimientoJugadorPlanetas jugadorBody;
    private DetectorCaida posicionInicialDelJugador;

    //En este array guardamos los distintos tipos de regalos que se pueden obtener:
    private int regaloElegido;
    private object[] regaloSorpresa = new object[20];

    //Aqui quiero crear un array que contenga todos los metodos para luego usar un randomRange qu eelija uno especifico.
    private int posicionNombrePropiedad;
    private string[] nombresPropiedades = 
    {
        "Regalo", 
        "Doble Impulso",
        "Reinicio",
        "Restauravida", 
        "Aumento Velocidad Jugador",
        "Activa Rotacion Planeta",
        "Cambio de Propiedades"
    };

    //Con esto accedemos al script del planeta padre:
    private DetectorColisionesPlanetas detectorPlanetaPadre;
    private RotacionPlanetas RotacionPlanetaActual;

    // Metodos Básicos ---------------------------------------------------------------------------------------

    private void Awake()
    {
        detectorPlanetaPadre = GetComponentInParent<DetectorColisionesPlanetas>();
        jugadorBody = GameObject.Find("Input Controller").GetComponent<MovimientoJugadorPlanetas>();
        posicionInicialDelJugador = GameObject.Find("SueloDetectorCaida").GetComponent<DetectorCaida>();
        RotacionPlanetaActual = GetComponentInParent<RotacionPlanetas>();
        variacionColor = RotacionPlanetaActual.GetComponent<Renderer>();
        colorOriginal = variacionColor.material.color;
        reinicioColores = GameObject.Find("Interruptor").GetComponent<InterruptorActivacionSistemaSolar>();
    }

    private void Start()
    {
        //Esto da una propiedad aleatoria a cada planeta
        posicionNombrePropiedad = Random.Range(0, nombresPropiedades.Length);
        propiedadActual = nombresPropiedades[posicionNombrePropiedad];
        ActivacionColores();

        //Esto elige un regalo aleatorio:
        regaloElegido = Random.Range(0, regaloSorpresa.Length);
    }
       

    private void Update()
    {
        if(posicionInicialDelJugador.AnulacionYreinicioPropiedades)
        {
            //Reiniciamos todo cuando cae al suelo:
            Debug.Log("ReinicioPropiedades");
            jugadorBody.impulsoSalto = 1000f;
            jugadorBody.velocidadJugadorSueño = 10f;
            posicionNombrePropiedad = Random.Range(0, nombresPropiedades.Length);
            propiedadActual = nombresPropiedades[posicionNombrePropiedad];
            ActivacionColores();
            posicionInicialDelJugador.AnulacionYreinicioPropiedades = false;
        }
        if (detectorPlanetaPadre.jugadorAfectadoPropiedades)
        {
            //Con esto reiniciamos el valor del impulso en caso de que haya sido modificado por "DobleImpulso()" anteriormente.
            jugadorBody.impulsoSalto = 1000f;
            jugadorBody.velocidadJugadorSueño = 10f;
            Debug.Log("Jugador Afectado por propiedadColision");
            ActivarPropiedad();
        }
        if (reinicioColores.activacionSistema) variacionColor.material.color = colorOriginal;
    }

    //Metodos Específicos ---------------------------------------------------------------------------------------

    void ActivarPropiedad()
    {
        if (propiedadActual == "Regalo") Regalo(regaloSorpresa[regaloElegido]);
        if (propiedadActual == "Doble Impulso") DobleImpulso();
        if (propiedadActual == "Reinicio") Reinicio();
        if (propiedadActual == "Restauravida") Restauravida();
        if (propiedadActual == "Aumento Velocidad Jugador") AumentoVelocidadJugador();
        if (propiedadActual == "Activa Rotacion Planeta") ActivaRotacionPlaneta();
        if (propiedadActual == "Cambio de Propiedades") CambioPropiedades();
        detectorPlanetaPadre.jugadorAfectadoPropiedades = false;
    }

    void ActivacionColores()
    {
        if (propiedadActual == "Regalo") variacionColor.material.color = new Color (0.83f, 0.69f, 0.22f); //Dorado
        if (propiedadActual == "Doble Impulso") variacionColor.material.color = new Color(1f, 0.4f, 0.7f); //Rosa
        if (propiedadActual == "Reinicio") variacionColor.material.color = Color.blue;
        if (propiedadActual == "Restauravida") variacionColor.material.color = Color.green;
        if (propiedadActual == "Aumento Velocidad Jugador") variacionColor.material.color = new Color(1f, 0.5f, 0f); //Naranja
        if (propiedadActual == "Activa Rotacion Planeta") variacionColor.material.color = new Color(0.55f, 0.27f, 0.07f); //Marrón
        if (propiedadActual == "Cambio de Propiedades") variacionColor.material.color = new Color(0.5f, 0f, 0.5f); //Morado
    }
    
    //Estas propiedades solo se activan si el jugador pisa el planeta padre:
    void Regalo(object regaloSorpresa)
    {

        //esto lo programaré cuando aprenda la parte de inventario.
        print("Has acumulado un regalo");
    }

    void DobleImpulso()
    {
        jugadorBody.impulsoSalto += 500f;
    }

    void Reinicio()
    {
        jugadorBody.jugadorSueño.transform.position = posicionInicialDelJugador.posicionoriginalJugador;
    }

    void Restauravida()
    {
        jugadorBody.vidaJugadorPlanetas = 10;
        Debug.Log("Tu vida ha sido restaurada: " + jugadorBody.vidaJugadorPlanetas);
    }
    void AumentoVelocidadJugador()
    {
        jugadorBody.velocidadJugadorSueño += 30f;
    }

    void ActivaRotacionPlaneta()
    {
        RotacionPlanetaActual.enabled = true;
    }
    void CambioPropiedades()
    {
        posicionNombrePropiedad = Random.Range(0, nombresPropiedades.Length);
        propiedadActual = nombresPropiedades[posicionNombrePropiedad];
    }
}
