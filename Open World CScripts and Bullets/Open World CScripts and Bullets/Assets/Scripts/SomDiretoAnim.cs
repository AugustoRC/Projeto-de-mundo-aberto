using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomDiretoAnim : MonoBehaviour
{

    ControladorSom controleSom;

    private void Awake()
    {
        ControladorSom = GameObject.FindWithTag("MainCamera").GetComponent<ControladorSom>();
    }

    public void AnimEvent_Ouvir_Walk()
    {
        controleSom.Ouvir(ControladorSom.Ouvir.Andar);
    }
    public void AnimEvent_Ouvir_Hit()
    {
        controleSom.Ouvir(ControladorSom.Ouvir.Atack);
    }
}
