using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarMaquina : MonoBehaviour
{
    public GameObject maquina;

    public Transform LugarDaBala;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Vector3 Local = new Vector3(LugarDaBala.position.x, LugarDaBala.position.y + 1, LugarDaBala.position.z);
        GameObject Maquinario = Instantiate(maquina, Local, LugarDaBala.localRotation);
        //Maquinario.transform.localRotation = new Quaternion(0, 0, 90, Quaternion.identity.w);

    }
}
