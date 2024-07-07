using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdinaryWater : MonoBehaviour
{
    public BoxCollider2D waterCollider;
    public BoxCollider2D waterTrigger;
    private Animator animator;
    public float offset;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        waterCollider = this.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        y = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.GetisDisable())
        {
            waterCollider.enabled = true;
            animator.speed = 0; // �ָ�����
        }
        else
        {
            waterCollider.enabled = false;
            animator.speed = 1; // ��ͣ����
        }
    }
    //��ʱ��ֹͣʱ������ײ���������޷���������ʱ������ʱ��û����ײ�������ҿ��Դ�����
    //��������ˮ��ֹͣʱ�䣬��ֱ��������

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!PlayerController.GetisDisable())
        {
            if (collision.gameObject.tag == "Player" ||( collision.gameObject.tag == "InteractObject" && collision.gameObject.name != "Key"))
            {
                transform.position = new Vector3(transform.position.x, y - offset, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!PlayerController.GetisDisable())
        {
            if (collision.gameObject.tag == "Player" || (collision.gameObject.tag == "InteractObject" && collision.gameObject.name != "Key"))
            {
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
            }
        }
    }
}
