using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public float spawnRate = 2;
	public static int size = 4;
	public Transform[] spawnPoints = new Transform[size];

	float randomX = 0;
	float randomY = 0;
	int startPointIndex = 0;
	float nextSpawn = 0;
	float randomSize = 1;
	Vector2 whereToSpawn;
	Vector3 defaultSize;

	void Start(){
		defaultSize = enemy.transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			SetNewEnemyInfo ();
			Instantiate (enemy, whereToSpawn, Quaternion.identity);
			randomX = 0;
			randomY = 0;
			enemy.transform.localScale = defaultSize;
		}
	}

	// Get new enemy size and spawn location
	void SetNewEnemyInfo()
	{
		startPointIndex = Random.Range (0, 4);
		switch (startPointIndex) {
		case 0: 
			randomX = Random.Range (-35.0f, 35.0f);
			break;
		case 1: 
			randomY = Random.Range (-20.0f, 20.0f);
			break;
		case 2: 
			randomX = Random.Range (-35.0f, 35.0f);
			break;
		case 3: 
			randomY = Random.Range (-20.0f, 20.0f);
			break;
		}
		randomSize = Random.Range (.75f, 3.0f);
		whereToSpawn = new Vector2 (spawnPoints [startPointIndex].transform.position.x + randomX, spawnPoints [startPointIndex].transform.position.y + randomY);
		enemy.transform.localScale = enemy.transform.localScale * randomSize;
	}

}
