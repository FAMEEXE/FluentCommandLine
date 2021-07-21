using System;
using System.Collections.Generic;

namespace REFame.CommandLine.Contracts
{
    /// <summary>
    /// Represents a command of the command line
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The name of the command.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The description of the command.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// All possible options of a command
        /// </summary>
        IEnumerable<IOption> Options { get; }

        /// <summary>
        /// The callback of the command
        /// </summary>
        Action<string> Callback { get; }
    }
}