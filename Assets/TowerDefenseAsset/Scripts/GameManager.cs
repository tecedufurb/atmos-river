using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefenseAsset {
	public class GameManager : MonoBehaviour {

		[SerializeField] 
		private GameObject towerPrefab;
		[SerializeField] 
		private GameObject gameOverText;
		[SerializeField] 
		private PlayerController player;

		void Start() {
			gameOverText.SetActive(false);
		}

		void Update() {
			if(GameOver()) {
				gameOverText.SetActive(true);
			} else {
				if(Fire1Click())
					BuildTower();
			}
		}

		private bool Fire1Click() {
			return Input.GetMouseButtonDown(0);
		}

		private void BuildTower() {
			Vector3 clickPosition = Input.mousePosition;
			RaycastHit hit = GetPosition(clickPosition);

			if(hit.collider != null) {
				Vector3 newTowerPosition = hit.point;
				Instantiate (towerPrefab, newTowerPosition, Quaternion.identity);
			}
		}

		private RaycastHit GetPosition(Vector3 startPoint) {
			Ray ray = Camera.main.ScreenPointToRay(startPoint);
			RaycastHit hit;
			Physics.Raycast(ray, out hit, 100f);

			return hit;
		}

		private bool GameOver() {
			return !player.IsAlive();
		}

		public void RestartGame(int scene) {
			SceneManager.LoadScene(scene);
		}
	}
}
