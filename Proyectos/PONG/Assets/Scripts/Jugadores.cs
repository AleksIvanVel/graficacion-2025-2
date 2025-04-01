using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores : MonoBehaviour
{
    public KeyCode teclaArriba, teclaAbajo;
    private Rigidbody2D rb2d;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(teclaArriba) && Pelota.numToques <=20)
        {
            rb2d.MovePosition(rb2d.position + (Vector2.up * Time.deltaTime * Juego.velJugador) + new Vector2(0, (float)Pelota.numToques/100.0f));
        }

        if (Input.GetKey(teclaAbajo) && Pelota.numToques <= 20)
        {
            rb2d.MovePosition(rb2d.position + (Vector2.down * Time.deltaTime * Juego.velJugador) - new Vector2(0, (float)Pelota.numToques / 100.0f));
        }

    }
}
