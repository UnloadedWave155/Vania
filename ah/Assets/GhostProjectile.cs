using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GhostProjectile : MonoBehaviour
{
	private Transform target;
	public GameObject explosion;
	public float speed = 3.0f;
	public float rotateSpeed = 200.0f;
	private Rigidbody2D rb;
	private float destroyTime = 4.5f;
	private float startTime;
	public bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag("player").transform;
		startTime = Time.time;
		destroyTime = startTime + destroyTime;
		canSpawn=false;
    }

	void Update()
	{
		if(Time.time > destroyTime)
		{
			Instantiate(explosion, transform.position, Quaternion.identity);
			transform.gameObject.SetActive(false);
			canSpawn=true;
			
			
			//Destroy(gameObject);
		}
		if(canSpawn==true){
			gameObject.transform.position = transform.position;
			transform.gameObject.SetActive(true);
		}
	}

    void FixedUpdate()
    {
		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
    }

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.layer == 15 || col.gameObject.layer == 8 || col.gameObject.layer == 11)
		{
			Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
		}

		if(col.gameObject.tag == "player")
		{
			Instantiate(explosion, transform.position, Quaternion.identity);
			transform.gameObject.SetActive(false);
			canSpawn=true;
			//Destroy(gameObject);
		}
	}
}
