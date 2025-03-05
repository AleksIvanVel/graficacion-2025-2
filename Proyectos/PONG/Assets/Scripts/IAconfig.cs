using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IAconfig : MonoBehaviour
{
    public Text difPri, difInte, difAv, ladoIzq, ladoDer;
    public static int dificultadJuego;
    public static char ladoJuego;

    // Start is called before the first frame update
    void Start()
    {
        dificultadJuego = 1;
        ladoJuego = 'i';
        difPri.gameObject.SetActive(true);
        difInte.gameObject.SetActive(false);
        difAv.gameObject.SetActive(false);

        ladoIzq.gameObject.SetActive(true);
        ladoDer.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //subrayado de las dificultades
        if(Input.GetKey(KeyCode.Alpha1)){
            difPri.gameObject.SetActive(true);
            difInte.gameObject.SetActive(false);
            difAv.gameObject.SetActive(false);
            dificultadJuego = 1;
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            difPri.gameObject.SetActive(false);
            difInte.gameObject.SetActive(true);
            difAv.gameObject.SetActive(false);
            dificultadJuego = 2;
        }
        if(Input.GetKey(KeyCode.Alpha3)){
            difPri.gameObject.SetActive(false);
            difInte.gameObject.SetActive(false);
            difAv.gameObject.SetActive(true);
            dificultadJuego = 3;
        }

        //subrayado del lado de juego seleccionado
         if(Input.GetKey(KeyCode.I)){
            ladoIzq.gameObject.SetActive(true);
            ladoDer.gameObject.SetActive(false);
            ladoJuego = 'i';
        }
        if(Input.GetKey(KeyCode.D)){
            ladoIzq.gameObject.SetActive(false);
            ladoDer.gameObject.SetActive(true);
            ladoJuego = 'd';
        }
        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("Main");
        }
        if(Input.GetKey(KeyCode.Escape)){
             SceneManager.LoadScene("Configuracion");
        }
    }
}
