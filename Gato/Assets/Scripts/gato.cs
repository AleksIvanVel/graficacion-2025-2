using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gato : MonoBehaviour
{
    public Button btn;
    public Text txtJuego;

    private int[,] matrizGato = new int[3,3];
    private int turno = 0; //En 0 nadie ha iniciado
    private int ganador = 0, movimientos = 0; //empate
    private int turnoviejo=0;

    // Start is called before the first frame update
    void Start(){
        IniciaGato();
        txtJuego.text = "juego nuevo, miau";
    }xdww
    public void AsignaTurno(Button btn){
        if (ObtenValoresMatrizGato(btn.name) == 0 && ganador == 0){
            turnoviejo=0;
            turnoviejo= turno;
            if (turno == 0){
                turno = 1;
            }else if( turno == 1){
                turno = 2;
            }else {
                turno = 1;
            }
            txtJuego.text = "juego en curso, miau";
            DibujaSimbolo(btn, turno);
            EscribeValorMatrizGato(btn.name, turno);
            if(turnoviejo != turno){
                movimientos++;
            }
            VerificaGanador();
        }
    }
    private void DibujaSimbolo(Button btn, int t){
        if (t==1){
            btn.GetComponentInChildren<Text>().text="X";
        }else{
            btn.GetComponentInChildren<Text>().text="O";
        }
    }

    private int ObtenValoresMatrizGato(string btn){
        int a= -1;
        switch (btn){
            case "G0":
                a= matrizGato[0,0];
                break;
            case "G1":
                a= matrizGato[0,1];
                break;
            case "G2":
                a= matrizGato[0,2];
                break;
            case "G3":
                a= matrizGato[1,0];
                break;
            case "G4":
                a= matrizGato[1,1];
                break;
            case "G5":
                a= matrizGato[1,2];
                break;
            case "G6":
                a= matrizGato[2,0];
                break;
            case "G7":
                a= matrizGato[2,1];
                break;
            case "G8":
                a= matrizGato[2,2];
                break;
        }
        return a;
    }
    private void EscribeValorMatrizGato(string btn, int t){
        switch (btn){
            case "G0":
                matrizGato[0,0] = t;
                break;
            case "G1":
                matrizGato[0,1]= t;
                break;
            case "G2":
                matrizGato[0,2]= t;
                break;
            case "G3":
                matrizGato[1,0]= t;
                break;
            case "G4":
                matrizGato[1,1]= t;
                break;
            case "G5":
                matrizGato[1,2]= t;
                break;
            case "G6":
                matrizGato[2,0]= t;
                break;
            case "G7":
                matrizGato[2,1]= t;
                break;
            case "G8":
                matrizGato[2,2]= t;
                break;
        }
    }

    private void VerificaGanador(){
        if(matrizGato[0,0] ==1 && matrizGato[0,1] ==1 && matrizGato[0,2] ==1){
            ganador = 1; //Gana X x renglon
        }
        if(matrizGato[1,0] ==1 && matrizGato[1,1] ==1 && matrizGato[1,2] ==1){
            ganador = 1;
        }
        if(matrizGato[2,0] ==1 && matrizGato[2,1] ==1 && matrizGato[2,2] ==1){
            ganador = 1;
        }

        if(matrizGato[0,0] ==2 && matrizGato[0,1] ==2 && matrizGato[0,2] ==2){
            ganador = 2; //Gana O x renglon
        }
        if(matrizGato[1,0] ==2 && matrizGato[1,1] ==2 && matrizGato[1,2] ==2){
            ganador = 2;
        }
        if(matrizGato[2,0] ==2 && matrizGato[2,1] ==2 && matrizGato[2,2] ==2){
            ganador = 2;
        }
        
        if (matrizGato[0,0]== 1 && matrizGato[1,0]==1 && matrizGato [2,0]== 1){
            ganador=1;// Gana X x columna
        }
        if (matrizGato[0,1]== 1 && matrizGato[1,1]==1 && matrizGato [2,1]== 1){
            ganador=1;// Gana X x columna
        }
        if (matrizGato[0,2]== 1 && matrizGato[1,2]==1 && matrizGato [2,2]== 1){
            ganador=1;// Gana X x columna
        }

        if (matrizGato[0,0]== 2 && matrizGato[1,0]==2 && matrizGato [2,0]== 2){
            ganador=2;// Gana O x columna
        }
        if (matrizGato[0,1]== 2 && matrizGato[1,1]==2 && matrizGato [2,1]== 2){
            ganador=2;// Gana O x columna
        }
        if (matrizGato[0,2]== 2 && matrizGato[1,2]==2 && matrizGato [2,2]== 2){
            ganador=2;// Gana O x columna
        }

        if(matrizGato[0,0]==1 && matrizGato[1,1]==1 && matrizGato[2,2]==1){
            ganador = 1; //Gana X por diagonal principal
        }
        if(matrizGato[0,0]==2 && matrizGato[1,1]==2 && matrizGato[2,2]==2){
            ganador = 2; //Gana O por diagonal
        }

        if(matrizGato[0,2]==1 && matrizGato[1,1]==1 && matrizGato[2,0]==1){
            ganador = 1; //Gana X por diagonal inversa
        }
        if(matrizGato[0,2]==2 && matrizGato[1,1]==2 && matrizGato[2,0]==2){
            ganador = 2; //Gana O por diagonal inversa
        }
        if(ganador== 0 && movimientos==9){
            txtJuego.text= "empate";
        }
        if (ganador == 1){
            txtJuego.text= "gana: X";
        }
        if (ganador == 2){
            txtJuego.text= "gana: O";
        }
    }
    
    

    private void IniciaGato(){
        //inicia la matriz en ceros
        for (int i  = 0; i<3; i++){
            for(int j= 0; j<3 ; j++){
                matrizGato[i,j] = 0;
            }
        }
        //borra los textos de los botones
        GameObject.Find("G0").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G1").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G2").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G3").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G4").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G5").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G6").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G7").GetComponentInChildren<Text>().text = "";
        GameObject.Find("G8").GetComponentInChildren<Text>().text = "";



    }
    public void ReiniciaJuego(){
        SceneManager.LoadScene("Main");
    }
    public void VolverInico(){
        SceneManager.LoadScene("Inicio");
    }
}
