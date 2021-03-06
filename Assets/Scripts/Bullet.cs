using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject bullet;
    GunManager gunManager;
    public AudioSource audiosource;
    public AudioClip Clip;
    Rigidbody getRigidBody;

    private void OnEnable()
    {
        if (gameObject.tag == "Red")
        {
            StartCoroutine(DestoryTime(4));
        }

        if (gameObject.tag == "Green")
        {
            StartCoroutine(CheckBullet());
        }
        if (gameObject.tag == "Blue")
        {
            StartCoroutine(DestoryTime(1));
        }
    }

    private void Start()
    {
        gunManager = FindObjectOfType<GunManager>();
        getRigidBody = gameObject.GetComponent<Rigidbody>();
        
    }

        
    IEnumerator DestoryRig()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject.GetComponent<Rigidbody>());
    }

    private void OnCollisionEnter(Collision collision)
    {

        //if (collision.gameObject.CompareTag("Red") && gameObject.CompareTag("Red"))
        //{
        //    Debug.Log("Red Trigger");

        //    Destroy(gameObject);
        //    //Destroy(collision.gameObject);
        //}

        //if (collision.gameObject.CompareTag("Green") && gameObject.CompareTag("Green"))
        //{
        //    Debug.Log("Green Trigger");
        //    Destroy(gameObject);
        //    //Destroy(collision.gameObject);
        //}

        //if (collision.gameObject.CompareTag("Blue") && gameObject.CompareTag("Blue"))
        //{
        //    Debug.Log("Black Trigger");
        //    Destroy(gameObject);
        //    //Destroy(collision.gameObject);
        //}

        //if (collision.gameObject.CompareTag("Glass"))
        //{
        //    Destroy(gameObject);
        //    Debug.Log("Glass Is Glass, And Glass Can Brake");
        //    //StartCoroutine(DestroyAfter(collision.gameObject));
        //}

        //if (collision.gameObject.CompareTag("metal"))
        //{
        //    PlayBullet(Clip);
        //}



        if (collision.gameObject.tag == "Wall")
        {
            if (gameObject.layer == 10)
            {
                getRigidBody.velocity = Vector3.zero;
                getRigidBody.isKinematic = true;

                this.transform.parent = collision.transform;

                this.GetComponentInChildren<Transform>().localScale = new Vector3(10, 10, 10);
                gunManager.isStuck = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.layer == 3)
        {
            gunManager.isStuck = false;
            Destroy(gameObject);
        }

        if (gameObject.tag == "Blue")
        {
            Destroy(gameObject);
        }

    }
    public void PlayBullet(AudioClip clip)
    {
        audiosource.clip = clip;
        audiosource.Play();
    }
    private void OnTriggerEnter(Collider collision)
    {

    }

    IEnumerator DestoryTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    IEnumerator WaitQueue(float time)
    {
        yield return new WaitForSeconds(time);
       
    }
    
    IEnumerator CheckBullet()
    {
        yield return new WaitForSeconds(2);
        if (gunManager.isStuck == true)
        {
            yield break;
        }
        if (gunManager.isStuck == false)
        {
            StartCoroutine(DestoryTime(0.2f));
        }
    }
}
