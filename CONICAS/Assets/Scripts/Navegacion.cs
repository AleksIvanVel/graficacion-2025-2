using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegacion : MonoBehaviour
{
    public void gotoConicas() {

        SceneManager.LoadScene("Conicas");
    } 

    public void gotoPortada() {
        SceneManager.LoadScene("Portada");
    }

    public void gotoInformacion() {
        SceneManager.LoadScene("Informacion");
    }
}
