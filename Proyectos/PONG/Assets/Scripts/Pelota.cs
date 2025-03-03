using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{

    Juego miJuego;
    private AudioSource audio;
    public AudioClip snd1, snd2, sndGol, sndPared;

    public static int numToques = 0, golesJugIzq = 0, golesJugDer = 0;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        miJuego = GameObject.Find("Juego").gameObject.GetComponent<Juego>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float compX = 0, compY = 0;

        if (collision.CompareTag("gol"))
        {
            audio.clip = sndGol;
            audio.Play();
            numToques = 0;

            GameObject nombrePorteria = collision.gameObject;
            if (nombrePorteria.name == "porteriaIzq") 
            {
                golesJugDer++;

            } else if (nombrePorteria.name == "porteriaDer")
            {
                golesJugIzq++;
            }

            miJuego.EscribirMarcador();
        }

        if (collision.CompareTag("jugIzq"))
        {
            audio.clip = snd1;
            audio.Play();
            numToques++;

            float alturaColisionIzq = GameObject.Find("JugadorIzq").gameObject.transform.position.y - transform.position.y;
            compX = Mathf.Cos(alturaColisionIzq);
            compY = Mathf.Sin(alturaColisionIzq);

            if (alturaColisionIzq >=0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * Juego.velBola + numToques, compY * (Juego.velBola * -1) - (float)numToques/2);
            } else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * Juego.velBola + numToques, compY * (Juego.velBola * -1) + (float)numToques / 2);
            }
        }

        if (collision.CompareTag("jugDer"))
        {
            audio.clip = snd2;
            audio.Play();

            float alturaColisionDer = GameObject.Find("JugadorDer").gameObject.transform.position.y - transform.position.y;
            compX = Mathf.Cos(alturaColisionDer);
            compY = Mathf.Sin(alturaColisionDer);

            if (alturaColisionDer >= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * (Juego.velBola * -1) - numToques, compY * (Juego.velBola * -1) - (float)numToques / 2);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * (Juego.velBola * -1) - numToques, compY * (Juego.velBola * -1) + (float)numToques / 2);
            }
        }

        if (collision.CompareTag("pared"))
        {
            audio.clip = sndPared;
            audio.Play();
        }
    }


}
