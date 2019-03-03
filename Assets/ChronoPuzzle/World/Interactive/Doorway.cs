using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : InteractiveObject {

	public Vector2 teleportExitPosition;
	public Doorway otherEnd;
	public string characterTag = "Player";

	public override void activate(GameObject activator) {
		if (activator.CompareTag(characterTag)) {
			base.playSound("Sound/door_open");
			otherEnd.acceptEntityTeleport(activator);
		}
	}

	public override GameObject pickup(GameObject parentGameObject) { return null; }

	public override GameObject drop(GameObject exParentGameObject) { return null; }

	public void acceptEntityTeleport(GameObject entity) {
		entity.transform.position = teleportExitPosition;
	}

	private void OnDrawGizmosSelected() {
		Gizmos.DrawIcon(teleportExitPosition, "point.png");
	}
}
