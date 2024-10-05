using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Player1 : MonoBehaviour, ISounds
{
    private bool isGrounded;
    private Ray ray;
    private float moveX;
    private float moveZ;
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float distanceRay = 1.48f;
    [SerializeField] private float rotateSpeed = 500f;
    [SerializeField] private float volume = 1f;
    private float p1 = 2f;
    private float p2 = 3f;
    [SerializeField] private LayerMask layerMask;
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private AudioClip[] soundsCollections;
    private AudioSource audioSrc;
 
    private void InitPlayer()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void AnimationsPlayer()
    {
        animator = GetComponent<Animator>();
    }
    private void Sounds()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void GroudCheckForPlayer()
    {
        ray = new Ray(transform.position, -transform.up);
        isGrounded = (Physics.Raycast(ray, distanceRay, layerMask));
    }
    private void MoveInput()
    {
        moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 1f;
        moveZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(moveX, 0, moveZ);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
    private void JumpPlayer()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * moveSpeed * 30);
        }
    }
    private void TeleportationOnFinish()
    {
        if(Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.H))
        {
            transform.position = new Vector3(12, 30, 491);
        }
    }
    private void AnimationsMove()
    {
        animator.SetBool("MoveZ", moveZ != 0);
        animator.SetBool("MoveX", moveX != 0);
        AnimatorJump();
    }
    private void AnimatorJump()
    {
        if (isGrounded)
        {
            animator.SetBool("air", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
                SoundsJumpPlayer();
            }
        }
        else
        {
            animator.SetBool("air", true);
        }
    }
    
    public void PlaySounds()
    {
        audioSrc.pitch = Random.Range(p1, p2);
        audioSrc.PlayOneShot(soundsCollections[0], volume);
    }
    private void SoundsStandPlayer()
    {
        audioSrc.pitch = Random.Range(p1, p2);
        audioSrc.PlayOneShot(soundsCollections[1], volume);
    }
    private void SoundsFallingPlayer()
    {
        audioSrc.pitch = Random.Range(p1, p2);
        audioSrc.PlayOneShot(soundsCollections[2], volume);
    }
    private void SoundsJumpPlayer()
    {
        audioSrc.pitch = Random.Range(p1, p2);
        audioSrc.PlayOneShot(soundsCollections[3], volume);
    }
    private void Start()
    {
        InitPlayer();
        AnimationsPlayer();
        Sounds();
    }
    private void Update()
    {
        MoveInput();
        AnimationsMove();
        TeleportationOnFinish();
    }
    private void FixedUpdate()
    {
        GroudCheckForPlayer();
        JumpPlayer();
    }

}


