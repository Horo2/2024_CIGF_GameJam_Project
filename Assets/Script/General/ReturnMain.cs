using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMain : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            SceneLoader.Instance.LoadScene("Menu");
        }

    }
}
