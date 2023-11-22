namespace UIHotel
{
    public class BaseFormTrack : Form
    {
        public delegate void UserActionTracker(string action);
        public event UserActionTracker ?OnUserTracker;
        /// <summary>
        /// METODO PARA DISPARAR EL EVENTO DE TRACKER
        /// </summary>
        /// <param name="action"></param>
        protected void TriggerUserTracker(string action)
        {
            OnUserTracker?.Invoke(action);
        }
    }
}
