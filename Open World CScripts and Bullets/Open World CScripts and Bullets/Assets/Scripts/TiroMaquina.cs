using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroMaquina : MonoBehaviour
{
    public GameObject machine;
    public Transform LugardaBala;
    public float forca = 500;

    public List<GameObject> Alvos = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Adicionaralvo(other.gameObject);
            if(Alvos.Count == 1){
                InvokeRepeating("AtacandoAlvos", 0, 3);
            }
        }
    }
    void AtacandoAlvos()
    {
        if (Alvos.Count == 0)
        {
            CancelInvoke("AtacandoAlvos");
            return;
        }
        for (int i = 0; i < Alvos.Count; i++)
        {
            GameObject Maquinario = Instantiate(machine, LugardaBala.position, Quaternion.identity);
            Maquinario.GetComponent<Segue>().Alvo = Alvos[i];
        } 
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Alvos.Remove(other.gameObject);
        }
    }
    void Adicionaralvo(GameObject Alvo)
    {
        bool check = false;
        for (int i = 0; i < Alvos.Count; i++)
        {
            if(Alvos[i] == Alvo)
            {
                check = true;
            }
        }
        if (!check) {
            Alvos.Add(Alvo);
        }
    }
}
