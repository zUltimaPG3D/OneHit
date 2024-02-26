using System.Diagnostics;
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

	[HarmonyPatch(typeof(NewMovement), "GetHurt")]
	[HarmonyPrefix]
	public static bool p_NewMovement_GetHurt(ref NewMovement __instance, ref int __0)
	{
		if (OneHitHandler.isOn.Value && __0 != 0) {
			__0 = int.MaxValue;
		}
		return true;
	}

	[HarmonyPatch(typeof(EnemyIdentifier), "DeliverDamage")]
	[HarmonyPrefix]
	public static bool p_EnemyIdentifier_DeliverDamage(ref EnemyIdentifier __instance, ref float __3)
	{
		if (OneHitHandler.isOn.Value && __3 != 0) {
			__3 = int.MaxValue;
		}
		return true;
	}

	[HarmonyPatch(typeof(GameStateManager), "CanSubmitScores", MethodType.Getter)]
	[HarmonyPostfix]
	public static void p_CanSubmitScores(ref bool __result) {
		if (OneHitHandler.isOn.Value) {
			__result = false;
		}
	}
}