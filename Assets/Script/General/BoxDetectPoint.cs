using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetectPoint : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Box"))
        {
            Destroy(collision.gameObject);
        }

    }
}
