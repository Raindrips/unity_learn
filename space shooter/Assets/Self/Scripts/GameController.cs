using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues=new Vector3(6,0,16);
	public int hazardCount= 10;			//�Ѷ�ϵ��
	public float spawnWait= 0.75f;		//���ɼ��
	public float startWait= 1f;			//��ʼʱ��
	public float waveWait= 4f;			//ÿ�����

	private bool gameOver = false;
	private bool restart = false;
	private int score = 0;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	

	void Start() {

		restartText.text = "";
		gameOverText.text = "";
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	void Update() {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				SceneManager.LoadScene(0);
			}
		}
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				
				Instantiate(hazard, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			//��Ϸ����
			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
