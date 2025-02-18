using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conicas : MonoBehaviour
{

    public Text txtConicas;
    private int conicaSeleccioanda = 0; //0 

    private float mlt = 7; 

    public Slider sl_a;
    private float a = 0;

    public Slider sl_b;
    private float b = 0;

    public Slider sl_h;
    private float h = 0;

    public Slider sl_k;
    private float k = 0;

    public Slider sl_t;
    private float t = 0;

    private int resolucion = 1000;

    public Text lbl_a, lbl_b, lbl_h, lbl_k, lbl_t;
    public Material matRecta, matCircunferencia, matElipse, matParabola, matHiperbola;

    private Vector3[] posPuntos;

    private void Start()
    {
        sl_a.enabled = false;
        sl_b.enabled = false;
        sl_h.enabled = false;
        sl_k.enabled = false;
        sl_t.enabled = false;
    }


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

                    //valores por defecto
                    

                    //cambia texto en las etiquetas
                    lbl_a.text = "ax";
                    lbl_b.text = "ay";
                    lbl_h.text = "bx";
                    lbl_k.text = "by";

                    //oculta slider y etiqueta
                    lbl_t.gameObject.SetActive(false);
                    sl_t.gameObject.SetActive(false);

                    posPuntos = CreaRecta(a*3, b, h*3, k, resolucion);
                    break;
                case 2: //Circunferencia
                    txtConicas.text = "Circunferencia";
                    lr.material = matCircunferencia;
                    ResetControles();

                    //cambia texto en las etiquetas
                    lbl_b.text = "r";

                    //oculta slider y etiqueta
                    lbl_a.gameObject.SetActive(false);
                    sl_a.gameObject.SetActive(false);

                    lbl_t.gameObject.SetActive(false);
                    sl_t.gameObject.SetActive(false);

                    posPuntos = CreaCircunferencia(b*mlt, h, k, resolucion);


                    break;
                case 3: //Elipse
                    txtConicas.text = "Elipse";
                    lr.material = matElipse;
                    ResetControles();

                    posPuntos = CreaElipse(a*mlt, b*mlt, h, k, t, resolucion);

                    break;
                case 4: //Parabola
                    txtConicas.text = "Parabola";
                    lr.material = matParabola;
                    ResetControles();

                    //cambia texto en las etiquetas
                    lbl_b.text = "p";

                    //oculta slider y etiqueta
                    lbl_a.gameObject.SetActive(false);
                    sl_a.gameObject.SetActive(false);

                    posPuntos = CreaParabola(b*mlt, h, k, t, resolucion);
                    break;
                case 5: //Hiperbola
                    txtConicas.text = "Hiperbola";
                    lr.material = matHiperbola;
                    ResetControles();

                    posPuntos = CreaHiperbola(a * mlt, b * mlt, h, k, t, resolucion);
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

        sl_a.enabled = true;
        sl_b.enabled = true;
        sl_h.enabled = true;
        sl_k.enabled = true;
        sl_t.enabled = true;
    }

    //**************    RECTA    *************************
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

    //**********************    CIRCUNFERENCIA    **********************
    public void BtnCircunferencia()
    {
        conicaSeleccioanda = 2;
        DibujaConicas();
    }

      private Vector3[] CreaCircunferencia(float r, float h, float k, int resolucion)
    {
        posPuntos = new Vector3[resolucion + 1];
        Vector3 centro = new Vector3(h,k,0); 
        
        for(int i = 0; i<= resolucion; i++){
            float angulo = (float)i / (float)resolucion * 2.0f * Mathf.PI;
            posPuntos[i] = new Vector3(r * Mathf.Cos(angulo), r * Mathf.Sin(angulo), 0);
            posPuntos[i] = posPuntos[i] + centro;
        }
        return posPuntos;

    }

    //**********************    ELIPSE    **********************
    public void BtnElipse()
    {
        conicaSeleccioanda = 3;
        DibujaConicas();
    }

    private Vector3[] CreaElipse(float a, float b, float h, float k, float theta, int resolucion)
    {
        posPuntos = new Vector3[resolucion + 1];
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);
        Vector3 centro = new Vector3(h, k, 0);

        for (int i = 0; i <= resolucion; i++)
        {
            float angulo = (float)i / (float)resolucion * 2.0f * Mathf.PI;
            posPuntos[i] = new Vector3(a * Mathf.Cos(angulo), b * Mathf.Sin(angulo), 0);
            posPuntos[i] = q * posPuntos[i] + centro;
        }
        return posPuntos;

    }

    //**********************    PARABOLA    **********************
    public void BtnParabola()
    {
        conicaSeleccioanda = 4;
        DibujaConicas();
    }

    private Vector3[] CreaParabola(float p, float h, float k, float theta, int resolucion)
    {
        posPuntos = new Vector3[resolucion + 1];
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);
        Vector3 centro = new Vector3(h, k, 0);

        for (int i = 0; i <= resolucion; i++)
        {
            float param = i - (resolucion / 2);
            float angulo = (float)i / (float)resolucion * 2.0f * Mathf.PI;
            posPuntos[i] = new Vector3(param, (1 / (4 * p)) * Mathf.Pow(param, 2), 0);
            posPuntos[i] = q * posPuntos[i] + centro;
        }
        return posPuntos;

    }

    //**********************    HIPERBOLA    **********************
    public void BtnHiperbola()
    {
        conicaSeleccioanda = 5;
        DibujaConicas();
    }
    private Vector3[] CreaHiperbola(float a, float b, float h, float k, float theta, int resolucion)
    {
        posPuntos = new Vector3[resolucion + 1];
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);
        Vector3 centro = new Vector3(h, k, 0);

        for (int i = 0; i <= resolucion; i++)
        {
            float angulo = (float)i / (float)resolucion * 2.0f * Mathf.PI;
            posPuntos[i] = new Vector3(a / Mathf.Cos(angulo), b * Mathf.Tan(angulo), 0);
            posPuntos[i] = q * posPuntos[i] + centro;
        }
        return posPuntos;

    }
}
