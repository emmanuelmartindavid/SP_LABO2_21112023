using Entities.Models;


namespace Entities.Utilities
{
    public static class UtilityClass
    {
        private static List<Billing> _billings;
        private static List<string> _actionLog;
        /// <summary>
        /// 
        /// </summary>
        public static List<Billing> Billings
        {
            get
            {
                _billings ??= new();
                return _billings;
            }
            set
            {
                _billings = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static List<string> ActionLog
        {
            get
            {
                _actionLog ??= new();
                return _actionLog;
            }
            set
            {
                _actionLog = value;
            }        
        }
    }
}
