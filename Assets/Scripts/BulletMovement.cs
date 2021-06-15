using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    [Header("Speed Settings")]
    public float movementSpeed;
    public float controlSpeed;
    public bool slowMotion;

    //Touch settings
    [Header("Touch Settings")]
    [SerializeField] bool isTouching;
    //Testing Inputs

    public GameObject scopeCanvas;
    public GameObject failCanvas;
    public float timeScale;



    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        GetInput();
        transform.Translate(Vector3.forward  * movementSpeed , Space.World) ;

        

    }
    private void FixedUpdate()
    {
        if (isTouching)
        {
            DisableScope();
            //m_Rigidbody.velocity = (Vector3.forward * movementSpeed) * ( Time.timeScale / 1);
           // transform.Translate(Vector3.forward  * movementSpeed * (Time.timeScale /1) , Space.World) ;
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            failCanvas.SetActive(true);
        }
    }
    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
    //Mobile Inputs
    void GetInputMobile()
    {
        if (Input.touchCount > 0)
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

    void DisableScope()
    {
        scopeCanvas.SetActive(false);
    }
}
