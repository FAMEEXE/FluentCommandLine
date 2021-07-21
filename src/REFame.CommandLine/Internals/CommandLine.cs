using System.Collections.Generic;
using System.CommandLine;
using System.Threading.Tasks;
using REFame.CommandLine.Contracts;
using ICommand = REFame.CommandLine.Contracts.ICommand;

namespace REFame.CommandLine.Internals
{
    /// <inheritdoc cref="ICommandLine"/>
    internal class CommandLine : ICommandLine
    {
        /// <summary>
        /// An internal object who contains the real command 
        /// </summary>
        internal RootCommand Root { get; init; }

        /// <inheritdoc/>
        public IEnumerable<ICommand> Commands { get; init; }

        /// <inheritdoc/>
        public Task<int> Run(string[] args)
        {
            return Root.InvokeAsync(args);
        }
    }
}