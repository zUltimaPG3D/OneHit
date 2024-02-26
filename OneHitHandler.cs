using Configgy;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class OneHitHandler : MonoBehaviour
{
	[Configgable(displayName: "Is enabled?")]
	public static ConfigToggle isOn = new(true);
}