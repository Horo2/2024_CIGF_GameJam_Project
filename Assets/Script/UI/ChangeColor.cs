using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColorRed()
    {
        if (transform.GetComponent<Image>().color.a == 1F)
        {
            transform.GetComponent<Image>().color = new Color(1, 1, 1, 0.4F);
        }
        transform.GetComponent<Image>().color = new Color(1, 1, 1, 1F);
    }
}

