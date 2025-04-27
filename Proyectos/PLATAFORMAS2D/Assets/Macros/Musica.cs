using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Musica : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PantallaGameOver;
    public GameObject PantallaSigNivel;
    public GameObject MusicaSonando;
    void Start()
    {
        MusicaSonando.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(PantallaGameOver.activeInHierarchy || PantallaSigNivel.activeInHierarchy)
        {
            MusicaSonando.SetActive(false);
        }
        else
        {
            MusicaSonando.SetActive(true);
        }
    }
}
