using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Animator anim;
    private AnimatorStateInfo animLayer0;
    private AnimatorStateInfo animLayer1;

    private float fStartTime = 0.0f;

    public float fMoveSpeed = 10.0f;

    private bool bLeft = false;
    private bool bRight = false;

    public float fSlideTime = 0.0f;

    private Vector3 vecTurn;

    private BoxCollider col;
    private Vector3 vColSize;
    private Vector3 vColCenter;

    public GUIStyle gui;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
        col = this.GetComponent<BoxCollider>();
        vColSize = col.size;
        vColCenter = col.center;
    }

    void Update ()
    {
        animLayer0 = anim.GetCurrentAnimatorStateInfo(0);
        animLayer1 = anim.GetCurrentAnimatorStateInfo(1);   //상체 애니만 돌릴 Layer

        if (fStartTime > 3.0f)
        {
            fStartTime = 0.0f;
            anim.SetBool("Start", true);
        }

        if (anim.GetBool("Start") == false)
        {
            fStartTime += Time.deltaTime;
            return;
        }

        Move();
        Rotate();
        Attack();
        Jump();
        Slide();

        if (animLayer1.IsName("Damage") == true)
        {
            anim.SetBool("Damage", false);
        }

        if (animLayer0.IsName("Fail") == true)
        {
            anim.SetBool("Dead", false);
        }

        if (animLayer0.IsName("Clear") == true)
        {
            anim.SetBool("Clear", false);
        }
    }

    void Move()
    {
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-fMoveSpeed * Time.deltaTime, 0 , 0);
        }
        //Right
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(fMoveSpeed * Time.deltaTime, 0, 0);
        }

        if (animLayer0.IsName("Idle") == false && animLayer0.IsName("Clear") == false)
        {
            this.transform.Translate(0, 0, fMoveSpeed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        //Left
        if(Input.GetKeyDown(KeyCode.Q))
        {
            bLeft = true;
            vecTurn = -this.transform.right;
        }
        //Right
        else if(Input.GetKeyDown(KeyCode.E))
        {
            bRight = true;
            vecTurn = this.transform.right;
        }

        //회전 보간
        if (bLeft == true || bRight == true)
        {
            if(this.transform.forward == vecTurn)
            {
                bLeft = false;
                bRight = false;
                return;
            }

            Vector3 vec = Vector3.Slerp(this.transform.forward, vecTurn, 0.3f);
            this.transform.rotation = Quaternion.LookRotation(vec, Vector3.up);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("Jump", true);
        }

        if (animLayer0.IsName("Jump") == true)
        {
            anim.SetBool("Jump", false);
        }
    }

    void Slide()
    {
        if(animLayer0.IsName("Run") == true)
        {
            fSlideTime = 0.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            fSlideTime += Time.deltaTime;
            if(fSlideTime >= 2.0f)
            {
                anim.SetBool("Slide", false);
                col.size = vColSize;
                col.center = vColCenter;
                return;
            }
            anim.SetBool("Slide", true);
            col.size = new Vector3(0.5f, 1.0f, 0.5f);
            col.center = new Vector3(0, 0.5f, 0);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("Slide", false);
            col.size = vColSize;
            col.center = vColCenter;
        }
    }

    void Attack()
    {
        if(animLayer0.IsName("Jump") 
            || animLayer0.IsName("SlideStart") || animLayer0.IsName("SlideLoop"))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Attack", true);
        }

        if (animLayer1.IsName("Attack") == true)
        {
            anim.SetBool("Attack", false);
        }
    }

    public void Dead()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        anim.SetBool("Dead", true);

        anim.SetBool("Slide", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Damage", false);
    }

    public void Damaged()
    {
        anim.SetBool("Damage", true);
    }

    public void StartRun()
    {
        anim.SetBool("Start", true);
    }

    public void Clear()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        anim.SetBool("Clear", true);

        anim.SetBool("Slide", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Jump", false);
        anim.SetBool("Damage", false);
    }

    private void OnGUI()
    {
        gui.fontSize = 50;
        GUI.Label(new Rect(0, 0, 500, 300), "Time : " + fStartTime.ToString(), gui);
    }
}
