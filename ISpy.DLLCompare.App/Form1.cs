using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ICSharpCode.Decompiler.Ast;
using Microsoft.CSharp;
using Mono.Cecil;
using ICSharpCode.Decompiler;
using System.Diagnostics;
using System.IO;



namespace ISpy.DLLCompare.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFile1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFile1.Text = openFileDialog1.FileName;
            }
        }

        private void btnFile2_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFile2.Text = openFileDialog1.FileName;
            }
        }
        public static void GenerateCode(string sourcefileName, string targetName)
        {
            string workdir = Environment.CurrentDirectory;

            FileInfo sourceFileInfo = new FileInfo(sourcefileName);


            Environment.CurrentDirectory = sourceFileInfo.DirectoryName;
            var assembly = AssemblyDefinition
                .ReadAssembly(sourceFileInfo.Name);
            AstBuilder decompiler = new AstBuilder(new DecompilerContext(assembly.MainModule));

            decompiler.AddAssembly(assembly);
            new ICSharpCode.Decompiler.Tests.Helpers.RemoveCompilerAttribute().Run(decompiler.SyntaxTree);
            StringBuilder sb = new StringBuilder();
            StringWriter output = new StringWriter(sb);
            decompiler.GenerateCode(new PlainTextOutput(output));

            Environment.CurrentDirectory = workdir;


            File.AppendAllText(targetName, sb.ToString());


        }



        public static void GenerateCodeSplit(string sourcefileName, string targetDir)
        {
            string workdir = Environment.CurrentDirectory;

            FileInfo sourceFileInfo = new FileInfo(sourcefileName);
            Environment.CurrentDirectory = sourceFileInfo.DirectoryName;


            var assembly = AssemblyDefinition
                .ReadAssembly(sourceFileInfo.Name);
        
            foreach (var item in assembly.MainModule.Types)
            {
                if (item.FullName.StartsWith("<"))
                {
                    continue;
                }
                AstBuilder decompiler = new AstBuilder(new DecompilerContext(assembly.MainModule) { CurrentType = item});
                decompiler.AddType(item);
                new ICSharpCode.Decompiler.Tests.Helpers.RemoveCompilerAttribute().Run(decompiler.SyntaxTree);
                StringBuilder sb = new StringBuilder();
                StringWriter output = new StringWriter(sb);
                decompiler.GenerateCode(new PlainTextOutput(output));
                Environment.CurrentDirectory = workdir;
                File.AppendAllText(Path.Combine(targetDir,item.FullName+".cs"), sb.ToString());
 
            }
            


        }

        
        private void btnCompare_Click(object sender, EventArgs e)
        {
            
            string file1 = txtFile1.Text;
            string file2 = txtFile2.Text;

            string file1DirName=Guid.NewGuid().ToString("n")+"";
            string file2DirName = Guid.NewGuid().ToString("n") + "";

            Directory.CreateDirectory(file1DirName);
            Directory.CreateDirectory(file2DirName);

            GenerateCodeSplit(file1, file1DirName);
            GenerateCodeSplit(file2, file2DirName);

            string argsTemplate = "{0} {1} /dl \"{2}\" /dr \"{3}\"";
            string args = string.Format(argsTemplate, file1DirName, file2DirName, file1, file2);
            Process process = Process.Start(
               diffApp,
               args);
            process.WaitForExit();


            try
            {
                Directory.Delete(file1DirName,true);
                Directory.Delete(file2DirName,true);
            }
            catch
            {
 
            }
           

            
        }

        private void btnCompare2_Click(object sender, EventArgs e)
        {

            string file1 = txtFile1.Text;
            string file2 = txtFile2.Text;

            string file1TargetName = Guid.NewGuid().ToString("n") + ".cs";
            string file2TargetName = Guid.NewGuid().ToString("n") + ".cs";
            GenerateCode(file1, file1TargetName);
            GenerateCode(file2, file2TargetName);

            string argsTemplate = "{0} {1} /dl \"{2}\" /dr \"{3}\"";
            string args = string.Format(argsTemplate, file1TargetName, file2TargetName, file1, file2);
            Process process = Process.Start(
               diffApp,
               args);
            process.WaitForExit();

            try
            {
                File.Delete(file1TargetName);
                File.Delete(file2TargetName);
            }
            catch
            {

            }




        }


        public string diffApp = "C:\\Program Files (x86)\\WinMerge\\WinMergeU.exe";
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Program Files (x86)\\WinMerge\\WinMergeU.exe"))
            {
                Process.Start("WinMerge-2.14.0-Setup.exe").WaitForExit();
               
            }
            
        }

        
    }
}
