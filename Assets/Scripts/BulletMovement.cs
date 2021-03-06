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

    //shattered target
    public GameObject shatteredObject;

    //ScoreUI
    public Text scoreText;
    public int score;
    public GameManager gameMng;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (gameMng.playerState == GameManager.PlayerState.Playing)
        {
            GetInput();
            transform.Translate(Vector3.forward  * movementSpeed , Space.World) ;
            //scoreText.text = score.ToString();
        }   
        
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
            gameMng.playerState = GameManager.PlayerState.Died;
        }
        if (collision.gameObject.tag == "TargetObject")
        {
            shatteredTarget();
            Destroy(collision.collider.gameObject);
            score++;
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

    void shatteredTarget()
    {
        Instantiate(shatteredObject, transform.position, transform.rotation);
    }
}
