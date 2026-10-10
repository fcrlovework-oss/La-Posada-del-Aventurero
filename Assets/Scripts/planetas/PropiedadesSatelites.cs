using UnityEngine;

public class PropiedadesSatelites : MonoBehaviour
{
    [Header ("Propiedad Actual de este Satélite")]
    public string propiedadActual;

    MovimientoJugadorPlanetas jugadorBody;
    private bool jugadorAfectado = false;

    //En este array guardamos los distintos tipos de regalos que se pueden obtener:
    private int regaloElegido;
    object[] regaloSorpresa = new object[20];

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
    DetectorColisionesPlanetas detectorPlanetaPadre;

    private void Awake()
    {
        detectorPlanetaPadre = GetComponentInParent<DetectorColisionesPlanetas>();
        jugadorBody = GameObject.Find("Input Controller").GetComponent<MovimientoJugadorPlanetas>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == jugadorBody.jugadorRb) jugadorAfectado = true;
    }

    private void Update()
    {
        if (jugadorAfectado) ActivarPropiedad();
    }

    private void Start()
    {
        //Esto da una propiedad aleatoria a cada planeta
        posicionNombrePropiedad = Random.Range(0, nombresPropiedades.Length);
        propiedadActual = nombresPropiedades[posicionNombrePropiedad];

        //Esto elige un regalo aleatorio:
        regaloElegido = Random.Range(0, regaloSorpresa.Length);
    }

    void ActivarPropiedad()
    {
        if (propiedadActual == "Regalo") Regalo(regaloSorpresa[regaloElegido]);
        if (propiedadActual == "Doble Impulso") DobleImpulso();
        if (propiedadActual == "Reinicio") Reinicio();
        if (propiedadActual == "Restauravida") Restauravida();
        if (propiedadActual == "Aumento Velocidad Jugador") AumentoVelocidadJugador();
        if (propiedadActual == "Activa Rotacion Planeta") ActivaRotacionPlaneta();
        if (propiedadActual == "Cambio de Propiedades") CambioPropiedades();
    }
    
    //Estas propiedades solo se activan si el jugador pisa el planeta padre:
    void Regalo(object regaloSorpresa)
    {
        //esto lo programaré cuando aprenda la parte de inventario.
    }

    void DobleImpulso()
    {

    }

    void Reinicio()
    {

    }

    void Restauravida()
    {

    }
    void AumentoVelocidadJugador()
    {

    }

    void ActivaRotacionPlaneta()
    {

    }
    void CambioPropiedades()
    {
        posicionNombrePropiedad = Random.Range(0, nombresPropiedades.Length);
        propiedadActual = nombresPropiedades[posicionNombrePropiedad];
    }
}
