using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilapidatedPlatform : MonoBehaviour
{
    public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc= this.GetComponent<BoxCollider2D>();
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

    //��ʱ��ֹͣʱ������ײ�������ҿ���վ�������档��ʱ������ʱ�����վ�������棬ƽ̨�ᱻ�ƻ���Ҳ���Ա��������崥����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!PlayerController.GetisDisable())
        {
            this.gameObject.SetActive(false);
        }
    }
}
