using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Data.Access.Source.Factory
{
    internal class ContextGenerator : IGenerateContext
    {
        public TuiContext GenerateContext()
        {
            return new TuiContext();
        }

        public TuiContext GenerateContext(String connectionString)
        {
            return new TuiContext(connectionString);
        }
    }
}
