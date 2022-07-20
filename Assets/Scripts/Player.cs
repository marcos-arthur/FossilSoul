using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public int groundLayer;

    public bool isJumping;

    public bool isLookingLeft;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("run", true);
            
            if(isLookingLeft){ 
                transform.Rotate(0f, 180f, 0f);
                isLookingLeft = false;
            }
        }

        if (Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("run", true);

            if(!isLookingLeft){
                transform.Rotate(0f, 180f, 0f);
                isLookingLeft = true;
            }
        }

        if (Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("run", false);
        }
    }

    private void Jump(){
        if (Input.GetButtonDown("Jump") && !isJumping){
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == groundLayer){
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.layer == groundLayer){
            isJumping = true;
        }
    }

    void TakeDamage(int damage){
        Health health = gameObject.GetComponent<Health>();
        // Debug.Log(healthC.health);
        health.health -= damage;

		if (health.health <= 0)
		{
			// Die();
            Debug.Log("morri");
		}
	}
    
    IEnumerator GetInvunerable(){
        Physics2D.IgnoreLayerCollision(9, 10, true);
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }

    void OnTriggerEnter2D (Collider2D collInfo){
        if(collInfo.GetComponent<Enemy>() != null){
            Enemy enemy = collInfo.GetComponent<Enemy>();

            TakeDamage(enemy.GetTouchDamage());
            StartCoroutine("GetInvunerable");
        }
    }

}
