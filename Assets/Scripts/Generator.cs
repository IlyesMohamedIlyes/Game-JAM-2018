using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject _toGenerate;
    public GameObject _world;
    public float position = 3440;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Objetcs")
        {
            int v = transform.childCount;
            var g = _world.transform.GetChild(v).transform;

            Debug.Log("GENERATE");

            Destroy(other.gameObject);

            Instantiate(_toGenerate, g.position + Vector3.forward * position, g.rotation, _world.transform);
        }
    }
    
}
