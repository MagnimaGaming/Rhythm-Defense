using UnityEngine;

public class PlayerMovNew : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public float moveSpeed=3f;
    public float rotationSpeed=300f;
    public AudioClip moveSound;

    private bool isRotating = false;
    private Quaternion targetRotation;

    void Start()
    {
        animator=GetComponent<Animator>();
        audioSource=GetComponent<AudioSource>();

        audioSource.clip=moveSound;
        audioSource.loop=true;
    }

    void Update()
    {
        bool isMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
            animator.SetBool("isWalking",true);
            isMoving = true;
        }
        else
        {
            animator.SetBool("isWalking",false);
        }


        if (Input.GetKeyDown(KeyCode.Q)&&!isRotating)
        {
            targetRotation = transform.rotation*Quaternion.Euler(0, -90f, 0);
            isRotating = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            targetRotation = transform.rotation*Quaternion.Euler(0, 90f, 0);
            isRotating = true;
        }

        if (isRotating)
        {
            transform.rotation=Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation,targetRotation) < 0.1f)
            {
                transform.rotation=targetRotation;
                isRotating = false;
            }

            isMoving = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("Jump");

        if (Input.GetKeyDown(KeyCode.S))
            animator.SetTrigger("Slide");

        if (isMoving)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }


        if (!isMoving)
            animator.SetTrigger("Idle");
    }
}