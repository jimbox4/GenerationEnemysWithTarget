using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;

    private void Start()
    {
        Destroy(gameObject, _destroyDelay);
    }
}