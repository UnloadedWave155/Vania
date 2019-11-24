using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShoot : MonoBehaviour
{
	private GameObject player;
	public GameObject projectile;
	public float fireRate = 4.5f;
	float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject == player && (Time.time > nextFire))
		{
			Instantiate(projectile, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}
	}
}
