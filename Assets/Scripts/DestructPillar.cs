using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructPillar : MonoBehaviour
{
    public Rigidbody pillar;
    public float offset = 1f;
    public Vector3 offsetVector;
    void Update()
    {
        offsetVector.y = offset;
        transform.position -= offsetVector;
        if (pillar.position.y < -8f)
            Destroy(pillar.gameObject);
    }
}
