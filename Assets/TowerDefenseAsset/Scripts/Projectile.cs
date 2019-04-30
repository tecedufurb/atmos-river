using UnityEngine;

namespace TowerDefenseAsset {
	public class Projectile : MonoBehaviour {

		[SerializeField]
		private int damage;
		private float speed = 10f;
		private EnemyController target;

		public EnemyController Target {
			get { 
				return target;
			}
			set { 
				target = value;
			}
		}

		void Start() {
			SelfDestroy(5f);
		}

		void Update() {
			Walk();	
			if (target != null)
				ChangeDirection();
		}

		private void Walk() {
			transform.position += transform.forward * Time.deltaTime * speed; 
		}

		private void ChangeDirection() {
			transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		}

		void OnTriggerEnter(Collider other) {
			if(other.CompareTag("Enemy")) {
				Destroy(gameObject);
				EnemyController enemy = other.GetComponent<EnemyController>();
				enemy.LoseHealth(damage);
			}
		}

		private void SelfDestroy(float time) {
			Destroy(gameObject, time);
		}
	}
}
