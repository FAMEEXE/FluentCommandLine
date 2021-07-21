using System;
using System.Collections.Generic;
using REFame.CommandLine.Contracts;

namespace REFame.CommandLine.Internals
{
    /// <inheritdoc cref="ICommand"/>
    internal class Command : ICommand
    {
        /// <inheritdoc/>
        public string Name { get; init; }

        /// <inheritdoc/>
        public string Description { get; init; }

        /// <inheritdoc/>
        public IEnumerable<IOption> Options { get; init; }

        /// <inheritdoc/>
        public Action<string> Callback { get; init; }
    }
}