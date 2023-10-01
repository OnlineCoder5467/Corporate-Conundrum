using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    private Animator anim;
    private bool isShooting;



    public CharacterController controller;
    public float playerSpeed;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

        // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }
    
    

    

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
 
        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction * playerSpeed * Time.deltaTime);
        }


        screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            LookAt(point);
        }

        anim.SetFloat("Speed", direction.magnitude);
        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.z);


        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("Roll");
            anim.SetTrigger("Idle");
        }


        /*
        if(direction != Vector3.zero)
        {
            if (direction.x < -0.01)
            {
                anim.SetTrigger("Walk Left");
            }
            if (direction.x > 0.01)
            {
                anim.SetTrigger("Walk Right");
            }

            if (direction.z > 0.01)
            {
                anim.SetTrigger("Walk Forward");
            }
            
            if (direction.z < -0.01)
            {
                anim.SetTrigger("Walk Backward");
            }
        }
        else
        {
            anim.SetTrigger("OnGround");
        }
        */
        /*
        if (direction == Vector3.zero)
        {
            anim.SetTrigger("OnGround");
        }
        */
        

    }



    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
}
