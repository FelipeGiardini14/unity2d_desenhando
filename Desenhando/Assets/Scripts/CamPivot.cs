using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPivot : MonoBehaviour
{
    public Transform bicicleta;

    private void FixedUpdate()
    {
        transform.position = new Vector3(bicicleta.position.x, 0, 0);
    }
}