using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Implosão : MonoBehaviour
{
    public GameObject particula;
    void Start()
    {
        Invoke("Particulas", 2.5f);
        Invoke("Implode", 3.5f);
    }

    void Implode() 
    {
        print("Boom!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                    hit.rigidbody.AddExplosionForce(-1000, transform.position, 10);
            }
        }
    }
    void Particulas()
    {
        Instantiate(particula, transform.position, Quaternion.identity);
        Destroy(particula);
    }
}

