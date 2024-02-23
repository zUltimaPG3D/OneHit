using BepInEx;
using Configgy;
using HarmonyLib;
using UnityEngine;

namespace OneHit;

[BepInPlugin(PluginData.GUID, PluginData.Name, PluginData.Version)]
[BepInDependency("Hydraxous.ULTRAKILL.Configgy")]
public class Plugin : BaseUnityPlugin
{
	private ConfigBuilder config;
	private void Awake()
	{
		config = new ConfigBuilder(PluginData.GUID, PluginData.Name);
		config.BuildAll();

		OneHitHandler d_h = new GameObject(PluginData.GUID).AddComponent<OneHitHandler>();
		DontDestroyOnLoad(d_h);

		Harmony harmony = new Harmony(PluginData.GUID);
		harmony.PatchAll(typeof(Patches));
	}
}
