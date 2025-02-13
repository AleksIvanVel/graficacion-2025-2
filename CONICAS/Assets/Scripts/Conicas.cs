using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conicas : MonoBehaviour
{

    public Text txtConicas;
    private int conicaSeleccioanda = 0; //0 

    public Slider sl_a;
    private float a = 5;

    public Slider sl_b;
    private float b = 3;

    public Slider sl_h;
    private float h = 1;

    public Slider sl_k;
    private float k = 1;

    public Slider sl_t;
    private float t = 45;

    private int resolucion = 1000;

    public Text lbl_a, lbl_b, lbl_h, lbl_k, lbl_t;
    public Material matRecta, matCircunferencia, matElipse, matParabola, matHiperbola;

    private Vector3[] posPuntos;
    

    public void DibujaConicas()
    {
        if(conicaSeleccioanda != 0)
        {
            LineRenderer lr = GetComponent<LineRenderer>();
            lr.SetVertexCount(resolucion + 1);

            a = sl_a.value;
            b = sl_b.value;
            h = sl_h.value;
            k = sl_k.value;
            t = sl_t.value;

            switch (conicaSeleccioanda)
            {
                case 1: //Recta
                    txtConicas.text = "Recta";
                    lr.material = matRecta;
                    ResetControles();

                    //cambia texto en las etiquetas
                    lbl_a.text = "ax";
                    lbl_b.text = "ay";
                    lbl_h.text = "bx";
                    lbl_k.text = "by";

                    //oculta slider y etiqueta
                    lbl_t.gameObject.SetActive(false);
                    sl_t.gameObject.SetActive(false);

                    posPuntos = CreaRecta(a, b, h * -1, k, resolucion);
                    break;
                case 2: //Circunferencia
                    txtConicas.text = "Circunferencia";
                    lr.material = matCircunferencia;
                    ResetControles();

                    //cambia texto en las etiquetas
                    lbl_a.text = "ax";
                    lbl_b.text = "ay";
                    lbl_h.text = "bx";
                    lbl_k.text = "by";

                    //oculta slider y etiqueta
                    lbl_t.gameObject.SetActive(false);
                    sl_t.gameObject.SetActive(false);

                    posPuntos = CreaCircunferencia();


                    break;
                case 3: //Elipse
                    txtConicas.text = "Elipse";
                    lr.material = matElipse;
                    ResetControles();
                    break;
                case 4: //Parabola
                    txtConicas.text = "Parabola";
                    lr.material = matParabola;
                    ResetControles();
                    break;
                case 5: //Hiperbola
                    txtConicas.text = "Hiperbola";
                    lr.material = matHiperbola;
                    ResetControles();
                    break;
            }

            for(int i = 0; i <= resolucion; i++)
            {
                lr.SetPosition(i, posPuntos[i]);
            }
        }


    }

    public void ResetControles()
    {
        sl_a.gameObject.SetActive(true);
        sl_b.gameObject.SetActive(true);
        sl_h.gameObject.SetActive(true);
        sl_k.gameObject.SetActive(true);
        sl_t.gameObject.SetActive(true);

        lbl_a.gameObject.SetActive(true);
        lbl_b.gameObject.SetActive(true);
        lbl_h.gameObject.SetActive(true);
        lbl_k.gameObject.SetActive(true);
        lbl_t.gameObject.SetActive(true);

        lbl_a.text = "a";
        lbl_b.text = "b";
        lbl_h.text = "h";
        lbl_k.text = "k";
        lbl_t.text = "t";
    }

    public void BtnRecta()
    {
        conicaSeleccioanda = 1;
        DibujaConicas();
    }

    private Vector3[] CreaRecta(float ax, float ay, float bx, float by, int resolucion)
    {
        posPuntos = new Vector3[resolucion + 1];
        float dx = bx - ax;
        float dy = by - ay;
        for (int i = 0; i<= resolucion; i++)
        {
            posPuntos[i] = new Vector3(ax + dx * i / resolucion, ay + dy * i / resolucion);

        }
        return posPuntos;

    }

    public void BtnCircunferencia()
    {
        conicaSeleccioanda = 2;
        DibujaConicas();
    }
    public void BtnElipse()
    {
        conicaSeleccioanda = 3;
        DibujaConicas();
    }
    public void BtnParabola()
    {
        conicaSeleccioanda = 4;
        DibujaConicas();
    }
    public void BtnHiperbola()
    {
        conicaSeleccioanda = 5;
        DibujaConicas();
    }
}
