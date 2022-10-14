using Base.Core;
using Base.Defs;
using Base.Levels;
using PhoenixPoint.Common.Game;
using PhoenixPoint.Modding;
using Code.PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Geoscape.Entities.Research;
using PhoenixPoint.Geoscape.Entities.Research.Cost;
using PhoenixPoint.Geoscape.Entities.Research.Requirement;
using PhoenixPoint.Geoscape.Entities.Research.Reward;
using PhoenixPoint.Tactical.Entities.Statuses;
using PhoenixPoint.Tactical.Entities.Weapons;
using System.Linq;
using UnityEngine;

namespace ResearchandVehicle
{
	/// <summary>
	/// This is the main mod class. Only one can exist per assembly.
	/// If no ModMain is detected in assembly, then no other classes/callbacks will be called.
	/// </summary>
	public class ResearchandVehicleMain : ModMain
	{
		/// Config is accessible at any time, if any is declared.
		public new ResearchandVehicleConfig Config => (ResearchandVehicleConfig)base.Config;

		/// This property indicates if mod can be Safely Disabled from the game.
		/// Safely sisabled mods can be reenabled again. Unsafely disabled mods will need game restart ot take effect.
		/// Unsafely disabled mods usually cannot revert thier changes in OnModDisabled
		public override bool CanSafelyDisable => true;

