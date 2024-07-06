using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public int Energy; 
    void Start()
    {
        
    }

    private void OnEnable()
    {
        PlayerController.Instance.OnUpdateScene += OnUpdateScene;
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnUpdateScene -= OnUpdateScene;
    }

    private void OnUpdateScene()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EnergyBar.Instance.AddEnergy(Energy);
            this.gameObject.SetActive(false);
        }
    }
}
