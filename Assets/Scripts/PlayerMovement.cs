using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public Rigidbody2D rBody;
    public SpriteRenderer sprite;
    public GroundSensor sensor;
    public Animator anim;
    public float jumpForce = 10;
    public float movementSpeed = 5;
    private float inputHorizontal;
    
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    private bool canShoot=true;
    public float timer;
    public float rateOfFire = 1;

    public Transform hitBox;
    public float hitBoxRadius = 2;

    void Awake(){
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal=Input.GetAxis("Horizontal");
        if(inputHorizontal<0) {
            sprite.flipX = true;
            anim.SetBool("IsWalking",true);
        }
        else if(inputHorizontal>0) {
            sprite.flipX = false;   
            anim.SetBool("IsWalking",true);
        }else{
            anim.SetBool("IsWalking",false);
        }
        if(Input.GetButtonDown("Jump") && sensor.isGrounded) {
            rBody.AddForce(new Vector2(0,1) * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping",true);
       
        }
        Shoot();
    }

    void FixedUpdate(){
        rBody.velocity =  new Vector2(inputHorizontal*movementSpeed, rBody.velocity.y);
    }

    void Shoot(){
        if(!canShoot){
            timer+=Time.deltaTime;
            if(timer>=rateOfFire){
                canShoot=true;
                timer=0;
            }
        }
        if(Input.GetKeyDown(KeyCode.F) && canShoot){
            Instantiate(bulletPrefab, bulletSpawn.position,bulletSpawn.rotation);
            canShoot = false;
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(hitBox.position, hitBoxRadius);
    }
}

