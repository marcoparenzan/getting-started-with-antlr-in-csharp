using Antlr4.Runtime;
using ParseExpressions;

var logger = new Logger();

var text = File.ReadAllText("example1.exp");
                
var inputStream = new AntlrInputStream(text);
var lexer = new ExpressionsLexer(inputStream);
var commonTokenStream = new CommonTokenStream(lexer);
var parser = new ExpressionsParser(commonTokenStream);
parser.AddErrorListener(logger);

var context = parser.expression();

var ctx = new ExpressionContext();

var visitor = new ExpressionsVisitor<ExpressionContext>(ctx);
var exp = visitor.Visit(context);

Console.WriteLine(exp.ToString());

Console.ReadLine();
