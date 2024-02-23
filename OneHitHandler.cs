using Configgy;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class OneHitHandler : MonoBehaviour
{
	[Configgable(displayName: "Is enabled?")]
	public static ConfigToggle isOn = new(true);
	public static float SET_HP = .25f;

	public static void UpdateEID(EnemyIdentifier e) {
		if (e) {
			if (e.health > SET_HP)
				e.health = SET_HP;
		}

		if (e.zombie) {
			if (e.zombie.health > SET_HP)
				e.zombie.health = SET_HP;
		}
				
		if (e.spider) {
			if (e.spider.health > SET_HP)
				e.spider.health = SET_HP;
		}

		if (e.drone) {
			if (e.drone.health > SET_HP)
				e.drone.health = SET_HP;
		}

		if (e.machine) {
			if (e.machine.health > SET_HP)
				e.machine.health = SET_HP;
		}
				
		if (e.statue) {
			if (e.statue.health > SET_HP)
				e.statue.health = SET_HP;
		}
	}

	private void LateUpdate() {
		if (isOn.Value)
			if (NewMovement.Instance)
				if (NewMovement.Instance.hp > 1)
					NewMovement.Instance.hp = 1;
	}
}