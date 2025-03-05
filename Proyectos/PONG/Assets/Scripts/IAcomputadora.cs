using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public GameObject miPelota;
    Vector3 posicionPelota;
    float velocidad = 1.0f;
    float velocidadComputadora;
    private GameObject jugadorIzq, jugadorDer, jugadorIA;


    // Start is called before the first frame update
    void Start()
    {
       jugadorIzq = GameObject.Find("JugadorIzq").gameObject;
        jugadorDer = GameObject.Find("JugadorDer").gameObject;

        // Asigna la IA al jugador contrario
        if (IAconfig.ladoJuego == 'i')
        {
            jugadorIA = jugadorDer; // IA juega en el lado derecho
        }
        else
        {
            jugadorIA = jugadorIzq; // IA juega en el lado izquierdo
        }

        // Agregar este script al jugador correcto
        gameObject.name = jugadorIA.name;  // Asegurar que el objeto con el script sea el correcto

        //asigan el nivel de dificultad
        switch (IAconfig.dificultadJuego){
            case 1:
                velocidadComputadora = 5000.00f;
            break;
            case 2:
                velocidadComputadora = 3000.00f;
            break;
            case 3:
                velocidadComputadora = 2000.00f;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Configuracion.tipoJuego == 1){
            float deltaY = velocidad * Time.deltaTime + (float)Pelota.numToques / velocidadComputadora;
            posicionPelota = miPelota.gameObject.transform.position;
            if(posicionPelota.x >= -9 && posicionPelota.x <= 9){ //Pelota en el terreno de juego
                jugadorIA.transform.position = Vector3.MoveTowards(
                    jugadorIA.gameObject.transform.position, 
                    new Vector3( jugadorIA.gameObject.transform.position.x, posicionPelota.y , 0), 
                    deltaY
                );
            }else{
                jugadorIzq.transform.position = new Vector3(-8, 0, 0);
                jugadorDer.transform.position = new Vector3(8, 0, 0);
            }

        }
    }
}
