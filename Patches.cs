using HarmonyLib;

public class Patches 
{
	[HarmonyPatch(typeof(SwordsMachine), "EndFirstPhase")]
	[HarmonyPrefix]
	public static bool p_EndFirstPhase()
	{
		if (!OneHitHandler.isOn.Value) {
			return true;
		}
		return false;
	}

	[HarmonyPatch(typeof(EnemyIdentifier), "Update")]
	[HarmonyPostfix]
	public static void p_EnemyIdentifier_Update(ref EnemyIdentifier __instance)
	{
		if (OneHitHandler.isOn.Value) {
			OneHitHandler.UpdateEID(__instance);
		}
	}

	[HarmonyPatch(typeof(DisabledEnemiesChecker), "Update")]
	[HarmonyPostfix]
	public static void p_DisabledEnemiesChecker_Update(ref DisabledEnemiesChecker __instance)
	{
		if (OneHitHandler.isOn.Value) {
			if (__instance.gameObject.name.Contains("Invisible")) {
				__instance.gameObject.SetActive(false);
			}
		}
	}

	[HarmonyPatch(typeof(GameStateManager), "CanSubmitScores", MethodType.Getter)]
	[HarmonyPostfix]
	public static void p_CanSubmitScores(ref bool __result) {
		if (OneHitHandler.isOn.Value) {
			__result = false;
		}
	}
}