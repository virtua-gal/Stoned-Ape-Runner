using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanController : MonoBehaviour{
    Animator chanim;
    Rigidbody rb;
    float inputH;
    float inputV;
    bool run;
    // Start is called before the first frame update
    void Start(){
        chanim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        run = false;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            chanim.Play("WAIT01");
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            chanim.Play("WAIT02");
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            chanim.Play("WAIT03");
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)){
            chanim.Play("WAIT04");
        }

        if(Input.GetMouseButtonDown(0)){
            int n = Random.Range(0, 2);

            if(n == 0){
                chanim.Play("DAMAGED00");
            }
            
            if(n == 1){
                chanim.Play("DAMAGED01");
            }
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            run = true;
        }
        else{
            run = false;
        }

        if(Input.GetKey(KeyCode.Space)){
            chanim.SetBool("jump", true);
        }
        else
        {
            chanim.SetBool("jump", false);
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        chanim.SetFloat("inputH", inputH);
        chanim.SetFloat("inputV", inputV);
        chanim.SetBool("run", run);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if(moveZ <= 0){
            moveX = 0f;
        }
        else if(run == true){
            moveX *= 3f;
            moveZ *= 3f;
        }

        rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
