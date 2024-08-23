using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace SimpleFuzzy.Abstract
{
    public interface ICompileService
    {
        public static void Compile(string exeCode, string savePath) { }
    }
}
