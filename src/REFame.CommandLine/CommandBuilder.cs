using System;
using System.Collections.Generic;
using System.CommandLine.Invocation;
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
        private ICommandHandler commandHandler;


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

        public ICommandBuilder Callback(ICommandHandler handler)
        {
            commandHandler = handler;
            return this;
        }

        /// <inheritdoc/>
        [Obsolete]
        public ICommandBuilder Callback<T>(Action<T> action)
        {
            commandHandler = CommandHandler.Create(action);
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
                CommandHandler = commandHandler,
                Description = description,
                Name = name,
                Options = options
            };
        }
    }
}