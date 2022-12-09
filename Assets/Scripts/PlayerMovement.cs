using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject spotLight;
    public float speed = 12f;
    private float originalSpeed;
    private float originalLighting = 0.5f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public GameManager gameManager;

    private void Start()
    {
        originalSpeed = speed;
    }
    void Update()
    {
        //Check Ground and Reset Velocity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Jump
        if(isGrounded && Input.GetButtonDown("Jump")){
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //Apply Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }

    public void PowerUpSpeed(){
        speed += 3;
        StartCoroutine(ResetSpeed());
    }

    public void PowerUpLighting(){
        originalLighting = RenderSettings.ambientIntensity;
        RenderSettings.ambientIntensity = 2;
        spotLight.SetActive(false);
        StartCoroutine(ResetLighting());
    }

    public void PowerUpPath() {
        gameManager.runAStar();
        StartCoroutine(ResetPath());
    }

    private IEnumerator ResetSpeed() {
    while(true) {
            yield return new WaitForSeconds(10);
            speed = originalSpeed;
        }
    }

    private IEnumerator ResetLighting() {
    while(true) {
            yield return new WaitForSeconds(10);
            RenderSettings.ambientIntensity = originalLighting;
            spotLight.SetActive(true);
        }
    }

    private IEnumerator ResetPath() {
    while(true) {
            yield return new WaitForSeconds(10);
            gameManager.resetPath();
        }
    }
}