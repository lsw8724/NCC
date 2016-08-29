using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCCCommon.ModuleProtocol.OmapProtocol
{
    public interface IFetchTrigger
    {
        bool FetchTrigger();
    }

    public class SimpleTimeTrigger : IFetchTrigger
    {
        public event Action Triggered;

        public TimeSpan Period { get; set; }

        private DateTime lastChecked;

        public SimpleTimeTrigger(TimeSpan period)
        {
            Period = period;
            lastChecked = DateTime.UtcNow;
        }

        public bool FetchTrigger()
        {
            var now = DateTime.UtcNow;
            var elapsed = now - lastChecked;
            if (elapsed > Period)
            {
                lastChecked = now;
                Triggered();
                return true;
            }
            return false;
        }
    }
}
