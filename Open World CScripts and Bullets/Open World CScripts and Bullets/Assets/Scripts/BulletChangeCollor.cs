using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChangeCollor : MonoBehaviour
{
    public Color StartColor = Color.blue;
    public bool transparencia = false;
    public float Troca = 1;
    public float velocidadeDetroca = 10;

    Material material;
    Color Randomcor;
    float temporizador;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        material.color = StartColor;
        temporizador = 0;

        MudaAcor();
    }
    void Update()
    {
        material.color = Color.Lerp(material.color, Randomcor, Time.deltaTime * velocidadeDetroca);
        temporizador += Time.deltaTime;
        if (temporizador > Troca)
        {
            temporizador = 0;
            MudaAcor();
        }
    }
    void MudaAcor()
    {
        if (transparencia == true)
            Randomcor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        else
            Randomcor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1);
    }
}
