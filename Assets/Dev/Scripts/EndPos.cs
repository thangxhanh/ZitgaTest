using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPos : MonoBehaviour
{
    [SerializeField] private ObjectPool pools;

    private void OnTriggerEnter2D(Collider2D col)
    {
        pools.Disable(col.gameObject);
    }
}
