namespace ReflectionAnalyzers.Tests.REFL025ArgumentsDontMatchParametersTests
{
    using Gu.Roslyn.Asserts;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using NUnit.Framework;

    public partial class ValidCode
    {
        public class MethodInfoInvoke
        {
            private static readonly DiagnosticAnalyzer Analyzer = new InvokeAnalyzer();
            private static readonly DiagnosticDescriptor Descriptor = REFL025ArgumentsDontMatchParameters.Descriptor;

            [Test]
            public void SingleIntParameter()
            {
                var code = @"
namespace RoslynSandbox
{
    public class C
    {
        public C()
        {
            var value = (int)typeof(C).GetMethod(nameof(M)).Invoke(null, new object[] { 1 });
        }

        public static int M(int value) => value;
    }
}";

                AnalyzerAssert.Valid(Analyzer, Descriptor, code);
            }

            [TestCase("Invoke(null, null)")]
            [TestCase("Invoke(null, new object[0])")]
            [TestCase("Invoke(null, new object[0] { })")]
            [TestCase("Invoke(null, Array.Empty<object>())")]
            public void NoParameter(string call)
            {
                var code = @"
namespace RoslynSandbox
{
    using System;

    public class C
    {
        public static object Get => typeof(C).GetMethod(nameof(M)).Invoke(null, null);

        public static int M() => 1;
    }
}".AssertReplace("Invoke(null, null)", call);

                AnalyzerAssert.Valid(Analyzer, Descriptor, code);
            }

            [TestCase("1")]
            [TestCase("Missing.Value")]
            public void OptionalParameter(string value)
            {
                var code = @"
namespace RoslynSandbox
{
    using System.Reflection;

    public class C
    {
        public static int Get => (int)typeof(C).GetMethod(nameof(M)).Invoke(null, new object[] { Missing.Value });

        public static int M(int value = 1) => value;
    }
}".AssertReplace("Missing.Value", value);

                AnalyzerAssert.Valid(Analyzer, Descriptor, code);
            }
        }
    }
}
