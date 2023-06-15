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
        /// The action is suspended correctly, with the ability to continue
        /// </summary>
        Default = 1,
        /// <summary>
        /// The action was suspended incorrectly, due to an error
        /// </summary>
        Error = 2,
        /// <summary>
        /// Thread stops completely, without the ability to continue
        /// </summary>
        Break = 3,
    }
}
