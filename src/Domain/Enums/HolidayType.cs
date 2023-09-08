namespace Domain.Enums
{
    public enum HolidayType
    {
        /// <summary>
        /// Saturdays and Sundays and for some countrys Wednesday and Friday
        /// </summary>
        Weekend = 0,
        /// <summary>
        /// Public holiday
        /// </summary>
        Public = 1,
        /// <summary>
        /// Days before a public holiday
        /// </summary>
        BeforePublic = 2,
        /// <summary>
        /// // during the month of July
        /// </summary>
        SpecificDate = 3,
    }
}
