using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using ParseJson.Model;
using System.Linq.Expressions;
using System.Reflection;

namespace ParseJson
{
    public class JsonVisitor : IJSONVisitor<Expression>
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
                return Expression.New(typeof(JValue).GetConstructor(new Type[] { typeof(string) }), Expression.Constant(token.Text.Trim('"')));
            }
            else
            {
                throw new NotSupportedException("");
            }
        }

        public Expression VisitArr([NotNull] JSONParser.ArrContext context)
        {
            var ctor = typeof(JList).GetConstructors()[1];

            var initializers = new List<Expression>();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JSONParser.ValueContext value)
                {
                    var v = VisitValue(value);
                    initializers.Add(v);
                }
            }

            return Expression.New(ctor, Expression.NewArrayInit(typeof(JItem), initializers.ToArray()));
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
            var ctor = typeof(JNode).GetConstructors()[0];
            var ctorTuple = typeof(JNodeKV).GetConstructors()[0];

            var initializers = new List<Expression>();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JSONParser.PairContext pair)
                {
                    var name = Expression.Constant(pair.GetChild(0).GetText().Trim('"'));
                    var value = VisitValue(pair.GetChild(2).Payload as JSONParser.ValueContext);

                    initializers.Add(Expression.New(ctorTuple, name, value));
                }
            }
            return Expression.New(ctor, Expression.NewArrayInit(typeof(JNodeKV), initializers.ToArray()));
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
                var ctor = typeof(JValue).GetConstructors()[0];

                return Expression.New(typeof(JValue).GetConstructor(new Type[] { typeof(string) }), Expression.Constant(token.Text.Trim('"')));
            }
            else
            {
                throw new NotSupportedException("");
            }
        }
    }
}