using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Linq.Expressions;
using System.Reflection;

namespace ParseJson
{
    public class ExpressionVisitor : IJSONVisitor<Expression>
    {
        public Expression Visit(IParseTree tree)
        {
            if (tree.Payload is JSONParser.ArrContext arr)
            {
                return VisitArr(arr);
            }
            else if (tree.Payload is JSONParser.JsonContext json)
            {
                return VisitJson(json);
            }
            else if (tree.Payload is JSONParser.ObjContext obj)
            {
                return VisitObj(obj);
            }
            else if (tree.Payload is JSONParser.PairContext pair)
            {
                return VisitPair(pair);
            }
            else if (tree.Payload is JSONParser.ValueContext value)
            {
                return VisitValue(value);
            }
            else if (tree.Payload is CommonToken token)
            {
                return Expression.Constant(token.Text.Trim('"'));
            }
            else
            {
                throw new NotSupportedException("");
            }
        }

        public Expression VisitArr([NotNull] JSONParser.ArrContext context)
        {
            var list = new List<Expression>();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JSONParser.ValueContext value)
                {
                    var v = VisitValue(value);
                    list.Add(v);
                }
            }
            return Expression.NewArrayInit(typeof(Expression), list);
        }

        public Expression VisitChildren(IRuleNode node)
        {
            throw new NotImplementedException();
        }

        public Expression VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException();
        }

        public Expression VisitJson([NotNull] JSONParser.JsonContext context)
        {
            return VisitValue(context.value());
        }

        public Expression VisitObj([NotNull] JSONParser.ObjContext context)
        {
            var createdType = typeof(Dictionary<string, object>);
            var addMethod = createdType.GetMethod("Add");

            var initializers = new List<ElementInit>();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JSONParser.PairContext pair)
                {
                    var name = Expression.Constant(pair.GetChild(0).GetText().Trim('"'));
                    var value = VisitValue(pair.GetChild(2).Payload as JSONParser.ValueContext);

                    var elementInit = Expression.ElementInit(addMethod, name, value);

                    initializers.Add(elementInit);
                }
            }
            return Expression.ListInit(Expression.New(createdType), initializers.ToArray());
        }

        public Expression VisitPair([NotNull] JSONParser.PairContext context)
        {
            throw new NotImplementedException();
        }

        public Expression VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException();
        }

        public Expression VisitValue([NotNull] JSONParser.ValueContext context)
        {
            var target = context.GetChild(0);
            if (target.Payload is JSONParser.ArrContext arr)
            {
                return VisitArr(arr);
            }
            else if (target.Payload is JSONParser.JsonContext json)
            {
                return VisitJson(json);
            }
            else if (target.Payload is JSONParser.ObjContext obj)
            {
                return VisitObj(obj);
            }
            else if (target.Payload is JSONParser.PairContext pair)
            {
                return VisitPair(pair);
            }
            else if (target.Payload is JSONParser.ValueContext value)
            {
                return VisitValue(value);
            }
            else if (target.Payload is CommonToken token)
            {
                return Expression.Constant(token.Text.Trim('"'));
            }
            else
            {
                throw new NotSupportedException("");
            }
        }
    }
}