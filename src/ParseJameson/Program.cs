using Antlr4.Runtime;
using ParseJameson;

var text = File.ReadAllText("example1.jmsn");
                
var inputStream = new AntlrInputStream(text);
var lexer = new JamesonLexer(inputStream);
var commonTokenStream = new CommonTokenStream(lexer);
var parser = new JamesonParser(commonTokenStream);

var context = parser.expression();

var ctx = new JamesonContext();

var visitor = new JamesonVisitor<JamesonContext>(ctx);
var exp = visitor.Visit(context);

Console.WriteLine(exp.ToString());

Console.ReadLine();
