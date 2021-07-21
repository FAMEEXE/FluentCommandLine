using System;

namespace REFame.CommandLine.Contracts
{
    /// <summary>
    /// Build an option
    /// </summary>
    public interface IOptionBuilder
    {
        IOption Build();
    }

    /// <summary>
    /// Build an option with a generic Action
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOptionBuilder<T> : IOptionBuilder
    {
        /// <summary>
        /// Sets the description for the option
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns></returns>
        IOptionBuilder<T> WithDescription(string description);

        /// <summary>
        /// Adds an alias for an option
        /// </summary>
        /// <param name="alias">The new alias</param>
        /// <returns></returns>
        IOptionBuilder<T> AddAlias(string alias);

        /// <summary>
        /// Sets the callback to obtain the default value
        /// </summary>
        /// <param name="getDefaultValue"></param>
        IOptionBuilder<T> WithDefaultValue(Func<object> getDefaultValue);

        /// <summary>
        /// Sets the option as required
        /// </summary>
        /// <returns></returns>
        IOptionBuilder<T> IsRequired();
    }
}