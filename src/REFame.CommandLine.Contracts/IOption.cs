using System;
using System.Collections.Generic;

namespace REFame.CommandLine.Contracts
{
    /// <summary>
    /// Represents a option for the command line tool.
    /// </summary>
    public interface IOption
    {
        /// <summary>
        /// All registered aliases for the command line tool.
        /// </summary>
        IEnumerable<string> Aliases { get; }

        /// <summary>
        /// The description of the option.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The type of the option.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Callback for obtaining the default value of the option
        /// </summary>
        Func<object> DefaultValueCallback { get; }

        /// <summary>
        /// Gets a value whether the option is required 
        /// </summary>
        bool Required { get; }

        /// <summary>
        /// Gets a value whether the option is hidden
        /// </summary>
        bool Hidden { get; }
    }
}