using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour {

	public Transform barrelEnd;
	public Rigidbody2D bullet;
	public float fireSpeed = 500f;
    public GameObject flame;
    [SerializeField]
    private Animator cannonAnimation;
    AudioSource audioSource;

    void Update () {
		Fire ();
	}

	void Fire ()
	{
		if (Input.GetButtonDown ("Fire1")) {
            cannonAnimation.SetBool("playCannonAnimation", true);
            var firedBullet = Instantiate (bullet, barrelEnd.position, barrelEnd.rotation);
			firedBullet.AddForce (barrelEnd.up * fireSpeed);
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            flame.SetActive(true);
            StartCoroutine(Wait());
        }        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        flame.SetActive(false);
        cannonAnimation.SetBool("playCannonAnimation", false);
    }
}