using System.Collections.Generic;
using System.CommandLine.Invocation;

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
        /// Get the handler of the command. This is the object for executing the command
        /// </summary>
        ICommandHandler CommandHandler { get; }
    }
}
