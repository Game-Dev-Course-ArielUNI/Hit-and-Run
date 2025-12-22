using UnityEngine;
using System.Collections;
public class playercontroller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardspeed;

    private int desiredLane = 1; //0:left 1=middle 2:rigth
    public float laneDistance = 4; //the distance between two lanes

    public float jumpforce;
    public float gravity = -20;
    public Animator animator;

    public bool isGrounded;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator.SetBool("isgrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerManeger.isGamestarted)
        //    return;
        direction.z = forwardspeed;

        //isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        //animator.SetBool("isGrounded", isGrounded);

        animator.SetBool("isgrounded", true);

        if ((controller.isGrounded))
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            } 
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Slide());
        }
            //gather the inputs on whuch lane we should be
            if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //calculate where we should be in the future
        Vector3 targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetposition += Vector3.left * laneDistance;

        }else if (desiredLane == 2)
        {
            targetposition += Vector3.right * laneDistance;
        }
        if (transform.position == targetposition)
            return;
        Vector3 diff = targetposition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate()
    {
        //if (playerManeger.isGamestarted)
        //    return;
        controller.Move(direction*Time.fixedDeltaTime);
    }

    private void jump()
    {
        direction.y = jumpforce;
        animator.SetBool("isgrounded", false);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "obstacle")
            playerManeger.gameover = true;
        //FindObjectOfType<AudioManeger>().playsound("gameover");

        if (hit.transform.tag == "finishLine")
            playerManeger.gameWin = true;
    }
    private IEnumerator Slide()
    {
        animator.SetBool("isSliding", true);
        yield return new WaitForSeconds(1.3f);
        animator.SetBool("isSliding", false);
             
    }
}
