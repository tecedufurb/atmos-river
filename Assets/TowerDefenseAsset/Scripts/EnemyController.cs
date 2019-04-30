using UnityEngine;
using UnityEngine.AI;

namespace TowerDefenseAsset {
	public class EnemyController : MonoBehaviour {

		[SerializeField]
		private int health;

		void Start() {
			NavMeshAgent agent = GetComponent<NavMeshAgent>();
			GameObject endOfTheRoad = GameObject.Find("EndOfTheRoad");
			agent.SetDestination (endOfTheRoad.transform.position);
		}

		public void LoseHealth(int damage) {
			health -= damage;
			if(health <= 0)
				Destroy(gameObject);
		}
	}
	
}
