using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wave_spawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public Transform spawnPoint;

	public float time_between_waves;
	private float countdown = 2f;

	public Text wave_countdown_text;

	private int wave_number = 0;

	void Update () {
		
		if (countdown <= 0.55f) {
			StartCoroutine (SpawnWave ());
			countdown = time_between_waves + 0.5f;
		}

		countdown -= Time.deltaTime;

		wave_countdown_text.text = Mathf.Round(countdown).ToString();
	}

	IEnumerator SpawnWave() {

		wave_number++;

		for (int i = 0; i < wave_number; i ++) {
			SpawnEnemy();
			yield return new WaitForSeconds (0.5f);
		}


	}

	void SpawnEnemy() {
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
