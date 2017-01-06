using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using ICSharpCode.Decompiler.Ast;
using Microsoft.CSharp;
using Mono.Cecil;
using ICSharpCode.Decompiler;
using System.Diagnostics;

namespace ISpy.DLLCompare
{
    class Program
    {
        public static void GenerateCode(string dir, string dllname, string targetDir, string targetName)
        {
            Environment.CurrentDirectory = dir;
            var assembly = AssemblyDefinition
                .ReadAssembly(dllname);
            AstBuilder decompiler = new AstBuilder(new DecompilerContext(assembly.MainModule));

            decompiler.AddAssembly(assembly);
            new ICSharpCode.Decompiler.Tests.Helpers.RemoveCompilerAttribute().Run(decompiler.SyntaxTree);
            StringBuilder sb = new StringBuilder();
            StringWriter output = new StringWriter(sb);
            decompiler.GenerateCode(new PlainTextOutput(output));

            File.AppendAllText(Path.Combine(targetDir , targetName ), sb.ToString());
        }
        static void Main(string[] args)
        {

            
            GenerateCode(@"C:\Users\user\Desktop\SMS\Message.SMS.WinService", "CMPP2Lib.dll", @"C:\Users\user\Desktop\SMS", "CMPP2Lib1.cs");
            GenerateCode(@"C:\Users\user\Desktop\SMS2\Message.SMS.WinService\bin\Debug", "CMPP2Lib.dll", @"C:\Users\user\Desktop\SMS", "CMPP2Lib2.cs");
            Environment.CurrentDirectory = @"C:\Users\user\Desktop\SMS";
            Process process = Process.Start(@"C:\Program Files (x86)\WinMerge\WinMergeU.exe", "CMPP2Lib1.cs CMPP2Lib2.cs /dl VersionProduct /dr VersionDev");
            process.WaitForExit();

        }
    }
}
