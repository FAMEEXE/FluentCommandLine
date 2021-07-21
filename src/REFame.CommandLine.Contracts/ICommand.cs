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
        public string Name { get; }

        /// <summary>
        /// The description of the command.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// All possible options of a command
        /// </summary>
        public IEnumerable<IOption> Options { get; }

        /// <summary>
        /// The callback of the command
        /// </summary>
        public Action<string> Callback { get; }
    }
}