		/// <summary>
		/// Callback for when mod is enabled. Called even on game starup.
		/// </summary>
		public override void OnModEnabled() {

			/// All mod dependencies are accessible and always loaded.
			int c = Dependencies.Count();
			/// Mods have their own logger. Message through this logger will appear in game console and Unity log file.
			Logger.LogInfo($"Say anything crab people-related.");
			/// Metadata is whatever is written in meta.json
			string v = MetaData.Version.ToString();
			/// Game creates Harmony object for each mod. Accessible if needed.
			HarmonyLib.Harmony harmony = (HarmonyLib.Harmony)HarmonyInstance;
			/// Mod instance is mod's runtime representation in game.
			string id = Instance.ID;
			/// Game creates Game Object for each mod. 
			GameObject go = ModGO;
			/// PhoenixGame is accessible at any time.
			PhoenixGame game = GetGame();

			/// Apply any general game modifications.
			DefRepository Repo = GameUtl.GameComponent<DefRepository>();

			//ResourcePack Money1 = Repo.GetAllDefs<ResourcesDef>().FirstOrDefault(b => b.name.Equals("Material_ResourceDef"));
			
			ResearchDef PandoranColony = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Colony_ResearchDef"));

			PandoranColony.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 250 * 70 };
			PandoranColony.Resources[1] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Tech, Value = 125 * 70 };
			PandoranColony.Resources[2] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Supplies, Value = 375 * 70 };

			ResearchDef PandoranEvo = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_EvolvedAliens_ResearchDef"));

			PandoranEvo.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 375 * 70 };
			PandoranEvo.Resources[1] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Tech, Value = 190 * 70 };

			ResearchDef PandoranLair = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Lair_ResearchDef"));

			PandoranLair.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 375 * 70 };
			PandoranLair.Resources[1] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Tech, Value = 190 * 70 };
			PandoranLair.Resources[2] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Supplies, Value = 500 * 70 };

			ResearchDef ScyllaAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Queen_ResearchDef"));

			ScyllaAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 250 * 70 };
			ScyllaAutopsy.Resources[1] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Tech, Value = 125 * 70 };
			ScyllaAutopsy.Resources[2] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Supplies, Value = 625 * 70 };

			ResearchDef DoA = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_DisciplesOfAnu_ResearchDef"));

			DoA.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Supplies, Value = 250 * 70 };

			ResearchDef NJ = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_NewJericho_ResearchDef"));

			NJ.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 315 * 70 };

			ResearchDef Syned = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Synedrion_ResearchDef"));

			Syned.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Tech, Value = 190 * 70 };

			ResearchDef MutiodCreate = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Mutoid_ResearchDef"));

			MutiodCreate.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Mutagen, Value = 500 * 70 };

			ResearchDef AcheronAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Acheron_ResearchDef"));

            AcheronAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Mutagen, Value = 250 * 70 };

			ResearchDef MindfraggerAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Mindfragger_ResearchDef"));
			ResearchDef FirewormAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Fireworm_ResearchDef"));
			ResearchDef PoisonwormAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Poisonworm_ResearchDef"));
			ResearchDef AcidwormAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Acidworm_ResearchDef"));
			ResearchDef MindfraggerEggAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_MindfraggerEgg_ResearchDef"));
			ResearchDef WormEggAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_WormEgg_ResearchDef"));
			ResearchDef SirenAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Siren_ResearchDef"));
			ResearchDef ChironAutopsy = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("PX_Alien_Chiron_ResearchDef"));

			MindfraggerAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 190*70};
			FirewormAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 125 * 70 };
			PoisonwormAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 125 * 70 };
			AcidwormAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 125 * 70 };
			MindfraggerEggAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 65 * 70 };
			MindfraggerEggAutopsy.Resources[1] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Supplies, Value = 500 * 70 };
			WormEggAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 65 * 70 };
			WormEggAutopsy.Resources[1] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Supplies, Value = 500 * 70 };
			SirenAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 190 * 70 };
			ChironAutopsy.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Materials, Value = 125 * 70 };
			ChironAutopsy.Resources[1] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Supplies, Value = 375 * 70 };
			ChironAutopsy.Resources[2] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Tech, Value = 65 * 70 };

			DamageMultiplierStatusDef MindfraggerVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToFacehugger_FactionEffectDef]"));
			DamageMultiplierStatusDef FirewormVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToFireworm_FactionEffectDef]"));
			DamageMultiplierStatusDef PoisonwormVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToPoisonworm_FactionEffectDef]"));
			DamageMultiplierStatusDef AcidwormVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToAcidworm_FactionEffectDef]"));
			DamageMultiplierStatusDef ArthronVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToCrabman_FactionEffectDef]"));
			DamageMultiplierStatusDef TritonVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToFishman_FactionEffectDef]"));
			DamageMultiplierStatusDef SirenVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToSiren_FactionEffectDef]"));
			DamageMultiplierStatusDef ChironVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToChiron_FactionEffectDef]"));
			DamageMultiplierStatusDef ScyllaVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToQueen_FactionEffectDef]"));
			DamageMultiplierStatusDef TerrorSentinel = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToSentinelTerror_FactionEffectDef]"));
			DamageMultiplierStatusDef HatchingSentinel = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToSentinelHatching_FactionEffectDef]"));
			DamageMultiplierStatusDef MistSentinel = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToSentinelMist_FactionEffectDef]"));
			DamageMultiplierStatusDef PandoranSpawnery = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToSpawnery_FactionEffectDef]"));
			DamageMultiplierStatusDef AcheronVivisection = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToAcheron_FactionEffectDef]"));
			DamageMultiplierStatusDef MoonDataAnalys = Repo.GetAllDefs<DamageMultiplierStatusDef>().FirstOrDefault(a => a.name.Equals("E_Status [DamageBonusToAliens_FactionEffectDef]"));

			MindfraggerVivisection.Multiplier = 1.8f;
			FirewormVivisection.Multiplier = 1.8f;
			PoisonwormVivisection.Multiplier = 1.8f;
			AcidwormVivisection.Multiplier = 1.8f;
			ArthronVivisection.Multiplier = 1.8f;
			TritonVivisection.Multiplier = 1.8f;
			SirenVivisection.Multiplier = 1.8f;
			ChironVivisection.Multiplier = 1.8f;
			ScyllaVivisection.Multiplier = 1.8f;
			AcheronVivisection.Multiplier = 1.8f;
			MoonDataAnalys.Multiplier = 1.8f;
			TerrorSentinel.Multiplier = 1.85f;
			HatchingSentinel.Multiplier = 1.85f;
			MistSentinel.Multiplier = 1.85f;
			PandoranSpawnery.Multiplier = 1.9f;

			FactionModifierResearchRewardDef ProtoCiv = Repo.GetAllDefs<FactionModifierResearchRewardDef>().FirstOrDefault(a => a.name.Equals("PX_ProtoCivilisation1_ResearchDef_FactionModifierResearchRewardDef_0"));
			ProtoCiv.ExperienceAfterMissionModifier = 0.8f;

			ResearchDef AnuAlienReligion = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(a => a.name.Equals("ANU_AlienReligion_ResearchDef"));

			AnuAlienReligion.Resources[0] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Supplies, Value = 500 * 70 };
			AnuAlienReligion.Resources[1] = new PhoenixPoint.Common.Core.ResourceUnit { Type = PhoenixPoint.Common.Core.ResourceType.Tech, Value = 250 * 70 };

			ResearchBonusResearchRewardDef NewJerichoPandoranPhysiology = Repo.GetAllDefs<ResearchBonusResearchRewardDef>().FirstOrDefault(a => a.name.Equals("NJ_AlienPhysiology_ResearchDef_ResearchBonusResearchRewardDef_0"));
			NewJerichoPandoranPhysiology.Amount = 0.95f;
			FacilityBuffResearchRewardDef ProductionRobotics = Repo.GetAllDefs<FacilityBuffResearchRewardDef>().FirstOrDefault(a => a.name.Equals("NJ_AutomatedFactories_ResearchDef_FacilityBuffResearchRewardDef_0"));
			ProductionRobotics.Increase = 1.20f;
			FacilityBuffResearchRewardDef CentralizedAI = Repo.GetAllDefs<FacilityBuffResearchRewardDef>().FirstOrDefault(a => a.name.Equals("NJ_CentralizedAI_ResearchDef_FacilityBuffResearchRewardDef_0"));
			CentralizedAI.Increase = 1.20f;
			FactionModifierResearchRewardDef NJSU = Repo.GetAllDefs<FactionModifierResearchRewardDef>().FirstOrDefault(a => a.name.Equals("NJ_SateliteUplink_ResearchDef_FactionModifierResearchRewardDef_0"));
			NJSU.ScannerRangeModifier = 0.95f;

			FacilityBuffResearchRewardDef SynFusionCellTech = Repo.GetAllDefs<FacilityBuffResearchRewardDef>().FirstOrDefault(a => a.name.Equals("SYN_FusionCellTech_ResearchDef_FacilityBuffResearchRewardDef_0"));
			SynFusionCellTech.Increase = 1.20f;
			FacilityBuffResearchRewardDef SynNanoHealing = Repo.GetAllDefs<FacilityBuffResearchRewardDef>().FirstOrDefault(a => a.name.Equals("SYN_NanoHealing_ResearchDef_FacilityBuffResearchRewardDef_0"));
			SynNanoHealing.Increase = 1.2f;
			FacilityBuffResearchRewardDef SynSAItech = Repo.GetAllDefs<FacilityBuffResearchRewardDef>().FirstOrDefault(a => a.name.Equals("SYN_SentientAITech_ResearchDef_FacilityBuffResearchRewardDef_0"));
			SynSAItech.Increase = 1.2f;

			GroundVehicleWeaponDef Taurus = Repo.GetAllDefs<GroundVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_Scarab_Taurus_GroundVehicleWeaponDef"));
			Taurus.APToUsePerc = 21;
			Taurus.IncompetenceAccuracyMultiplier = 1;
			Taurus.HandsToUse = 0;
			Taurus.DamagePayload.DamageKeywords[0].Value = 350;
			
			GroundVehicleWeaponDef Scorpio = Repo.GetAllDefs<GroundVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_Scarab_Scorpio_GroundVehicleWeaponDef"));
			Scorpio.APToUsePerc = 21;
			Scorpio.IncompetenceAccuracyMultiplier = 1;
			Scorpio.HandsToUse = 0;
			Scorpio.DamagePayload.DamageKeywords[0].Value = 120;
			
			GroundVehicleWeaponDef PhoenixMT = Repo.GetAllDefs<GroundVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_Scarab_Missile_Turret_GroundVehicleWeaponDef"));
			PhoenixMT.APToUsePerc = 21;
			PhoenixMT.IncompetenceAccuracyMultiplier = 1;
			PhoenixMT.HandsToUse = 0;
			PhoenixMT.DamagePayload.DamageKeywords[0].Value = 80;

			ShootAbilityDef ScorpioShoot100 = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("LaunchMissiles_ShootAbilityDef"));
			ShootAbilityDef PhoenixMTShoot100 = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("LaunchMissiles_ShootAbilityDef"));

			ScorpioShoot100.UsesPerTurn = 100;
			PhoenixMTShoot100.UsesPerTurn = 100;

			WeaponDef KaosChaosFullstop = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("KS_Buggy_Fullstop_WeaponDef"));
			WeaponDef KaosChaosMinigunFullstop = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("KS_Buggy_Minigun_Fullstop_WeaponDef"));
			WeaponDef KaosChaosMinigunScreamer = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("KS_Buggy_Minigun_Screamer_WeaponDef"));
			WeaponDef KaosChaosScreamer = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("KS_Buggy_Screamer_WeaponDef"));
			WeaponDef KaosChaosMinigunVishnu = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("KS_Buggy_Minigun_Vishnu_WeaponDef"));
			WeaponDef KaosChaosTheVishnuGunCannon = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("KS_Buggy_The_Vishnu_Gun_Cannon_WeaponDef"));

			KaosChaosFullstop.APToUsePerc = 14;
			KaosChaosFullstop.IncompetenceAccuracyMultiplier = 1;
			KaosChaosFullstop.HandsToUse = 0;
			KaosChaosFullstop.DamagePayload.DamageKeywords[0].Value = 1;

			KaosChaosMinigunFullstop.APToUsePerc = 14;
			KaosChaosMinigunFullstop.IncompetenceAccuracyMultiplier = 1;
			KaosChaosMinigunFullstop.HandsToUse = 0;
			KaosChaosMinigunFullstop.DamagePayload.DamageKeywords[0].Value = 50;

			KaosChaosMinigunScreamer.APToUsePerc = 14;
			KaosChaosMinigunScreamer.IncompetenceAccuracyMultiplier = 1;
			KaosChaosMinigunScreamer.HandsToUse = 0;
			KaosChaosMinigunScreamer.DamagePayload.DamageKeywords[0].Value = 50;

			KaosChaosScreamer.APToUsePerc = 14;
			KaosChaosScreamer.IncompetenceAccuracyMultiplier = 1;
			KaosChaosScreamer.HandsToUse = 0;
			KaosChaosScreamer.DamagePayload.DamageKeywords[0].Value = 80;

			KaosChaosMinigunVishnu.APToUsePerc = 14;
			KaosChaosMinigunVishnu.IncompetenceAccuracyMultiplier = 1;
			KaosChaosMinigunVishnu.HandsToUse = 0;
			KaosChaosMinigunVishnu.DamagePayload.DamageKeywords[0].Value = 50;

			KaosChaosTheVishnuGunCannon.APToUsePerc = 21;
			KaosChaosTheVishnuGunCannon.IncompetenceAccuracyMultiplier = 1;
			KaosChaosTheVishnuGunCannon.HandsToUse = 0;
			KaosChaosTheVishnuGunCannon.DamagePayload.DamageKeywords[0].Value = 80;
		}

		/// <summary>
		/// Callback for when mod is disabled. This will be called even if mod cannot be safely disabled.
		/// Guaranteed to have OnModEnabled before.
		/// </summary>
		public override void OnModDisabled() {
			/// Undo any game modifications if possible. Else "CanSafelyDisable" must be set to false.
			/// ModGO will be destroyed after OnModDisabled.
		}

		/// <summary>
		/// Callback for when any property from mod's config is changed.
		/// </summary>
		public override void OnConfigChanged() {
			/// Config is accessible at any time.
		}


		/// <summary>
		/// In Phoenix Point there can be only one active level at a time. 
		/// Levels go through different states (loading, unloaded, start, etc.).
		/// General puprose level state change callback.
		/// </summary>
		/// <param name="level">Level being changed.</param>
		/// <param name="prevState">Old state of the level.</param>
		/// <param name="state">New state of the level.</param>
		public override void OnLevelStateChanged(Level level, Level.State prevState, Level.State state) {
			/// Alternative way to access current level at any time.
			Level l = GetLevel();
		}

		/// <summary>
		/// Useful callback for when level is loaded, ready, and starts.
		/// Usually game setup is executed.
		/// </summary>
		/// <param name="level">Level that starts.</param>
		public override void OnLevelStart(Level level) {
		}

		/// <summary>
		/// Useful callback for when level is ending, before unloading.
		/// Usually game cleanup is executed.
		/// </summary>
		/// <param name="level">Level that ends.</param>
		public override void OnLevelEnd(Level level) {
		}
	}
}
