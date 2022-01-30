using Antlr4.Runtime;
using ParseJson;

var text = File.ReadAllText("example1.json");

var inputStream = new AntlrInputStream(text);
var lexer = new JSONLexer(inputStream);
var commonTokenStream = new CommonTokenStream(lexer);
var parser = new JSONParser(commonTokenStream);

var context = parser.json();
//var expressionVisitor = new ExpressionVisitor();
//var exp = expressionVisitor.Visit(context);

var jnodeVisitor = new JNodeVisitor();
var jnode = jnodeVisitor.Visit(context);


//Console.WriteLine(exp.ToString());

Console.ReadLine();

new JNode() {
    ["glossary"]=(JValue)""
};
