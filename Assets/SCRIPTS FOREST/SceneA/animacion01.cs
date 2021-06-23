using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion01 : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public float fuerzaSalto;
    bool enPiso;
    public Transform refePie;
    public Transform refePie2;
    public float velX;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movX;
        float movY;
        //enPiso = Physics.OverlapSphere (refePie.position, refePie2.position , 1 , 1<<8);
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        rb.velocity = new Vector3 (velX * movX, rb.velocity.y, 0f);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            //anim.SetTrigger ("Walk");

            rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
        }
    }
}
