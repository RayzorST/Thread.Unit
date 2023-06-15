using Unit.Enums;

namespace Unit.Types
{
    public class Unit
    {
        public string Name;
        /// <summary>
        /// List of functions performed in different threads
        /// </summary>
        public List<Case> Cases = new();

        public Unit(Action action, string UnitName, bool important = false)
        {
            Name = UnitName;
            Cases.Add(new Case(UnitName, action, important));
            new Thread(new ParameterizedThreadStart(Payload)).Start(0);
        }

        public Unit(List<Action> Actions, string UnitName, List<string> ActionNames, bool important = false)
        {
            Name = UnitName;
            for (int n = 0; n < Actions.Count; n++)
            {
                if (!AlreadyName(ActionNames[n]))
                {
                    Cases.Add(new Case(ActionNames[n], Actions[n], important));
                    new Thread(new ParameterizedThreadStart(Payload)).Start(n);
                }
            }
        }

        public void Add(Action action, string ActionName, bool important = false)
        {
            if (!AlreadyName(ActionName))
            {
                Cases.Add(new Case(ActionName, action, important));
                new Thread(new ParameterizedThreadStart(Payload)).Start(Cases.Count - 1);
            }
        }

        private void Payload(object? n)
        {
            int i = Convert.ToInt32(n);
            while (true)
            {
                try
                {
                    Cases[i].Execute();
                }
                catch (Exception e)
                {
                    Cases[i].SetException(e);
                    Cases[i].SetStatus(CaseStatus.Error);
                }
            }
        }

        private bool AlreadyName(string name)
        {
            foreach(var Case in Cases)
                if(Case.Name == name) return true;
            return false;
        }

        public string GetStatus()
        {
            string result = "";
            if (Cases.Count > 1)
            {
                result += Name;
                for (int i = 0; i < Cases.Count; i++)
                    result += (i == Cases.Count - 1 ? "└" : "├") + "─── " + Cases[i].Name + ":  " + Cases[i].GetStatus();
            }
            else
                result += Name + ":  " + Cases[0].GetStatus();

            return result;
        }
    }
}