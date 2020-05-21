using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segue : MonoBehaviour
{
    public GameObject Alvo;
    public float forca = 1000;
    public float TempoVida = 0;
    void Start()
    {
        transform.LookAt(Alvo.transform);
        GetComponent<Rigidbody>().AddForce(transform.forward * forca);
    }

    void Update()
    {
        transform.LookAt(Alvo.transform);
        TempoVida += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Alvo || TempoVida > 3) {
            Destroy(gameObject);
        }
    }
}
