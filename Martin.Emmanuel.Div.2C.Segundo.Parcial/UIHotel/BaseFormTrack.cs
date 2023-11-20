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
