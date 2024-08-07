using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�C���X�y�N�^�[��Ő��l��ݒ肳����
    public float speed;
    public GroundCheck ground;
    
    //�v���C�x�[�g�̕ϐ�
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�̃C���X�^���X���w��
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = ground.IsGround();

        //�L�[���͂��ꂽ��s��
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if(horizontalKey > 0)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            anim.SetBool("runR", true);
            xSpeed = speed;
        }
        else if(horizontalKey < 0)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            anim.SetBool("runR", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("runR", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }
}
