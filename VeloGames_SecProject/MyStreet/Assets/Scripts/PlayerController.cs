using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public float laneDistance = 5.5f;
    private bool isGrounded = true;
    private int lane = 1;

    private Rigidbody rb;
    private Animator anim;
    private CapsuleCollider col;

    public Material Player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        PlayerImpulse();

        if (Input.GetKeyDown(KeyCode.A))
        {
            lane--;
            if (lane < 0)
            {
                lane = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            lane++;
            if (lane > 2)
            {
                lane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && isGrounded)
        {
            StartCoroutine(SlideDelay());
            anim.SetTrigger("Slide");
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetTrigger("Jump");
        }
        Vector3 targetPosition = transform.position.z * Vector3.forward + Vector3.up * transform.position.y;

        if (lane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (lane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }
    IEnumerator SlideDelay()
    {
        col.height = 0;
        yield return new WaitForSeconds(1f);
        col.height = 3.5f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.unDeath)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                GameManager.Instance.life--;
                StartCoroutine(UnDead());
            }
        }
    }
    public void PlayerImpulse()
    {
        if (GameManager.Instance.unDeath)
        {
            Player.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 0.5f));
        }
        else
        {
            Player.color = Color.white;
        }
    }
    IEnumerator UnDead()
    {
        GameManager.Instance.unDeath = true;
        yield return new WaitForSeconds(3f);
        GameManager.Instance.unDeath = false;
    }
}

