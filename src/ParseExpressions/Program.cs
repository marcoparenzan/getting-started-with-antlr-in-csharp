using Antlr4.Runtime;
using ParseExpressions;

var text = File.ReadAllText("example1.exp");
                
var inputStream = new AntlrInputStream(text);
var lexer = new ExpressionsLexer(inputStream);
var commonTokenStream = new CommonTokenStream(lexer);
var parser = new ExpressionsParser(commonTokenStream);

var context = parser.expression();

var ctx = new ExpressionsContext();

var visitor = new ExpressionsVisitor<ExpressionsContext>(ctx);
var exp = visitor.Visit(context);

Console.WriteLine(exp.ToString());

Console.ReadLine();
