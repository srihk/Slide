using UnityEngine;
using System.Collections;

public class DestructByLimit : MonoBehaviour
{
    public float limit = -1f;
    public bool isPillar = false;
    void FixedUpdate()
    {
        if (isPillar)
            transform.position += new Vector3(0f, -2.5f * Time.fixedDeltaTime, 0f);
        if (GetComponent<Rigidbody>().position.y < limit)
            Destroy(gameObject);
    }
}
