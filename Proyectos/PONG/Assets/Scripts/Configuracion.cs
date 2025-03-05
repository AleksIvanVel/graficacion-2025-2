using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Configuracion : MonoBehaviour
{
    public Text op1, op2;
    public static int tipoJuego = 1; // 1. compu, 2. persona

    // Start is called before the first frame update
    void Awake() {
        tipoJuego = 1;
        op1.gameObject.SetActive(true);
        op2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            BorraSubrayado();
            op1.gameObject.SetActive(true);
            tipoJuego = 1;
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            BorraSubrayado();
            op2.gameObject.SetActive(true);
            tipoJuego = 2;
        }
        if(Input.GetKey(KeyCode.Space)){

            if(tipoJuego == 1){
                SceneManager.LoadScene("IAconfig");
            }
            else{
                SceneManager.LoadScene("Main");
            }  
        }
        if(Input.GetKey(KeyCode.Escape)){
             SceneManager.LoadScene("Inicio");
        }

    }
    public void BorraSubrayado(){
        op1.gameObject.SetActive(false);
        op2.gameObject.SetActive(false);
    }
}
