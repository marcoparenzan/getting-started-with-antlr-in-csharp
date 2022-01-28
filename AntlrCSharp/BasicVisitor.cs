using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace ParseJson
{
    public class BasicVisitor : IJSONVisitor<object>
    {
        public object Visit(IParseTree tree)
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
                return token.Text.Trim('"');
            }
            else
            {
                throw new NotSupportedException("");
            }
        }

        public object VisitArr([NotNull] JSONParser.ArrContext context)
        {
            var list = new List<object>();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JSONParser.ValueContext value)
                {
                    var v = VisitValue(value);
                    list.Add(v);
                }
            }
            return list;
        }

        public object VisitChildren(IRuleNode node)
        {
            throw new NotImplementedException();
        }

        public object VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException();
        }

        public object VisitJson([NotNull] JSONParser.JsonContext context)
        {
            return VisitValue(context.value());
        }

        public object VisitObj([NotNull] JSONParser.ObjContext context)
        {
            var dict = new Dictionary<string, object>();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JSONParser.PairContext pair)
                {
                    var (name, value) = ((string, object)) VisitPair(pair);
                    dict[name] = value;
                }
            }
            return dict;
        }

        public object VisitPair([NotNull] JSONParser.PairContext context)
        {
            var name = context.GetChild(0).GetText().Trim('"');
            var value = VisitValue(context.GetChild(2).Payload as JSONParser.ValueContext);
            return (name, value);
        }

        public object VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException();
        }

        public object VisitValue([NotNull] JSONParser.ValueContext context)
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
                return token.Text.Trim('"');
            }
            else
            {
                throw new NotSupportedException("");
            }
        }
    }
}