using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{

    [SerializeField] private float speed = 6f;
    private Animator anim;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Walk Forward");
        }


         if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Walk Left");
        }

         if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("Walk Right");
        }


        var velocity = Vector3.
        if (Input.GetKeyUp(KeyCode.W | KeyCode.A | KeyCode.D))
        {
            anim.SetTrigger("OnGround");
        }
        */


        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        anim.SetFloat("Speed", velocity.z);
        
    }
}