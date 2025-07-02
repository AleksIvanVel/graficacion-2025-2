using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planetas : MonoBehaviour
{
    public GameObject planeta;
    public Text txtPlaneta;
    public Material matMercurio, matVenus, matTierra, matMarte, matJupiter, matSaturno, matUrano, matNeptuno, matPluton;

    private int contador=0;
    public AudioSource reproductor;
    public AudioClip Mercurio, Venus, Tierra, Marte, Jupiter, Saturno, Urano, Neptuno, Pluton;
    // Start is called before the first frame update
    void Start()
    {
        contador=0;
        planeta.SetActive(false);
        txtPlaneta.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(contador >= 1){
            planeta.SetActive(true);

        }
    }
    public void BtnAnterior(){
        if (contador >1 & contador <=9){
            contador--;
            
        }else if(contador<=1 ){
            contador =9;
        }
        DibujarPlaneta();
    }
    public void BtnSiguiente(){
        if(contador < 9 ){
            contador++;
        }else{
            contador=1;
        }
        DibujarPlaneta();

    }
    private void DibujarPlaneta (){
        switch(contador){
            case 1:
                planeta.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                planeta.GetComponent<MeshRenderer>().material = matMercurio;
                txtPlaneta.text ="Mercurio";
                reproductor.clip = Mercurio;
                reproductor.Play();
                break;

            case 2:
                planeta.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                planeta.GetComponent<MeshRenderer>().material = matVenus;
                txtPlaneta.text ="Venus";
                reproductor.clip = Venus;
                reproductor.Play();
                break;
            case 3:
                planeta.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                planeta.GetComponent<MeshRenderer>().material = matTierra;
                txtPlaneta.text ="Tierra";
                reproductor.clip = Tierra;
                reproductor.Play();
                break;
            case 4:
                planeta.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                planeta.GetComponent<MeshRenderer>().material = matMarte;
                txtPlaneta.text ="Marte";
                reproductor.clip = Marte;
                reproductor.Play();
                break;
            case 5:
                planeta.transform.localScale = new Vector3(3, 3, 3);
                planeta.GetComponent<MeshRenderer>().material = matJupiter;
                txtPlaneta.text ="Júpiter";
                reproductor.clip = Jupiter;
                reproductor.Play();
                break;
            case 6:
                planeta.transform.localScale = new Vector3(2, 2, 2);
                planeta.GetComponent<MeshRenderer>().material = matSaturno;
                txtPlaneta.text ="Saturno";
                reproductor.clip = Saturno;
                reproductor.Play();
                break;
            case 7:
                planeta.transform.localScale = new Vector3(1, 1, 1);
                planeta.GetComponent<MeshRenderer>().material = matUrano;
                txtPlaneta.text ="Urano";
                reproductor.clip = Urano;
                reproductor.Play();
                break;
            case 8:
                planeta.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                planeta.GetComponent<MeshRenderer>().material = matNeptuno;
                txtPlaneta.text ="Neptuno";
                reproductor.clip = Neptuno;
                reproductor.Play();
                break;
            case 9:
                planeta.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                planeta.GetComponent<MeshRenderer>().material = matPluton;
                txtPlaneta.text ="Plutón";
                reproductor.clip = Pluton;
                reproductor.Play();
                break;    
        }
    }
}
