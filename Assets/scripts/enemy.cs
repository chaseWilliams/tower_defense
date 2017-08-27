using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float speed = 10f;

	private Transform target_waypoint;
	private int waypoint_index = 0;

	void Start() {
		target_waypoint = waypoints.points [0];
	}

	void Update() {
		Vector3 dir = target_waypoint.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance (transform.position, target_waypoint.position) <= 0.2f) {
			GetNextWaypoint ();
		}
	}

	void GetNextWaypoint() {

		if (waypoint_index >= waypoints.points.Length - 1) {
			Destroy (gameObject);
			return;
		}
		waypoint_index++;
		target_waypoint = waypoints.points [waypoint_index];
	}
}
