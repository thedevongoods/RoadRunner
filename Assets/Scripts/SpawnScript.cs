using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject obstacle;
	public GameObject powerup;
	public GameObject boulder;
	
	float timeElapsed = 0;
	float spawnCycle = .8f;
	//bool spawnPowerup = true;
	int spawnKind;
	
	void Update () {
		timeElapsed += Time.deltaTime;
		spawnKind = Random.Range (0, 5);
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			if(spawnKind >= 2)
			{
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
			}
			else if(spawnKind <=1)
			{
				temp = (GameObject)Instantiate(obstacle);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
			}
			/*
			else 
			{
				temp = (GameObject)Instantiate(boulder);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(0, pos.y, pos.z);
			}*/
			
			timeElapsed -= spawnCycle;
			//spawnPowerup = !spawnPowerup;
		}
	}
}