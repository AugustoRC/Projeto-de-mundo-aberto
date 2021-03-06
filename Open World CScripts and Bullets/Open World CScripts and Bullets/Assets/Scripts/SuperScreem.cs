﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperScreem : MonoBehaviour
{
    public GameObject Enemy;
    public float segundos;
    public bool respiracao;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal") && Input.GetButtonDown("Vertical"))
        {
            respiracao = false;
            Debug.Log("Ta dando certo, grita passarinho");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Invoke("SuperSonic", 1f);
        StartCoroutine("Destruicao");
    }
    void SuperSonic()
    {
        if (respiracao == false) {
            Vector3 posicao = new Vector3(Enemy.transform.position.x, 0, Enemy.transform.position.z - 10);
            Enemy.transform.position = posicao;
        }
    }
    IEnumerable Destruicao()
    {
        yield return new WaitForSeconds(segundos);
        Destroy(gameObject);
    }
}
