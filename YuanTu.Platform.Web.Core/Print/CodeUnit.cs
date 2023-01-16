using Abp.UI;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace YuanTu.Platform.Print
{
    public class CodeUnit
    {
        public static bool Excute(string command, Dictionary<string, object> parameters)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace("CodeGenerate");
            unit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration cls = new CodeTypeDeclaration("DynamicClass");
            ns.Types.Add(cls);
            var start = new CodeMemberMethod();
            start.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            start.Name = "Run";
            start.ReturnType = new CodeTypeReference(typeof(bool));

            foreach (var param in parameters)
            {
                if (param.Value == null)
                {
                    start.Statements.Add(new CodeAssignStatement(new CodeParameterDeclarationExpression(typeof(string), param.Key), new CodePrimitiveExpression(param.Value)));
                }
                else
                {
                    start.Statements.Add(new CodeAssignStatement(new CodeParameterDeclarationExpression(param.Value.GetType(), param.Key), new CodePrimitiveExpression(param.Value)));
                }
            }

            start.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(command)));
            cls.Members.Add(start);

            var isNotEmpty = new CodeMemberMethod();
            isNotEmpty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            isNotEmpty.Name = $"IsNotEmpty";
            isNotEmpty.ReturnType = new CodeTypeReference(typeof(bool));
            isNotEmpty.Parameters.Add(new CodeParameterDeclarationExpression(typeof(object), "input"));

            isNotEmpty.Statements.Add(new CodeAssignStatement(new CodeParameterDeclarationExpression(typeof(bool), "trimed"), new CodePrimitiveExpression(true)));

            CodeSnippetStatement snippet = new CodeSnippetStatement("if(input == null) return false; if(trimed) return input.ToString().Trim() != string.Empty; else return input.ToString() != string.Empty;");
            isNotEmpty.Statements.Add(snippet);
            cls.Members.Add(isNotEmpty);

            var provider = CodeDomProvider.CreateProvider("CSharp");

            CodeGeneratorOptions options = new CodeGeneratorOptions();

            options.BracingStyle = "C";

            options.BlankLinesBetweenMembers = true;

            //CompilerResults res = null;

            using (MemoryStream memory = new MemoryStream(1024 * 32))
            {
                using (StreamWriter sw = new StreamWriter(memory))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sw, options);
                    sw.Flush();
                    memory.Position = 0;
                    string text = string.Empty;
                    var p = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var len = memory.Read(buffer, 0, 1024);
                        p += len;
                        text += Encoding.UTF8.GetString(buffer, 0, len);
                        if (len < 1024)
                        {
                            break;
                        }
                    }

                    var ins = new Compiler().Compile(text, typeof(int).Assembly).CreateInstance("CodeGenerate.DynamicClass");
                    
                    return (bool)ins.GetType().GetMethod("Run").Invoke(ins, null);
                }
            }
        }

        public static Result<T> RunScript<T>(string command, Dictionary<string, object> parameters)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace("CodeGenerate");
            unit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration cls = new CodeTypeDeclaration("DynamicClass");
            ns.Types.Add(cls);
            var start = new CodeMemberMethod();
            start.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            start.Name = "Run";
            start.ReturnType = new CodeTypeReference(typeof(T));

            foreach (var param in parameters)
            {
                if (param.Value == null)
                {
                    start.Statements.Add(new CodeAssignStatement(new CodeParameterDeclarationExpression(typeof(string), param.Key), new CodePrimitiveExpression(param.Value)));
                }
                else
                {
                    start.Statements.Add(new CodeAssignStatement(new CodeParameterDeclarationExpression(param.Value.GetType(), param.Key), new CodePrimitiveExpression(param.Value)));
                }
            }

            start.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(command)));
            cls.Members.Add(start);

            var provider = CodeDomProvider.CreateProvider("CSharp");

            CodeGeneratorOptions options = new CodeGeneratorOptions();

            options.BracingStyle = "C";

            options.BlankLinesBetweenMembers = true;

            using (MemoryStream memory = new MemoryStream(1024 * 32))
            {
                using (StreamWriter sw = new StreamWriter(memory))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sw, options);
                    sw.Flush();
                    memory.Position = 0;
                    string text = string.Empty;
                    var p = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var len = memory.Read(buffer, 0, 1024);
                        p += len;
                        text += Encoding.UTF8.GetString(buffer, 0, len);
                        if (len < 1024)
                        {
                            break;
                        }
                    }
                    try
                    {
                        var ins = new Compiler().Compile(text, typeof(int).Assembly).CreateInstance("CodeGenerate.DynamicClass");

                        return Result<T>.Success((T)ins.GetType().GetMethod("Run").Invoke(ins, null));
                    }
                    catch(Exception ex)
                    {
                        throw new UserFriendlyException($"编译失败:\r\n{text}");
                    }
                }
            }
        }

        public static void RunFunc(string function, Dictionary<string, object> parameters)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace("CodeGenerate");
            unit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("Newtonsoft.Json"));
            ns.Imports.Add(new CodeNamespaceImport("Newtonsoft.Json.Linq"));

            CodeTypeDeclaration cls = new CodeTypeDeclaration("DynamicClass");
            ns.Types.Add(cls);
            var start = new CodeMemberMethod();
            start.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            start.Name = "Run";
            start.ReturnType = new CodeTypeReference();

            foreach (var param in parameters)
            {
                if (param.Value == null)
                {
                    start.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), param.Key));
                }
                else
                {
                    start.Parameters.Add(new CodeParameterDeclarationExpression(param.Value.GetType(), param.Key));
                }
            }

            start.Statements.Add(new CodeVariableReferenceExpression(function));
            cls.Members.Add(start);

            var provider = CodeDomProvider.CreateProvider("CSharp");

            CodeGeneratorOptions options = new CodeGeneratorOptions();

            options.BracingStyle = "C";

            options.BlankLinesBetweenMembers = true;

            using (MemoryStream memory = new MemoryStream(1024 * 32))
            {
                using (StreamWriter sw = new StreamWriter(memory))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sw, options);
                    sw.Flush();
                    memory.Position = 0;
                    string text = string.Empty;
                    var p = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var len = memory.Read(buffer, 0, 1024);
                        p += len;
                        text += Encoding.UTF8.GetString(buffer, 0, len);
                        if (len < 1024)
                        {
                            break;
                        }
                    }

                    var ins = new Compiler().Compile(text, typeof(Newtonsoft.Json.Linq.JObject).Assembly).CreateInstance("CodeGenerate.DynamicClass");

                    ins.GetType().GetMethod("Run").Invoke(ins, parameters.Values.Select(v=>v).ToArray());

                }
            }
        }
    }

    public class Compiler
    {
        public Assembly Compile(string text, params Assembly[] referencedAssemblies)
        {
            List<Assembly> asses = new List<Assembly>();
            foreach (var ass in referencedAssemblies)
            {
                GetReferenceAssemblies(ass, asses);
            }

            var references = asses.Where(v=>!string.IsNullOrEmpty(v.Location)).Select(it => MetadataReference.CreateFromFile(it.Location));
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            var assemblyName = "_" + Guid.NewGuid().ToString("D");
            var syntaxTrees = new SyntaxTree[] { CSharpSyntaxTree.ParseText(text) };
            var compilation = CSharpCompilation.Create(assemblyName, syntaxTrees, references, options);
            
            using (var stream = new MemoryStream())
            {
                var compilationResult = compilation.Emit(stream);

                GC.Collect();

                if (compilationResult.Success)
                {
                    stream.Seek(0, SeekOrigin.Begin);

                    return Assembly.Load(stream.ToArray());
                }

                return null;
            }
        }

        protected void GetReferenceAssemblies(Assembly assembly, List<Assembly> referencedAssemblies)
        {
            if (referencedAssemblies.Exists(v => v.FullName == assembly.FullName))
            {
                return;
            }

            referencedAssemblies.Add(assembly);

            var dd = assembly.GetReferencedAssemblies();

            foreach (var assn in dd)
            {
                var ass = Assembly.Load(assn.FullName);

                if (referencedAssemblies.Exists(v => v.FullName == ass.FullName))
                {
                    continue;
                }

                GetReferenceAssemblies(ass, referencedAssemblies);
            }

            return;
        }
    }
}

