using System;
using System.Collections.Generic;
using System.Linq;
using REFame.CommandLine.Contracts;
using REFame.CommandLine.Internals;

namespace REFame.CommandLine
{
    /// <inheritdoc cref="IOptionBuilder"/>/>
    internal class OptionBuilder<T> : IOptionBuilder<T>
    {
        private readonly List<string> alias = new List<string>();
        private string description;
        private Func<object> getDefaultValue;
        private bool required;

        /// <inheritdoc />
        public IOption Build()
        {
            if (!alias.Any())
            {
                throw new InvalidOperationException("provide alias");
            }

            return new Option()
            {
                Aliases = alias,
                Description = description,
                Type = typeof(T),
                DefaultValueCallback = getDefaultValue,
                Required = required,
            };
        }

        /// <inheritdoc />
        public IOptionBuilder<T> IsRequired()
        {
            this.required = true;
            return this;
        }

        /// <inheritdoc />
        public IOptionBuilder<T> WithDescription(string optionDescription)
        {
            description = optionDescription;
            return this;
        }

        /// <inheritdoc/>
        public IOptionBuilder<T> AddAlias(string optionAlias)
        {
            alias.Add(optionAlias);
            return this;
        }

        /// <inheritdoc />
        public IOptionBuilder<T> WithDefaultValue(Func<object> getDefaultValue)
        {
            this.getDefaultValue = getDefaultValue;
            return this;
        }
    }
}