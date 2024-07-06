using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilapidatedPlatform : MonoBehaviour
{
    public bool isOpen;
    public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
        bc= this.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        PlayerController.Instance.OnStateSwitching += OnStateSwitching;
        PlayerController.Instance.OnUpdateScene += OnUpdateScene;
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnStateSwitching -= OnStateSwitching;
        PlayerController.Instance.OnUpdateScene -= OnUpdateScene;
    }
    private void OnUpdateScene()
    {
        isOpen = false;
        this.gameObject.SetActive(true);
    }

    private void OnStateSwitching()
    {
        isOpen = !isOpen;
    }

    //��ʱ��ֹͣʱ������ײ�������ҿ���վ�������档��ʱ������ʱ�����վ�������棬ƽ̨�ᱻ�ƻ���Ҳ���Ա��������崥����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isOpen)
        {
            this.gameObject.SetActive(false);
        }
    }
}
