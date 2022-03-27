using Exiled.API.Interfaces;
using System.ComponentModel;

namespace MegaUtils
{
	public class Config : IConfig
	{
		[Description("Whether or not the plugin is enabled.")]
		public bool IsEnabled { get; set; } = true;

		[Description("Turn on TPS Debugger.")]
		public bool TpsDebug { get; set; } = true;

		[Description("Time between every TPS check. (in seconds)")]
		public float TpsCheckDelay { get; set; } = 10;
	}
}
