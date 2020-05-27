using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtackIa : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public int vida = 100;
    public NavMeshAgent agent;
    void Update()
    {
        IniciandoEstados();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            Invoke("Ataque", 0.5f);
        if (other.gameObject.tag == "Tiro")
        {
            estado = Estados.Dano;
            vida -= 10;
            if (vida == 0)
            {
                estado = Estados.Morte;
            }
            Invoke("Ataque", 0.5f);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Invoke("Ataque", 0.5f);

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            estado = Estados.Parado;
    }
    public enum Estados
    {
        Perseguir,
        Ataque,
        Parado,
        Morte,
        Dano,
    }
    public Estados estado;
    void IniciandoEstados()
    {
        switch (estado)
        {
            case Estados.Parado:
                Parado();
                break;
            case Estados.Perseguir:
                Perseguir();
                break;
            case Estados.Morte:
                Morto();
                break;
            case Estados.Dano:
                Dano();
                break;
            case Estados.Ataque:
                Ataque();
                break;
        }
    }
    void Perseguir()
    {
        agent.isStopped = false;
        anim.SetBool("Idle", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Walk", true);
        anim.SetBool("Die", false);
        if (Vector3.Distance(transform.position, player.transform.position) < 4)
        {
            estado = Estados.Ataque;
        }
    }
    void Ataque()
    {
        agent.isStopped = true;
        anim.SetBool("Idle", false);
        anim.SetBool("Attack", true);
        anim.SetBool("Hit", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Die", false);
        if (Vector3.Distance(transform.position, player.transform.position) > 5)
        {
            estado = Estados.Perseguir;
        }
    }
    void Parado()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("Attack", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Die", false);
    }
    void Morto()
    {
        agent.isStopped = false;
        anim.SetBool("Idle", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Hit", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Die", true);
        Destroy(gameObject, 2.5f);
    }
    void Dano()
    {
        agent.isStopped = false;
        anim.SetBool("Idle", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Hit", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Die", false);
        Invoke("Ataque", 0.3f);
    }
}
