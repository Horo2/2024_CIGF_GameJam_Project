using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoSingleton<PlayerController>
{
    
    public PlayerInputController inputControl;
    public PhysicsCheck physicsCheck;
    [Header("组件")]
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D Rb;
    public Vector2 inputDirection;
    [Header("基本变量")]
    public float Speed;
    public float jumpForce;
    private int jumpCount = 2;

    private bool doubleJump;
    private bool isDisable;
    public UnityAction OnStateSwitching;
    public UnityAction OnUpdateScene;

    public Transform HoldPosition;
    private void Awake(){
        //将新输入系统实例化
        inputControl = new PlayerInputController();
        //获取PhysicsCheck中的组件,实例化
        physicsCheck = GetComponent<PhysicsCheck>();

    }

    private void Start()
    {
        isDisable = true;
        if (this.OnStateSwitching != null)
            this.OnStateSwitching();
    }

    //启动输入系统
    private void OnEnable()
    {
        this.OnStateSwitching += OnState;
        inputControl.Enable();
    }
    //关闭输入系统
    private void OnDisable(){
        this.OnStateSwitching -= OnState;
        inputControl.Disable();
    }

    private void OnState()
    {
        isDisable = !isDisable;
    }

    private void Update(){
        //读取输入系统传来的2维向量值
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
        //读取输入系统中是否按下空格进行跳跃
        inputControl.GamePlay.Jump.started+= Jump;
        //读取输入系统中是否按下Q进行状态切换
        inputControl.GamePlay.StateSwitching.started += StateSwitching;

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "PressureValves")
        {
            other.gameObject.GetComponent<PressureValves>().flag = !other.gameObject.GetComponent<PressureValves>().flag;
        }
    }

    void FixedUpdate()
    {
        //检测人物移动
        Move();
        IsPickUp();
    }

  
    //人物移动
    void Move(){
        //通过rigidbody组件，来改变人物的线性速度
        Rb.velocity = new Vector2(inputDirection.x*Speed,Rb.velocity.y);
        //定义一个变量来控制人物朝向
        int faceDir ;
        //如果输入为负数朝向左边，反之朝向右边
        if(inputDirection.x<0)
            faceDir=-1;
        else
            faceDir=1;
        //通过刚体组件来进行人物翻转
        // transform.localScale=new Vector3(faceDir,1,1);
        //通过精灵组件来进行翻转
        //if(faceDir==-1)
        //    spriteRenderer.flipX=true;
        //else
        //    spriteRenderer.flipX=false;
    }
    //人物跳跃
    private void Jump(InputAction.CallbackContext context)
    {
        // 如果在地面上
        if (physicsCheck.isGround)
        {
            // 重置二段跳状态
            doubleJump = true;
            // 给刚体施加一个向上瞬时的力
            Rb.velocity = Vector2.up * jumpForce;
            Debug.Log("跳跃");
        }
        // 如果不在地面上，但可以二段跳
        else if (doubleJump)
        {
            // 给刚体施加一个向上瞬时的力
            Rb.velocity = Vector2.up * jumpForce;
            // 禁用二段跳
            doubleJump = false;
            Debug.Log("二段跳跃");
        }
    }
    private void StateSwitching(InputAction.CallbackContext context)
    {
        if (this.OnStateSwitching != null)
            this.OnStateSwitching();
    }

    //更新玩家位置
    public void UpdatePlayerPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        // 删除 HoldPosition 下的所有子对象（Transform）
        foreach (Transform child in HoldPosition)
        {
            Destroy(child.gameObject);
        }
        if (this.OnUpdateScene != null)
            this.OnUpdateScene();
    }

    public void Restrat()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneLoader.Instance.LoadScene(currentScene.name);
    }

    private void IsPickUp()
    {
        if(isDisable)
            this.GetComponent<PlayerPickUp>().enabled = true;
        else
            this.GetComponent<PlayerPickUp>().enabled = false;
    }
}
