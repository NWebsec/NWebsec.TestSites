// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System.Configuration;
using NUnit.Framework;

namespace NWebsec.Tests.Integration
{
    [TestFixture]
    public class Mvc6Tests : MvcTestsBase
    {
        protected override string BaseUri => ConfigurationManager.AppSettings["Mvc6BaseUri"];
    }
}