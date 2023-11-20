using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIHotel
{
    public class BaseFormTrack : Form
    {
        public delegate void UserActionTracker(string action);
        public event UserActionTracker OnUserTracker;
        protected void TriggerUserTracker(string action)
        {
            OnUserTracker?.Invoke(action);
        }
    }
}
