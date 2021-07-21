using System;

namespace REFame.CommandLine.Contracts
{
    /// <summary>
    /// Represents a builder for a command of the command line
    /// </summary>
    public interface ICommandBuilder
    {
        /// <summary>
        /// Set the name of the command
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns></returns>
        ICommandBuilder WithName(string name);

        /// <summary>
        /// Set the description of the command
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns></returns>
        ICommandBuilder WithDescription(string description);

        /// <summary>
        /// Add an option to the command
        /// </summary>
        /// <typeparam name="T">The type of the command</typeparam>
        /// <param name="configure">Configuration of the command</param>
        /// <returns></returns>
        ICommandBuilder WithOption<T>(Action<IOptionBuilder<T>> configure);
        
        /// <summary>
        /// Set the callback of the command
        /// </summary>
        /// <param name="callback">The callback of the command</param>
        /// <returns></returns>
        ICommandBuilder Callback<T>(Action<T> callback);

        /// <summary>
        /// Build the Command.
        /// </summary>
        /// <returns>The command with all its items</returns>
        ICommand Build();
    }
}