using System.Text;
using zentronC;
class mainClass
{
    public static string output = "";
    public static List<string[]> parsedLines = new List<string[]>();
    Compiler compiler = new Compiler();
    public static Dictionary<string,object> stack = new Dictionary<string,object>();
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide a file to compile and an output executable");
            return;
        }
        mainClass mainClassObj = new mainClass();  
        var lines = File.ReadAllLines(args[0]);
        output = args[1];
        foreach(var line in lines)
        {
            mainClass.parsedLines.Add(mainClassObj.ParseLine(line));
        }
        mainClassObj.run(mainClass.parsedLines);
    }

    public void run(List<string[]> pLines)
    {
       
        Compiler compiler = new Compiler();
        compiler.initCompiler();
        foreach(var line in pLines)
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
            return true;
        }
        else if (statement.Length > 2)
        {
            if (statement[1] == "=")
            {
                return true;
            }
        }
        return false;
    }
    bool isInput(string[] statement)
    {
        if (statement.Length == 2)
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
    public void doLine(string[] parsedLn)
    {
        string cmnd = parsedLn[0];
        string[] args = parsedLn[1..^0];
        if (cmnd.ToLower() == "say")
        {
            compiler.writePrint(parsedLn);
        }
        if(cmnd.ToLower() == "#rule")
        {

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
            compiler.writeIf(parsedLn);
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
            compiler.writeUntilBegin(new string[] {"until","1","=","2"});
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
            compiler.writeIncrementNum(parsedLn);
        }
        else if (cmnd.ToLower() == "decrement")
        {
            compiler.writeDecrementNum(parsedLn);
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