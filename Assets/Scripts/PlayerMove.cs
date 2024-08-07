using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //インスペクター上で数値を設定させる
    public float speed;
    public GroundCheck ground;
    
    //プライベートの変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントのインスタンスを指定
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = ground.IsGround();

        //キー入力されたら行動
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
