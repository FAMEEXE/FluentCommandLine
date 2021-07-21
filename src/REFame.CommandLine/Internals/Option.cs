using System;
using System.Collections.Generic;
using REFame.CommandLine.Contracts;

namespace REFame.CommandLine.Internals
{
    /// <inheritdoc cref="IOption"/>
    internal class Option : IOption
    {
        /// <inheritdoc/>
        public IEnumerable<string> Aliases { get; init; }
        
        /// <inheritdoc/>
        public string Description { get; init; }

        /// <inheritdoc/>
        public Type Type { get; init; }
    }
}