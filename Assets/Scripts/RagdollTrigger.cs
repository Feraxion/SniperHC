using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{

    public GameManager gameMng;
    //public Collider mainCollider;
    //public Collider[] allColliders;
    //private void Awake()
    //{
    //    mainCollider = GetComponent<Collider>();
    //    allColliders = GetComponentsInChildren<Collider>(true);
    //    DoRagdoll(false);
    //}


    //void DoRagdoll(bool isRagdoll)
    //{
    //    foreach (var col in allColliders)
    //    {
    //        col.enabled = isRagdoll;
    //        mainCollider.enabled = !isRagdoll;
    //        GetComponent<Rigidbody>().useGravity = !isRagdoll;
    //        GetComponent<Animator>().enabled = !isRagdoll;
    //    }
    //}

    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Bullet")
    //    {
    //        DoRagdoll(true);
    //        Destroy(gameObject);
    //    }
    //}

    public BoxCollider mainCollider;
    public GameObject thisGuyRig;
    public Animator thisGuyAnimator;
    public bool ragdollMode = false;

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidBodies;

    public GameObject endGameParticle;
    //public GameObject winCanvas;
    
    private void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }
    void GetRagdollBits()
    {
        ragDollColliders = thisGuyRig.GetComponentsInChildren<Collider>();
        limbsRigidBodies = thisGuyRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {
        thisGuyAnimator.enabled = false;
        GetComponent<Animator>().enabled = false;
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidBodies)
        {
            rigid.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void RagdollModeOff()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidBodies)
        {
            rigid.isKinematic = true;
        }
        thisGuyAnimator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            RagdollModeOn();
            foreach (Transform child in endGameParticle.transform)
            {
                child.GetComponent<ParticleSystem>().Play();
            }
            //winCanvas.SetActive(true);
            gameMng.playerState = GameManager.PlayerState.Finish;
            // DoRagdoll(true);
        }
    }

}
