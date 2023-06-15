using Unit.Enums;

namespace Unit.Types
{
    /// <summary>
    /// List of operations
    /// </summary>
    public class Case
    {
        public string Name;
        private readonly Action action;
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
            if (!important)
                this.status = status;
        }

        public void Execute()
        {
            if (status == 0) action();
            else if (status != 0 && important) status = 0;
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
    }
}
