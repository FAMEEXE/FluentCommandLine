using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using REFame.CommandLine.Contracts;
using REFame.CommandLine.Internals;

namespace REFame.CommandLine
{

    /// <inheritdoc cref="ICommandBuilder"/>
    internal class CommandBuilder : ICommandBuilder
    {
        private string name;
        private string description;

        private readonly List<IOption> options = new();
        private Action<string> callback;

        /// <inheritdoc/>
        public ICommandBuilder WithName(string commandName)
        {
            name = commandName;
            return this;
        }

        /// <inheritdoc/>
        public ICommandBuilder WithDescription(string commandDescription)
        {
            description = commandDescription;
            return this;
        }

        /// <inheritdoc/>
        public ICommandBuilder WithOption<T>(Action<IOptionBuilder<T>> configure)
        {
            IOptionBuilder<T> optionBuilder = new OptionBuilder<T>();
            configure(optionBuilder);
            
            options.Add(optionBuilder.Build());
            return this;
        }

        /// <inheritdoc/>
        public ICommandBuilder Callback(Action action)
        {
            callback = _ => action();
            return this;
        }

        public ICommandBuilder Callback(Action<string> action)
        {
            callback = action;
            return this;
        }

        /// <inheritdoc/>
        public ICommand Build()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidOperationException("Name cannot be null or empty");
            }

            return new Command
            {
                Callback = callback,
                Description = description,
                Name = name,
                Options = options
            };
        }
    }
}