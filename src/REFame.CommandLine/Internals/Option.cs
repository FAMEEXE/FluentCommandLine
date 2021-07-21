using System;
using System.Collections.Generic;
using REFame.CommandLine.Contracts;

namespace REFame.CommandLine.Internals
{
    /// <inheritdoc cref="IOption"/>
    internal class Option : IOption
    {
        /// <inheritdoc/>
        public IEnumerable<string> Aliases { get; internal set; }
        
        /// <inheritdoc/>
        public string Description { get; internal set; }

        /// <inheritdoc/>
        public Type Type { get; internal set; }
    }
}