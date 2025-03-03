using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip sndSilbato, sndGameOver;

    public Text txtGameOver;
    public GameObject txtMarcador;
    private GameObject pelota;
    private int MaxPunt = 5; // Puntaje Maximo para terminar el juego


    public static float velBola = 5.0f, velJugador = 6.5f; // Valores para las velocidades de los objetos del juego
    public int signoX, signoY, velocidad = 1;

    void Start()
    {

        txtGameOver.gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();
        pelota = GameObject.Find("pelota");
        txtMarcador = GameObject.Find("txtMarcador");
        txtMarcador.GetComponent<Text>().text = "0 - 0";

        if (Random.Range(0,1) > 0.5f)
        {
            signoX = 1;
        }
        else
        {
            signoX = -1;
        }

        StartCoroutine(ArbitroPitaInicio());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Inicio");
            Pelota.golesJugDer = 0;
            Pelota.golesJugIzq = 0;
        }

        if (Pelota.golesJugDer == MaxPunt || Pelota.golesJugIzq == MaxPunt)
        {
            if (Input.anyKey)
            {
                Pelota.golesJugDer = 0;
                Pelota.golesJugIzq = 0;
                SceneManager.LoadScene("Configuracion");
            }
        }
    }

    public void EscribirMarcador()
    {
        txtMarcador.GetComponent<Text>().text = Pelota.golesJugIzq.ToString() + " - " + Pelota.golesJugDer.ToString();
        if (Pelota.golesJugDer == MaxPunt || Pelota.golesJugIzq == MaxPunt) 
        {
            txtGameOver.gameObject.SetActive(true);
            audio.clip = sndGameOver;
            audio.Play();
        } else
        {
            StartCoroutine(ArbitroPitaInicio());
        }
    }

    IEnumerator ArbitroPitaInicio()
    {
        yield return new WaitForSeconds(1.0f); // Tiempo en segundos que toma al juego lanzar la pelota
        LanzaPelota();
    }

    public void LanzaPelota()
    {
        audio.clip = sndSilbato;
        audio.Play();
        pelota.transform.position = gameObject.transform.position = new Vector3(0, 0, 0);
        signoY = Random.Range(0, 1) > 0.5f ? 1 : -1;

        pelota.GetComponent<Rigidbody2D>().velocity = new Vector2(signoX * velocidad, signoY * velocidad);
    }



}
