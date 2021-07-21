using System.Collections.Generic;
using REFame.CommandLine.Contracts;
using REFame.CommandLine.Internals;

namespace REFame.CommandLine
{
    /// <inheritdoc cref="IOptionBuilder"/>/>
    internal class OptionBuilder<T> : IOptionBuilder<T>
    {
        private readonly List<string> alias = new List<string>();
        private string description;

        public IOption Build()
        {
            return new Option()
            {
                Aliases = alias,
                Description = description,
                Type = typeof(T),
            };
        }

        public IOptionBuilder<T> WithDescription(string optionDescription)
        {
            description = optionDescription;
            return this;
        }

        public IOptionBuilder<T> AddAlias(string optionAlias)
        {
            alias.Add(optionAlias);
            return this;
        }
    }
}