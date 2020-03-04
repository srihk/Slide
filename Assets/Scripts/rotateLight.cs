using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLight : MonoBehaviour
{
    public float rotate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rotate = Random.Range(-0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate, rotate, rotate);
    }
}
