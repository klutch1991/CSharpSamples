using System;
using System.Runtime.CompilerServices;

namespace _009_InfoAttributes
{
	class Program
	{
		static void Main() => Foo(); // eg Foo("Main", ".../Pogram.cs", 8)

		static void Foo(
			[CallerMemberName] string memberName = null,
			[CallerFilePath] string callerFilePath = null,
			[CallerLineNumber] int lineNumber = 0)
		{
			Console.WriteLine(memberName); // Main
			Console.WriteLine(callerFilePath); // ".../Pogram.cs"
			Console.WriteLine(lineNumber); // 8
		}
	}
}
