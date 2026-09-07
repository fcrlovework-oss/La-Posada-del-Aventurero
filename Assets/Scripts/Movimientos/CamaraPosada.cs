using UnityEngine;

public class CamaraPosada : MonoBehaviour
{
    //Variables Camara:
    public Transform camara;
    public float sensibilidadCamara;
    public bool rotacionCamara;
    public bool zoomCamara;
    public bool posicionCamara;

    //Booleanos:
    public bool metodoAntiguo;
    public bool metodoNuevo;

    void Update()
    {
        if (rotacionCamara == true)
        {
            RotacionCamara();
        }
        if (zoomCamara == true)
        {
            ZoomCamara();
        }

        if(posicionCamara == true)
        {
            PosicionCamara();
        }
        
    }


    void RotacionCamara()
    {
        if (metodoAntiguo == true)
        {
            metodoNuevo = false;
            





        }
        else if (metodoNuevo == true) 
        {
            metodoAntiguo = false;





        }
    }
    void ZoomCamara()
    {
        if (metodoAntiguo == true)
        {
            metodoNuevo = false;
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {

            }


        }
        else if (metodoNuevo == true)
        {
            metodoAntiguo = false;
        }
    }

    void PosicionCamara()
    {
        if (metodoAntiguo == true)
        {
            metodoNuevo = false;
        }
        else if (metodoNuevo == true)
        {
            metodoAntiguo = false;
        }
    }
}
