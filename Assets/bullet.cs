using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek(Transform _target) {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float move_distance = speed * Time.deltaTime;
        if (dir.magnitude <= move_distance)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * move_distance, Space.World);
	}

    void HitTarget() {
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
