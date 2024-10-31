using Exiled.API.Features;
using MEC;

namespace MegaUtils
{
	public class EventHandler
	{
		private CoroutineHandle Tpscoroutine;
		public IEnumerator<float> tpsCoroutine()
        {
            for (; ; )
            {
                if (MegaUtils.Instance.Config.TpsDebug)
                {
                    Log.Info($"TPS: {Server.Tps}");
                }
                yield return Timing.WaitForSeconds(MegaUtils.Instance.Config.TpsCheckDelay);
            }
        }
		public void OnWaitingForPlayers()
        {
            Log.Debug($"Server is Waiting for players, stopping and starting Coroutines.");
            if (MegaUtils.Instance.Config.TpsDebug) 
            {
                Timing.KillCoroutines(Tpscoroutine);
                Tpscoroutine = Timing.RunCoroutine(tpsCoroutine());
            }  
        }
	}
}
