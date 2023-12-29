using System.Text;
using zentronC.src;

class mainClass
{
    public static string output = "";
    public static List<string[]> parsedLines = new List<string[]>();
    Compiler compiler = new Compiler();
    public static List<string> createdVars = new List<string>();
    static void Main(string[] args)
    {
        bool isCpp = false;
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide a file to compile and an output executable");
            return;
        }
        mainClass mainClassObj = new mainClass();  
        var lines = File.ReadAllLines(args[0]);
        output = args[1];
        mainClassObj.run(lines);
    }

    public void run(string[] lines)
    {
        bool iscpp = false;
        compiler.initCompiler();
        foreach(var line in lines)
        {
            if(line.Trim().ToLower() == "cpp")
            {
                iscpp = true;
                continue;
            }
            else if(line.Trim().ToLower() == "cppend")
            {
                iscpp = false;
                continue;
            }
            if(iscpp)
            {
                File.AppendAllText("tmp.cpp",line+"\n");
            }
            else
            {
                mainClass.parsedLines.Add(ParseLine(line));
            }
        }
        foreach(var line in parsedLines)
        {
            doLine(line);
        }
        compiler.closeCompiler();
        compiler.Compile(output);

    }
    bool isDef(string[] statement)
    {
        if (statement[0].EndsWith(";"))
        {
            createdVars.Add(statement[0]);
            return true;
        }
        else if (statement.Length > 2)
        {
            if (statement[1] == "is")
            {
                createdVars.Add(statement[0]);
                return true;
            }
        }
        return false;
    }
    bool isInput(string[] statement)
    {
        if (statement.Length == 3)
        {
            if (statement[0] == "input" && statement[1] == "->")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else { return false; }
    }

    bool isArithemic(string[] statement,string type)
    {
        if (statement.Length == 5)
        {
            if (statement[0] == type && statement[3] == "->")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else { return false; }
    }
    public void doLine(string[] parsedLn)
    {
        string cmnd = parsedLn[0];
        string[] args = parsedLn[1..^0];
        if (cmnd.ToLower() == "say")
        {
            compiler.writePrint(parsedLn);
        }
        else if(cmnd.ToLower() == "say_fmt")
        {
            compiler.writeFmt(parsedLn);
        }
        else if(cmnd.ToLower() == "#rule")
        {
            compiler.writeRule(parsedLn);
        }
        else if (cmnd.ToLower() == "until")
        {
            compiler.writeUntilBegin(parsedLn);
        }
        else if (isDef(parsedLn))
        {
            compiler.writeDef(parsedLn);
        }
        else if (isInput(parsedLn))
        {
            compiler.writeIn(parsedLn);
        }
        else if (cmnd.ToLower() == "mark")
        {
            compiler.writePoint(parsedLn);
        }
        else if (cmnd.ToLower() == "jumptomark")
        {
            compiler.writeGo(parsedLn);
        }
        else if (cmnd.ToLower() == "if")
        {
            compiler.writeIf(parsedLn,false);
        }
        else if (cmnd.ToLower() == "elif")
        {
            compiler.writeIf(parsedLn, true);
        }
        else if (cmnd.ToLower() == "end")
        {
            compiler.writeEnd(parsedLn);
        }
        else if (cmnd.ToLower() == "continue")
        {
            compiler.writeContinue();
        }
        else if (cmnd.ToLower() == "break")
        {
            compiler.writeBreak();
        }
        else if (cmnd.ToLower() == "loop")
        {
            compiler.writeLoop();
        }
        else if (cmnd.ToLower() == "exit")
        {
            compiler.writeReturnProg();
        }
        else if (cmnd.ToLower() == "else")
        {
            compiler.writeElseBegin();
        }
        else if (cmnd.ToLower() == "waitseconds")
        {
            compiler.writeSleep(parsedLn);
        }
        else if (cmnd.ToLower() == "sayemptyline")
        {
            compiler.writeSayEmptyLine();
        }
        else if (cmnd.ToLower() == "increment")
        {
            compiler.writeIncDecNum(parsedLn, true);
        }
        else if (cmnd.ToLower() == "decrement")
        {
            compiler.writeIncDecNum(parsedLn,false);
        }
        else if (isArithemic(parsedLn,"add"))
        {
            compiler.writeArithemic(parsedLn,"+");
        }
        else if (isArithemic(parsedLn, "subtract"))
        {
            compiler.writeArithemic(parsedLn, "-");
        }
        else if (isArithemic(parsedLn, "multiply"))
        {
            compiler.writeArithemic(parsedLn, "*");
        }
        else if (isArithemic(parsedLn, "divide"))
        {
            compiler.writeArithemic(parsedLn, "/");
        }
        else if (cmnd.StartsWith("//"))
        {
            return;
        }
        else if (String.IsNullOrEmpty(cmnd))
        {
            return;
        }
        else
        {
            throw new Exception($"Invalid operation: {cmnd}");
        }

    }
    public string[] ParseLine(string line)
    {

        string[] parsedLine = SplitWithEscape(line.Trim());
        return parsedLine;
    }
    public string[] SplitWithEscape(string toSplit)
    {
        bool isEscaping = false;
        List<StringBuilder> splitOutputBuilder = new List<StringBuilder>();
        splitOutputBuilder.Add(new StringBuilder());
        List<string> splitOutput = new List<string>();

        foreach (char chr in toSplit)
        {
            if (chr == '\"')
            {
                isEscaping = !isEscaping;
            }
            else if (chr == ' ' && !isEscaping)
            {
                splitOutputBuilder.Add(new StringBuilder());
            }
            else
            {
                splitOutputBuilder.Last().Append(chr);
            }
        }

        foreach (StringBuilder output in splitOutputBuilder)
        {
            splitOutput.Add(output.ToString());
        }

        return splitOutput.ToArray();
    }
}