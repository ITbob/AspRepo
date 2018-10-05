

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Data.Access.Source.Factory;
using TUI.Places.Source;
using TUI.Transportations.Air;
using System.Data.Entity;
using TUI.Transportations.Air.Source;
using InteractivePreGeneratedViews;
using System.Web;
using System.Diagnostics;

namespace TUI.Data.Access.Source
{
    public static class TuiDataHelper
    {
        private static IGenerateContext _generator = new ContextGenerator();

        public static void Delete()
        {
            using (var context = _generator.GenerateContext())
            {
                context.Database.Delete();
            }
        }

        public static void SetCache(String cachePath)
        {
            using (var ctx = new TuiContext())
            {
                try
                {
                    InteractiveViews
                        .SetViewCacheFactory(
                            ctx,
                            new SqlServerViewCacheFactory(ctx.Database.Connection.ConnectionString));
                }
                catch (Exception)
                {
                    Debug.WriteLine("not available");
                }

            }
        }

        public static void Initialize()
        {
            using (var context = _generator.GenerateContext())
            {
                context.Database.Initialize(true);
            }
        }

        public static void CleanAll(String connectionString)
        {
            using (var context = _generator.GenerateContext(connectionString))
            {
                context.Database.Delete();
            }
        }

    }
}
