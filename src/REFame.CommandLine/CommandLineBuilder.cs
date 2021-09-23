using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using REFame.CommandLine.Contracts;
using ICommand = REFame.CommandLine.Contracts.ICommand;
using IOption = REFame.CommandLine.Contracts.IOption;

namespace REFame.CommandLine
{
    /// <inheritdoc cref="ICommandLineBuilder"/>
    public class CommandLineBuilder : ICommandLineBuilder
    {
        private readonly List<ICommandBuilder> commands = new List<ICommandBuilder>();

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
                        internalOption.Type, 
                        internalOption.DefaultValueCallback)
                    {
                        IsRequired = internalOption.Required
                    };

                    command.AddOption(option);
                }

                command.Handler = internalCommand.CommandHandler;
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