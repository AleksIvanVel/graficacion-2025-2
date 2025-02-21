using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class inicio : MonoBehaviour
{

    public void IniciaJuego(){

        SceneManager.LoadScene("Main");
    }
    public void Creditos(){

        SceneManager.LoadScene("Creditos");
    }
    public void VolverInicio(){
 
        SceneManager.LoadScene("Inicio");
    }
}
