using System;

namespace REFame.CommandLine.Contracts
{
    /// <summary>
    /// Build a command line tool 
    /// </summary>
    public interface ICommandLineBuilder
    {
        /// <summary>
        /// Adds a command.
        /// </summary>
        /// <param name="configuring">Action to configure the command</param>
        /// <returns></returns>
        ICommandLineBuilder AddCommand(Action<ICommandBuilder> configuring);

        /// <summary>
        /// Build the command line with all added commands
        /// </summary>
        /// <returns></returns>
        ICommandLine Build();
    }
}