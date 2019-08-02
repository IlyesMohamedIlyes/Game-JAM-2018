using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public Transform[] _targets;
    public int _index;

    private int _previousIndex;

    private void Start()
    {
        _previousIndex = _index;
    }
    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(_targets[_index].position, Vector3.up, 20 * Time.deltaTime);
    }
}
