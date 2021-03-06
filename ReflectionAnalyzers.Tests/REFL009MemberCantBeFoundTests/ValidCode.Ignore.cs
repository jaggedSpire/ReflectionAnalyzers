namespace ReflectionAnalyzers.Tests.REFL009MemberCantBeFoundTests
{
    using Gu.Roslyn.Asserts;
    using NUnit.Framework;

    public partial class ValidCode
    {
        public class Ignore
        {
            [TestCase("GetNestedType(\"Generic\", BindingFlags.Public)")]
            [TestCase("GetNestedType(nameof(Generic<int>), BindingFlags.Public)")]
            [TestCase("GetNestedType(\"Generic`2\", BindingFlags.Public)")]
            public void GetNestedType(string call)
            {
                var code = @"
namespace RoslynSandbox
{
    using System.Reflection;

    class C
    {
        public C()
        {
            var methodInfo = typeof(C).GetNestedType(nameof(Generic<int>), BindingFlags.Public);
        }

        public class Generic<T>
        {
        }
    }
}".AssertReplace("GetNestedType(nameof(Generic<int>), BindingFlags.Public)", call);
                AnalyzerAssert.Valid(Analyzer, Descriptor, code);
            }

            [Test]
            public void GetPropertyAnonymousType()
            {
                var code = @"
namespace RoslynSandbox
{
    class C
    {
        public C()
        {
            var anon = new { C = 1 };
            var member = anon.GetType().GetProperty(""MISSING"");
        }
    }
}";
                AnalyzerAssert.Valid(Analyzer, Descriptor, code);
            }

            [TestCase("typeof(string).GetMethod(\"MISSING\")")]
            [TestCase("typeof(string).GetMethod(\"MISSING\", BindingFlags.Public | BindingFlags.Instance)")]
            [TestCase("typeof(string).GetMethod(\"MISSING\", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)")]
            [TestCase("typeof(string).GetMethod(\"MISSING\", BindingFlags.Public | BindingFlags.Static)")]
            [TestCase("typeof(string).GetMethod(\"MISSING\", BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)")]
            public void MissingMethodNotInSource(string type)
            {
                var code = @"
namespace RoslynSandbox
{
    using System.Reflection;

    class C
    {
        public C()
        {
            var methodInfo = typeof(string).GetMethod(""MISSING"");
        }
    }
}".AssertReplace("typeof(string).GetMethod(\"MISSING\")", type);
                AnalyzerAssert.Valid(Analyzer, Descriptor, code);
            }
        }
    }
}
