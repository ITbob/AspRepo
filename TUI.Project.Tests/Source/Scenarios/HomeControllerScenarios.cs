using LightBDD.Framework;
using LightBDD.Framework.Scenarios.Extended;
using LightBDD.NUnit2;
using NUnit.Framework;
using System;
using System.Configuration;
using TUI.Data.Access.Source;

namespace TUI.Project.Tests.Source.Scenarios
{
    partial class HomeControllerFeatures 
    {
        private String _connection;

        [SetUp]
        public void SetUp()
        {
            _connection = ConfigurationManager.ConnectionStrings["TUITest"].ToString();
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
            TuiDataHelper.CleanAll(this._connection);
        }

        [Test]
        [Scenario]
        [Label("Add added city from details page")]
        public void Check_added_city_from_details_page()
        {
            Runner.RunScenario();
        }
    }
}
