using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

	[Header("Setup Fields")]
	public Transform target;
	public string enemyTag = "Enemy";
	public Transform part_to_rotate;

	[Header("Attributes")]
	public float fire_rate;
	public float range;
	public float rotate_speed;
    public GameObject bulletPrefab;
    public Transform fire_point;

	private float shooting_countdown = 0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget() {
		
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) {
			float enemy_distance = Vector3.Distance (transform.position, enemy.transform.position);
			if (enemy_distance < shortestDistance) {
				shortestDistance = enemy_distance;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
			return;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(part_to_rotate.rotation, lookRotation, Time.deltaTime * rotate_speed).eulerAngles;
		part_to_rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (shooting_countdown <= 0f) {
			Shoot ();
			shooting_countdown = fire_rate;
		}

		shooting_countdown -= Time.deltaTime;
	}

	void Shoot() {
        GameObject bullet_obj = (GameObject)Instantiate(bulletPrefab, fire_point.position, fire_point.rotation);
        bullet bullet_script = bullet_obj.GetComponent< bullet > ();

        if (bullet_script != null)
            bullet_script.Seek(target);
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
