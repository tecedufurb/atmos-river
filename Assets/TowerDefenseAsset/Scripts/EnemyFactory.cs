using UnityEngine;

namespace TowerDefenseAsset {
	public class EnemyFactory : MonoBehaviour {

		[SerializeField]
		private GameObject enemy;
		private float instantiationTime = 2f;
		private float lastInstantiationTime;

		void Update() {
			InstantiateEnemy();
		}

		private void InstantiateEnemy() {
			float currentTime = Time.time;
			if(currentTime > lastInstantiationTime + instantiationTime) {
				lastInstantiationTime = currentTime;
				Instantiate(enemy, transform.position, Quaternion.identity);
			}
		}
	}
}
