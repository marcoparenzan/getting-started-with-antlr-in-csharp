using Antlr4.Runtime;
using ParseJson;

var text = File.ReadAllText("example1.json");
                
var inputStream = new AntlrInputStream(text);
var lexer = new JSONLexer(inputStream);
var commonTokenStream = new CommonTokenStream(lexer);
var parser = new JSONParser(commonTokenStream);

var context = parser.json();                
var visitor = new BasicVisitor();
var result = visitor.Visit(context) as Dictionary<string, object>;

Console.ReadLine();
