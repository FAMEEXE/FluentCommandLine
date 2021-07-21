using System.Collections.Generic;
using System.Threading.Tasks;

namespace REFame.CommandLine.Contracts
{
    public interface ICommandLine
    {
        /// <summary>
        /// All command of the command-line interface
        /// </summary>
        public IEnumerable<ICommand> Commands { get; }

        /// <summary>
        /// Run the command-line with all its commands
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<int> Run(string[] args);
    }
}