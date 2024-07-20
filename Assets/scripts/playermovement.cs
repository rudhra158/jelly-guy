using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed;
    public float jumppower;
    public float scale =2f;

    public bool Isground = true;

    public Rigidbody rb;

    public float dashspeed;
    public float dashduration = 1f;
    public bool isdashing;

    Vector3 movedirection;


    // Update is called once per frame
    void Update()
    {
     float xmovement = Input.GetAxisRaw("Horizontal");
     float zmovement = Input.GetAxisRaw("Vertical");


        movedirection = new Vector3(xmovement, 0, zmovement).normalized;
        transform.Translate(movedirection*speed*Time.deltaTime);
        

        if (Input.GetButtonDown("Jump") && Isground)
        {
            rb.AddForce(new Vector3(0, jumppower, 0), ForceMode.Impulse);
            Isground = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            StartCoroutine(Dash());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.localScale = transform.localScale * scale;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.localScale= transform.localScale / scale;
        }

    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            Isground = true;
        }
    }
    private IEnumerator Dash()
    {
       
        rb.velocity = new Vector3(movedirection.x*dashspeed,0,movedirection.z*dashspeed);
        yield return new WaitForSeconds(dashduration);
       
    }

}
