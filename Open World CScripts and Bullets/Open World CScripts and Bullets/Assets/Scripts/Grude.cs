using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grude : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Player"))
        {
            Destroy(GetComponent<Rigidbody>());
            transform.SetParent(col.transform);
            Destroy(GetComponent<Grude>());
            Destroy(gameObject, 3);
        }
    }
}
