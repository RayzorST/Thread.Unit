using Unit.Enums;

namespace Unit.Types
{
    /// <summary>
    /// Information about operation
    /// </summary>
    public class Case
    {
        public string Name;
        private readonly Action action;
        /// <summary>
        /// If true, the object will continue to work in any situation except break
        /// </summary>
        private readonly bool important = false;
        private CaseStatus status = CaseStatus.Run;
        private Exception? exception = null;

        public Case(string name, Action action)
        {
            Name = name;
            this.action = action;
        }

        public Case(string name, Action action, bool important)
        {
            Name = name;
            this.action = action;
            this.important = important;
        }

        public void SetStatus(CaseStatus status)
        {
            if (!important) this.status = status;
        }

        public void Execute()
        {
            action();
        }

        public CaseStatus GetStatus()
        {
            return status;
        }

        public Exception? GetException()
        {
            return exception;
        }

        public void SetException(Exception ex)
        {
            exception = ex;
        }

        public bool IsImportant()
        {
            return important;
        }
    }
}
