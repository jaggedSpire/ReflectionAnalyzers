namespace ReflectionAnalyzers.Tests.REFL043FirstArgumentTypeTests
{
    using Gu.Roslyn.Asserts;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using NUnit.Framework;

    public class ValidCode
    {
        private static readonly DiagnosticAnalyzer Analyzer = new CreateDelegateAnalyzer();
        private static readonly DiagnosticDescriptor Descriptor = REFL043FirstArgumentType.Descriptor;

        [TestCase("null")]
        [TestCase("string.Empty")]
        public void StaticStringIntWithFirstArg(string text)
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public static int M(string arg) => arg.Length;

        public static object Get => Delegate.CreateDelegate(
            typeof(Func<int>),
            string.Empty,
            typeof(C).GetMethod(nameof(M)));
    }
}".AssertReplace("string.Empty", text);
            AnalyzerAssert.Valid(Analyzer, code);
        }

        [Test]
        public void StaticStringVoidFirstArg()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public static void M(string arg) { }

        public static object Get => Delegate.CreateDelegate(
            typeof(Action),
            string.Empty,
            typeof(C).GetMethod(nameof(M)));
    }
}";

            AnalyzerAssert.Valid(Analyzer, code);
        }

        [TestCase("1")]
        [TestCase("null")]
        [TestCase("\"abc\"")]
        public void StaticObjectVoidFirstArg(string arg)
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public static void M(object arg) { }

        public static object Get => Delegate.CreateDelegate(
            typeof(Action),
            1,
            typeof(C).GetMethod(nameof(M)));
    }
}".AssertReplace("1", arg);

            AnalyzerAssert.Valid(Analyzer, code);
        }

        [Test]
        public void StaticStringStringVoidFirstArg()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public static void M(string arg1, string arg2) { }

        public static object Get => Delegate.CreateDelegate(
            typeof(Action<string>),
            string.Empty,
            typeof(C).GetMethod(nameof(M)));
    }
}";

            AnalyzerAssert.Valid(Analyzer, code);
        }

        [Test]
        public void CreateDelegateParameterExpressionMake()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    class C
    {

        public static object Get => Delegate.CreateDelegate(
            typeof(Func<Type, string, bool, ParameterExpression>),
            typeof(ParameterExpression).GetMethod(""Make"", BindingFlags.Static | BindingFlags.NonPublic));
    }
}";
            AnalyzerAssert.Valid(Analyzer, Descriptor, code);
        }

        [Test]
        public void StaticStringInt()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public static int M(string arg) => arg.Length;

        public static object Get => Delegate.CreateDelegate(
            typeof(Func<string, int>),
            typeof(C).GetMethod(nameof(M)));
    }
}";
            AnalyzerAssert.Valid(Analyzer, code);
        }

        [Test]
        public void StaticVoid()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public static void M() { }

        public static object Get => Delegate.CreateDelegate(
            typeof(Action),
            typeof(C).GetMethod(nameof(M)));
    }
}";
            AnalyzerAssert.Valid(Analyzer, code);
        }

        [Test]
        public void StaticStringVoid()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public static void M(string arg) { }

        public static object Get => Delegate.CreateDelegate(
            typeof(Action<string>),
            typeof(C).GetMethod(nameof(M)));
    }
}";

            AnalyzerAssert.Valid(Analyzer, code);
        }

        [Test]
        public void InstanceStringInt()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public int M(string arg) => arg.Length;

        public static object Get => Delegate.CreateDelegate(
            typeof(Func<C, string, int>),
            typeof(C).GetMethod(nameof(M)));
    }
}";
            AnalyzerAssert.Valid(Analyzer, code);
        }

        [Test]
        public void InstanceStringIntWithTarget()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        public int M(string arg) => arg.Length;

        public static object Get => Delegate.CreateDelegate(
            typeof(Func<string, int>),
            new C(),
            typeof(C).GetMethod(nameof(M)));
    }
}";
            AnalyzerAssert.Valid(Analyzer, code);
        }

        [Test]
        public void StaticStringIntCustomDelegate()
        {
            var code = @"
namespace RoslynSandbox
{
    using System;
    using System.Reflection;

    class C
    {
        delegate int StringInt(string text);

        public static int M(string arg) => arg.Length;

        public static object Get => Delegate.CreateDelegate(
            typeof(StringInt),
            typeof(C).GetMethod(nameof(M)));
    }
}";
            AnalyzerAssert.Valid(Analyzer, code);
        }
    }
}
