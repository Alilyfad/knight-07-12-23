using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using TMPro;

public class playermovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    public TextMeshProUGUI healthCounter, coinsCounter, healthPowerUpsValue, speedPowerUpsValue;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow)) 
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("knightforward");
        //}

        //if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    anim.enabled = false;
        //}

        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("backwardanimation");
        //}

        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    anim.enabled = false;
        //}

        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("leftanimation");
        //}

        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    anim.enabled = false;
        //}

        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("rightanimation");
        //}

        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    anim.enabled = false;

    }

    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove (InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coinsCounter++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Health"))
        {
            healthCounter += healthPowerUpsValue;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Speed"))
        {
            moveSpeed += speedPowerUpsValue;
            Destroy(collision.gameObject);

            StartCoroutine(returnToBaseSpeed());

        }
    }

 
    
}