using UnityEngine;

public class EjercicioProfe : MonoBehaviour
{
    //Atributos:
    public float velocidadJugador = 5;
    public float velocidadRotacionCamara = 300;
    public float velocidadZoom = 5;
    public Transform jugadoresfera;
    public Transform camaraTransform;
    public bool rotacionCamara;
    float angulovertical;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Esto mueve al jugador con las teclas, usando el metodo antiguo.
        jugadoresfera.transform.Translate(-Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * velocidadJugador);
        jugadoresfera.transform.Translate(-Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * velocidadJugador);

        if (rotacionCamara == true)
        {
            //Rotacion camara:
            camaraTransform.transform.RotateAround(jugadoresfera.transform.position, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * velocidadRotacionCamara);
        }
        else
        {
            angulovertical += Input.GetAxis("Mouse Y") * Time.deltaTime * velocidadRotacionCamara;
            angulovertical = Mathf.Clamp(angulovertical, -30, 90);
            //RotacionPlayer: Esto es mejor porque asi el player ya va hacia donde mira. y funciona porque la camara es hija del player.
            jugadoresfera.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * velocidadRotacionCamara);
            //Rotacion Vertical camara:
            camaraTransform.transform.localRotation = Quaternion.Euler(-angulovertical, 0, 0);
        }

        //Zoom Camara:
        float cercaniazoom = Vector3.Distance(jugadoresfera.transform.position, camaraTransform.transform.position);
        float valorZoom = Input.GetAxis("Mouse ScrollWheel");

        Debug.Log("distancia camara: " + cercaniazoom + ", valor zoom: " + valorZoom);

        if (cercaniazoom > 56 || valorZoom < 0)
        {
            /*camaraTransform.transform.LookAt(jugadoresfera.transform.position);
            camaraTransform.transform.Translate(camaraTransform.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * velocidadZoom); // no funciona correctamente*/
            //Esto lo propuiso chatGPT, mover la posicion de forma constante:
            camaraTransform.transform.localPosition += Vector3.forward * valorZoom * Time.deltaTime * velocidadZoom;
        }
    }
}
