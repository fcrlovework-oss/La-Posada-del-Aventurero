using UnityEngine;

public class PropiedadesSatelites : MonoBehaviour
{
    [Header ("Propiedad Actual de este Satélite")]
    public string propiedadActual;

    //Aqui quiero crear un array que contenga todos los metodos para luego usar un randomRange qu eelija uno especifico.
    private int posicionNombrePropiedad;
    private string[] nombresPropiedades = 
    {   
        "Resta Vida", 
        "Doble Impulso",
        "Reinicio",
        "Restauravida", 
        "Aumento Velocidad Planetas", 
        "Cambio de Propiedades"
    };

    //Con esto accedemos al script del planeta padre:
    DetectorColisionesPlanetas detectorPlanetaPadre;

    private void Awake()
    {
        detectorPlanetaPadre = GetComponentInParent<DetectorColisionesPlanetas>();
    }

    private void Update()
    {
        if (detectorPlanetaPadre.jugadorDentro == true)
        {
            ActivarPropiedad();
            detectorPlanetaPadre.jugadorDentro = false;
        }
    }



    private void Start()
    {
        posicionNombrePropiedad = Random.Range(0, nombresPropiedades.Length);
        propiedadActual = nombresPropiedades[posicionNombrePropiedad];
    }

    

    void ActivarPropiedad()
    {
        if (propiedadActual == "Resta Vida") RestaVida();
        if (propiedadActual == "Doble Impulso") DobleImpulso();
        if (propiedadActual == "Reinicio") Reinicio();
        if (propiedadActual == "Restauravida") Restauravida();
        if (propiedadActual == "Aumento Velocidad Planetas") AumentoVelocidadPlanetas();
        if (propiedadActual == "Cambio de Propiedades") CambioPropiedades();
    }
    
    //Estas propiedades solo se activan si el jugador pisa el planeta padre:
    void RestaVida()
    {

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
    void AumentoVelocidadPlanetas()
    {

    }
    void CambioPropiedades()
    {
        posicionNombrePropiedad = Random.Range(0, nombresPropiedades.Length);
        propiedadActual = nombresPropiedades[posicionNombrePropiedad];
    }
}
