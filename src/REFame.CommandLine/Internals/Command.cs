using System.Collections.Generic;
using System.CommandLine.Invocation;
using REFame.CommandLine.Contracts;

namespace REFame.CommandLine.Internals
{
    /// <inheritdoc cref="ICommand"/>
    internal class Command : ICommand
    {
        /// <inheritdoc/>
        public string Name { get; internal set; }

        /// <inheritdoc/>
        public string Description { get; internal set; }

        /// <inheritdoc/>
        public IEnumerable<IOption> Options { get; internal set; }

        /// <inheritdoc />
        public ICommandHandler CommandHandler { get; set; }
    }
}