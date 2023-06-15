namespace Unit.Enums
{
    /// <summary>
    /// Current status of the action
    /// </summary>
    public enum CaseStatus
    {
        /// <summary>
        /// The action is executed correctly
        /// </summary>
        Run = 0,
        /// <summary>
        /// The action is suspended correctly
        /// </summary>
        Default = 1,
        /// <summary>
        /// The action was suspended incorrectly, due to an error
        /// </summary>
        Error = 2,
    }
}
