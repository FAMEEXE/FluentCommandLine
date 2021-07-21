using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using REFame.CommandLine.Contracts;
using ICommand = REFame.CommandLine.Contracts.ICommand;
using IOption = REFame.CommandLine.Contracts.IOption;

namespace REFame.CommandLine
{
    /// <inheritdoc cref="ICommandLineBuilder"/>
    internal class CommandLineBuilder : ICommandLineBuilder
    {
        private readonly List<ICommandBuilder> commands = new();

        /// <inheritdoc/>
        public ICommandLineBuilder AddCommand(Action<ICommandBuilder> configuring)
        {
            var builder = new CommandBuilder();
            configuring(builder);
            commands.Add(builder);

            return this;
        }

        /// <inheritdoc/>
        public ICommandLine Build()
        {
            var root = new RootCommand();

            var commandsBuild = commands.ConvertAll(x => x.Build());

            foreach (ICommand internalCommand in commandsBuild)
            {
                var command = new Command(internalCommand.Name, internalCommand.Description);
                command.AddAlias(internalCommand.Name);
                foreach (IOption internalOption in internalCommand.Options)
                {
                    var option = new Option(
                        internalOption.Aliases.ToArray(), 
                        internalOption.Description,
                        internalOption.Type);

                    command.AddOption(option);
                }

                command.Handler = CommandHandler.Create(internalCommand.Callback);
                root.AddCommand(command);
            }


            return new Internals.CommandLine
            {
                Root = root,
                Commands = commandsBuild,
            };
        }
    }
}