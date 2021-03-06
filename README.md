# ReflectionAnalyzers
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build status](https://ci.appveyor.com/api/projects/status/5apvp4qa64q3tyi8/branch/master?svg=true)](https://ci.appveyor.com/project/JohanLarsson/reflectionanalyzers/branch/master)
[![NuGet](https://img.shields.io/nuget/v/ReflectionAnalyzers.svg)](https://www.nuget.org/packages/ReflectionAnalyzers/)
[![Join the chat at https://gitter.im/DotNetAnalyzers/ReflectionAnalyzers](https://badges.gitter.im/DotNetAnalyzers/ReflectionAnalyzers.svg)](https://gitter.im/DotNetAnalyzers/ReflectionAnalyzers?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Analyzers checking System.Reflection

<!-- start generated table -->
<table>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL001.md">REFL001</a></td>
    <td>Cast return value to the correct type.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL002.md">REFL002</a></td>
    <td>Discard the return value.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL003.md">REFL003</a></td>
    <td>The member does not exist.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL004.md">REFL004</a></td>
    <td>More than one member is matching the criteria.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL005.md">REFL005</a></td>
    <td>There is no member matching the filter.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL006.md">REFL006</a></td>
    <td>The binding flags can be more precise.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL007.md">REFL007</a></td>
    <td>The binding flags are not in the expected order.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL008.md">REFL008</a></td>
    <td>Specify binding flags for better performance and less fragile code.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL009.md">REFL009</a></td>
    <td>The referenced member is not known to exist.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL010.md">REFL010</a></td>
    <td>Prefer the generic extension method GetCustomAttribute<T>.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL011.md">REFL011</a></td>
    <td>Duplicate BindingFlag.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL012.md">REFL012</a></td>
    <td>Prefer Attribute.IsDefined().</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL013.md">REFL013</a></td>
    <td>The member is of the wrong type.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL014.md">REFL014</a></td>
    <td>Prefer GetMember().AccessorMethod.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL015.md">REFL015</a></td>
    <td>Use the containing type.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL016.md">REFL016</a></td>
    <td>Use nameof.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL017.md">REFL017</a></td>
    <td>Don't use name of wrong member.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL018.md">REFL018</a></td>
    <td>The member is explicitly implemented.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL019.md">REFL019</a></td>
    <td>No member matches the types.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL020.md">REFL020</a></td>
    <td>More than one interface is matching the name.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL022.md">REFL022</a></td>
    <td>Use fully qualified name.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL023.md">REFL023</a></td>
    <td>The type does not implement the interface.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL024.md">REFL024</a></td>
    <td>Prefer null over empty array.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL025.md">REFL025</a></td>
    <td>Use correct arguments.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL026.md">REFL026</a></td>
    <td>No parameterless constructor defined for this object.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL027.md">REFL027</a></td>
    <td>Prefer Type.EmptyTypes.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL028.md">REFL028</a></td>
    <td>Cast return value to correct type.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL029.md">REFL029</a></td>
    <td>Specify types in case an overload is added in the future.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL030.md">REFL030</a></td>
    <td>Use correct obj parameter.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL031.md">REFL031</a></td>
    <td>Use generic arguments that satisfies the type parameters.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL032.md">REFL032</a></td>
    <td>The dependency does not exist.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL033.md">REFL033</a></td>
    <td>Use the same type as the parameter.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL034.md">REFL034</a></td>
    <td>Don't call MakeGeneric when not a generic definition.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL035.md">REFL035</a></td>
    <td>Don't call Invoke on a generic definition.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL036.md">REFL036</a></td>
    <td>Pass 'throwOnError: true' or check if null.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL037.md">REFL037</a></td>
    <td>The type does not exist.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL038.md">REFL038</a></td>
    <td>Prefer RuntimeHelpers.RunClassConstructor.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL039.md">REFL039</a></td>
    <td>Prefer typeof(...) over instance.GetType when the type is sealed.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL040.md">REFL040</a></td>
    <td>Prefer type.IsInstanceOfType(...).</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL041.md">REFL041</a></td>
    <td>Delegate type is not matching.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL042.md">REFL042</a></td>
    <td>First argument must be reference type.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL043.md">REFL043</a></td>
    <td>First argument must match type.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL044.md">REFL044</a></td>
    <td>Expected attribute type.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL045.md">REFL045</a></td>
    <td>These flags are insufficient to match any members.</td>
  </tr>
  <tr>
    <td><a href="https://github.com/DotNetAnalyzers/ReflectionAnalyzers/tree/master/documentation/REFL046.md">REFL046</a></td>
    <td>The specified default member does not exist.</td>
  </tr>
<table>
<!-- end generated table -->
