using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Data.Access.Source
{
    //need to create a creational pattern because entity framework is not thread safe
    internal interface IGenerateContext
    {
        TuiContext GenerateContext();
        TuiContext GenerateContext(String connectionString);
    }
}
