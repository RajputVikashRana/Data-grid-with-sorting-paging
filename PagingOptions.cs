namespace Models.Core
{
    /// <summary>
    /// Represents a paging option
    /// </summary>
    public class PagingOptions
    {
        /// <summary>
        /// Gets or sets the SortField parameter
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Gets or sets the SortOrder value for sort order
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the Page Index for paging 
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the Page Size total number record display
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number record
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// Gets or sets the total number PAGE
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets the position of the first record to be displayed.
        /// </summary>        
        public int? LowerBound => ((PageIndex - 1) * PageSize) + 1;

        /// <summary>
        /// Gets the position of the last record to be displayed.
        /// </summary>
        public int? UpperBound => (LowerBound + PageSize) > RecordCount ? RecordCount : (LowerBound + PageSize);
    }
}
