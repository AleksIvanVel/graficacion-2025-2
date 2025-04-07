using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoQueParpadeaIndefinidamente : MonoBehaviour
{
    public GameObject objetoParpadea;
    public float tiempoRepetir = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeStateOfGameObject", 1f, tiempoRepetir);
    }

    void ChangeStateOfGameObject()
    {
        objetoParpadea.SetActive(!objetoParpadea.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {

    }
}