using Exiled.API.Interfaces;
using System.ComponentModel;

namespace MegaUtils
{
	public class Config : IConfig
	{
		[Description("Whether or not the plugin is enabled.")]
		public bool IsEnabled { get; set; } = true;

		[Description("Time between every TPS check. (in seconds)")]
		public float TpsCheckDelay { get; set; } = 5;

		[Description("Turn on TPS Debugger.")]
		public bool TpsDebug { get; set; } = true;

		[Description("Remove ragdolls when under TPS deadline.")]
		public bool TpsRemoveRagdollsUnderDeadline { get; set; } = true;

		[Description("Remove items when under TPS deadline.")]
		public bool TpsRemoveItemsUnderDeadline { get; set; } = true;

		[Description("TPS deadline.")]
		public float TpsDeadline { get; set; } = 20;

		[Description("Minimum number of players to start round.")]
		public float MinimumPlayers { get; set; } = 1;		
	}
}
