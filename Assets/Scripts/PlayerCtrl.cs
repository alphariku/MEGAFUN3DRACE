using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 MoveVector = Vector3.zero;
    private float FallSpeed = 0.0f;
    private float gravity = 0.05f;
    private bool Dead = false;
    private bool end = false;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject UI;
    [SerializeField] GameObject EndCard;
    [SerializeField] Slider progressBar;
    [SerializeField] Transform start;
    [SerializeField] Transform endcoord;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Dead || end){return;}
        progressBar.value = (transform.position.x - start.position.x) / (endcoord.position.x - start.position.x);
        if (transform.position.y < -0.5f)
        {
            Death();
            return;
        }
        if (Input.GetMouseButton(0))
        {
            UI.SetActive(false);
            rigidbody.velocity = new Vector3(5f, rigidbody.velocity.y, rigidbody.velocity.z);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, rigidbody.velocity.z);
            animator.SetBool("IsMoving", false);
        }

    }
    void OnCollisionEnter(Collision hit){
        if (hit.gameObject.tag == "Killer"){
            Death();
        }
    }
    
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "End"){
            end = true;
            transform.Rotate(0,180,0);
            animator.SetTrigger("WinTrigger");
            StartCoroutine(Win());
        }
    }

    private void Death(){
        Dead = true;
        animator.SetTrigger("DeathTrigger");
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn(){
        yield return new WaitForSeconds(2f);
        transform.position = start.position;
        animator.SetTrigger("Respawn");
        Dead = false;
    }
     private IEnumerator Win(){
        yield return new WaitForSeconds(2f);
        EndCard.SetActive(true);
        
    }
    
}

