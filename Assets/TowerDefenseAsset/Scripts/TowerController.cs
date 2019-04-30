using UnityEngine;

namespace TowerDefenseAsset {
	public class TowerController : MonoBehaviour {

		public GameObject projectilePrefab; 	
		[Range(0,3)] 
		public float reloadTime = 1f;

		[SerializeField] 
		private float rangeRadius;
		private float lastShotTime;

		void Update() {
			EnemyController target = ChooseTarget();
			if(target != null)
				Shoot(target);
		}

		private void Shoot(EnemyController enemy) {
			float currentTime = Time.time;
			if(currentTime > lastShotTime + reloadTime) {
				lastShotTime = currentTime;
				Transform shooterPoint = this.transform.Find("TowerCannon/ShooterPoint");
				GameObject newProjectile = Instantiate(projectilePrefab, shooterPoint.position, Quaternion.identity);
				Projectile projectile = newProjectile.GetComponent<Projectile>();
				projectile.Target = enemy;
			}
		}

		private EnemyController ChooseTarget() { 
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach(GameObject enemy in enemies) {
				if(IsInRange(enemy))
					return enemy.GetComponent<EnemyController>();
			}
			return null;
		}

		private bool IsInRange(GameObject enemy) {
			Vector3 towerPositionOnPlane = Vector3.ProjectOnPlane(transform.position, Vector3.up);
			Vector3 enemyPositionOnPlane = Vector3.ProjectOnPlane(enemy.transform.position, Vector3.up);

			float enemyDistance = Vector3.Distance(towerPositionOnPlane, enemyPositionOnPlane);
			return enemyDistance <= rangeRadius;
		}
	}
}
