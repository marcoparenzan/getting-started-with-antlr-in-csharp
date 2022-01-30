using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace ParseJson
{
    public class JNodeVisitor : IJSONVisitor<JItem>
    {
        public JItem Visit(IParseTree tree)
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
                return (JValue) token.Text.Trim('"');
            }
            else
            {
                throw new NotSupportedException("");
            }
        }

        public JItem VisitArr([NotNull] JSONParser.ArrContext context)
        {
            var list = new JList();
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

        public JItem VisitChildren(IRuleNode node)
        {
            throw new NotImplementedException();
        }

        public JItem VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException();
        }

        public JItem VisitJson([NotNull] JSONParser.JsonContext context)
        {
            return VisitValue(context.value());
        }

        public JItem VisitObj([NotNull] JSONParser.ObjContext context)
        {
            var dict = new JNode();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JSONParser.PairContext pair)
                {
                    var name = pair.children[0].GetText().Trim('"');
                    if (pair.children[1].Payload is JSONParser.ValueContext valueCtx)
                        dict[name] = VisitValue(valueCtx);
                    else if (pair.children[1].Payload is CommonToken vtx)
                        dict[name] = (JValue) vtx.Text;
                    else
                        throw new NotImplementedException();
                }
            }
            return dict;
        }

        public JItem VisitPair([NotNull] JSONParser.PairContext context)
        {
            throw new NotImplementedException();
        }

        public JItem VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException();
        }

        public JItem VisitValue([NotNull] JSONParser.ValueContext context)
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
                return (JValue) token.Text.Trim('"');
            }
            else
            {
                throw new NotSupportedException("");
            }
        }
    }
}