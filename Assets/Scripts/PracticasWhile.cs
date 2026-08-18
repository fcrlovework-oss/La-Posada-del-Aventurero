using UnityEngine;

public class PracticasWhile : MonoBehaviour
{
    //Variables Públicas
    public bool cuentaAtras;
    public bool ahorrarMonedas;
    public bool contraseñaSecreta;
    public bool dadoInfinito;
    public string contraseñaUsuario = null;

    //Variables privadas
    string contraseña = "Mapache";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cuentaAtras = false;
        ahorrarMonedas = false;
        contraseñaSecreta = false;
        dadoInfinito = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cuentaAtras == true)
        {
            CuentaAtras();
            cuentaAtras = false;
        }

        if (ahorrarMonedas == true)
        {
            AhorrarMonedas();
            ahorrarMonedas = false;
        }

        if (contraseñaSecreta == true)
        {
            ContraseñaSecreta();
            contraseñaSecreta = false;
        }

        if (dadoInfinito == true)
        {
            DadoInfinito();
            dadoInfinito = false;
        }
    }
    //Usa while para imprimir una cuenta atras y la palabra ¡Despegue! cuando acabes.
    void CuentaAtras()
    {
        int cuentaAtras = 5;

        while (cuentaAtras > 0)
        {
            Debug.Log(cuentaAtras);
            cuentaAtras--;

        }
        Debug.Log("¡Despegue!");
    }

    //quieres ahorrar 100 monedas, usa while para ganar 15 en cada bucle y cuando consigas las 100 imprime "¡Ya puedes comprar el objeto!
    void AhorrarMonedas()
    {
        int monedas = 0;
        while(monedas < 100)
        {
            monedas += 15;
            Debug.Log("Tienes " +  monedas);
        }
        Debug.Log("¡Ya puedes comprar el objeto!");
    }

    //comprueba si la contraseña que pone el usuario es correcta, cuando lo sea, imprime "¡Acceso conseguido!", minetras tanto, "contraseña incorrecta"
    void ContraseñaSecreta()
    {  
        if(contraseñaUsuario == contraseña)
        {
            Debug.Log("¡Acceso conseguido!");
        }
        else
        {
            Debug.Log("contraseña incorrecta");
        }
    }

    void DadoInfinito()
    {             
       while (true)
       {
          int dado = Random.Range(1, 7);
          Debug.Log("Sacaste un... " + dado);
          if (dado == 6)
          {
            Debug.Log("¡Ganaste!");
            break;
          }
       }
        
    }

}
