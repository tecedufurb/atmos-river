using UnityEngine;
namespace TowerDefenseAsset {
	public class PlayerController : MonoBehaviour {

		[SerializeField]
		private int health;

		public int Health {
			get { 
				return health;
			}
			set { 
				health = value;
			}
		}

		public void LoseHealth() {
			if(IsAlive())
				health--;
		}

		public bool IsAlive() {
			return health > 0;
		}

	}
}