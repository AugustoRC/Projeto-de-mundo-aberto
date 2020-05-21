using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChangeCollor : MonoBehaviour
{
    public Renderer visual;
    private void OnTriggerEnter(Collider other)
    {
        visual.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}
