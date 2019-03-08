using UnityEngine;

namespace ChronoPuzzle.World.Vision {

	public class DarknessScreenspaceOverlay : MonoBehaviour {

		[SerializeField]
		private Material material;
		[SerializeField]
		private string playerPositionName;
		[SerializeField]
		private string bonfirePositionName;
		[SerializeField]
		private Transform playerCharacter;
		[SerializeField]
		private Transform bonfire;
		
		private void Start() {
			if (! material.HasProperty(playerPositionName) || ! material.HasProperty(bonfirePositionName)) {
				Debug.LogError("Supplied material does not have the required properties");
				enabled = false;
			}
		}

		private void Update() {
			material.SetVector(playerPositionName, playerCharacter.position);
			material.SetVector(bonfirePositionName, bonfire.position);
		}

	}

}
