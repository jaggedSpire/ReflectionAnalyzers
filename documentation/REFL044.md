# REFL044
## Expected attribute type.

<!-- start generated table -->
<table>
  <tr>
    <td>CheckId</td>
    <td>REFL044</td>
  </tr>
  <tr>
    <td>Severity</td>
    <td>Warning</td>
  </tr>
  <tr>
    <td>Enabled</td>
    <td>true</td>
  </tr>
  <tr>
    <td>Category</td>
    <td>ReflectionAnalyzers.SystemReflection</td>
  </tr>
  <tr>
    <td>Code</td>
     <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/blob/master/ReflectionAnalyzers/NodeAnalzers/GetCustomAttributeAnalyzer.cs">GetCustomAttributeAnalyzer</a></td>
  </tr>
  <tr>
    <td></td>
     <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/blob/master/ReflectionAnalyzers/NodeAnalzers/IsDefinedAnalyzer.cs">IsDefinedAnalyzer</a></td>
  </tr>
</table>
<!-- end generated table -->

## Description

Expected attribute type.

## Motivation

ADD MOTIVATION HERE

## How to fix violations

ADD HOW TO FIX VIOLATIONS HERE

<!-- start generated config severity -->
## Configure severity

### Via ruleset file.

Configure the severity per project, for more info see [MSDN](https://msdn.microsoft.com/en-us/library/dd264949.aspx).

### Via #pragma directive.
```C#
#pragma warning disable REFL044 // Expected attribute type.
Code violating the rule here
#pragma warning restore REFL044 // Expected attribute type.
```

Or put this at the top of the file to disable all instances.
```C#
#pragma warning disable REFL044 // Expected attribute type.
```

### Via attribute `[SuppressMessage]`.

```C#
[System.Diagnostics.CodeAnalysis.SuppressMessage("ReflectionAnalyzers.SystemReflection", 
    "REFL044:Expected attribute type.", 
    Justification = "Reason...")]
```
<!-- end generated config severity -->