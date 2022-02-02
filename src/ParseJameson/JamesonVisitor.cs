using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using ParseJameson.Model;
using System.Linq.Expressions;
using static JamesonParser;

namespace ParseJameson
{
    public partial class JamesonVisitor<TTarget> : IJamesonVisitor<Expression>
    {
        TTarget contextInstance;
        ParameterExpression contextExpression;

        public JamesonVisitor(TTarget instance)
        {
            this.contextInstance = instance;
            this.contextExpression = Expression.Variable(typeof(TTarget), "context");
        }

        public Expression Visit(IParseTree tree)
        {
            if (tree.Payload is JamesonParser.LiteralContext literal)
            {
                return VisitLiteral(literal);
            }
            else if (tree.Payload is JamesonParser.FunctionCallContext functionCall)
            {
                // alpha, beta, gamma
                throw new NotImplementedException();
            }
            else if (tree.Payload is JamesonParser.AlphaContext alpha)
            {
                return VisitAlpha(alpha);
            }
            else if (tree.Payload is JamesonParser.BetaContext beta)
            {
                return VisitBeta(beta);
            }
            else if (tree.Payload is JamesonParser.GammaContext gamma)
            {
                return VisitGamma(gamma);
            }

            else if (tree.Payload is JamesonParser.ArgListContext argList)
            {
                return VisitArgList(argList);
            }
            else if (tree.Payload is JamesonParser.AttributeContext attribute)
            {
                return VisitAttribute(attribute);
            }
            else if (tree.Payload is JamesonParser.BitXorContext bitXor)
            {
                return VisitBitXor(bitXor);
            }
            else if (tree.Payload is JamesonParser.BooleanContext boolean)
            {
                return VisitBoolean(boolean);
            }
            else if (tree.Payload is JamesonParser.CallContext call)
            {
                return VisitCall(call);
            }
            else if (tree.Payload is JamesonParser.ComparisonContext comparison)
            {
                return VisitComparison(comparison);
            }
            else if (tree.Payload is JamesonParser.FactorContext factor)
            {
                return VisitFactor(factor);
            }
            else if (tree.Payload is JamesonParser.GetNodeContext getNode)
            {
                return VisitGetNode(getNode);
            }
            else if (tree.Payload is JamesonParser.JumpLiteralContext jumpLiteral)
            {
                return VisitJumpLiteral(jumpLiteral);
            }
            else if (tree.Payload is JamesonParser.LogicAndContext logicAnd)
            {
                return VisitLogicAnd(logicAnd);
            }
            else if (tree.Payload is JamesonParser.LogicNotContext logicNot)
            {
                return VisitLogicNot(logicNot);
            }
            else if (tree.Payload is JamesonParser.LogicOrContext logicOr)
            {
                return VisitLogicOr(logicOr);
            }
            else if (tree.Payload is JamesonParser.MinusContext minus)
            {
                return VisitMinus(minus);
            }
            else if (tree.Payload is JamesonParser.ParentesesContext parenteses)
            {
                return VisitParenteses(parenteses);
            }
            else if (tree.Payload is JamesonParser.PlusContext plus)
            {
                return VisitPlus(plus);
            }
            else if (tree.Payload is JamesonParser.SignContext sign)
            {
                return VisitSign(sign);
            }
            else if (tree.Payload is JamesonParser.SubscriptionContext subscription)
            {
                return VisitSubscription(subscription);
            }
            else if (tree.Payload is JamesonParser.JsonContext json)
            {
                return VisitJson(json);
            }
            else if (tree.Payload is JamesonParser.JmespathContext jmespath)
            {
                return VisitJmespath(jmespath);
            }
            else if (tree.Payload is CommonToken token)
            {
                return Expression.Constant(token.Text.Trim('"'));
            }
            else
            {
                throw new NotImplementedException("");
            }
        }

        public Expression VisitArgList([NotNull] JamesonParser.ArgListContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitAttribute([NotNull] JamesonParser.AttributeContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitBitXor([NotNull] JamesonParser.BitXorContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitBoolean([NotNull] JamesonParser.BooleanContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitCall([NotNull] JamesonParser.CallContext context)
        {
            var target = context.GetChild(0);
            if (target.Payload is JamesonParser.AlphaContext alpha)
            {
                return VisitAlpha(alpha);
            }
            else if (target.Payload is JamesonParser.BetaContext beta)
            {
                return VisitBeta(beta);
            }
            else if (target.Payload is JamesonParser.GammaContext gamma)
            {
                return VisitGamma(gamma);
            }
            else
                throw new NotImplementedException("");
        }

        public Expression VisitChildren(IRuleNode node)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitComparison([NotNull] JamesonParser.ComparisonContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitFactor([NotNull] JamesonParser.FactorContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitGetNode([NotNull] JamesonParser.GetNodeContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitJumpLiteral([NotNull] JamesonParser.JumpLiteralContext context)
        {
            var target = context.GetChild(0) as LiteralContext;
            if (target != null)
                return VisitLiteral(target);
            else
                throw new NotImplementedException();
        }

        public Expression VisitLiteral([NotNull] JamesonParser.LiteralContext context)
        {
            if (context.STRING() != null)
            {
                return Expression.Constant(context.STRING().GetText());
            }
            else if (context.INTEGER() != null)
            {
                return Expression.Constant(int.Parse(context.INTEGER().GetText()));
            }
            else if (context.FLOAT() != null)
            {
                return Expression.Constant(float.Parse(context.FLOAT().GetText()));
            }
            else if (context.IDENTIFIER() != null)
            {
                throw new NotImplementedException();
            }
            else
                throw new NotImplementedException();

        }

        public Expression VisitLogicAnd([NotNull] JamesonParser.LogicAndContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitLogicNot([NotNull] JamesonParser.LogicNotContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitLogicOr([NotNull] JamesonParser.LogicOrContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitMinus([NotNull] JamesonParser.MinusContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitParenteses([NotNull] JamesonParser.ParentesesContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitPlus([NotNull] JamesonParser.PlusContext context)
        {
            var a = Visit(context.GetChild(0));
            var b = Visit(context.GetChild(2));
            return Expression.Add(a, b);
        }

        public Expression VisitSign([NotNull] JamesonParser.SignContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitSubscription([NotNull] JamesonParser.SubscriptionContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException("");
        }

        /// JSON

        public Expression VisitArr([NotNull] ArrContext context)
        {
            var ctor = typeof(JList).GetConstructors()[1];

            var initializers = new List<Expression>();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JamesonParser.ExpressionContext value)
                {
                    var v = Visit(value);
                    initializers.Add(v);
                }
            }

            return Expression.New(ctor, Expression.NewArrayInit(typeof(JItem), initializers.ToArray()));
        }

        public Expression VisitJson([NotNull] JsonContext context)
        {
            if (context.obj() != null)
            {
                return VisitObj(context.obj());
            }
            else if (context.arr() != null)
            {
                return VisitArr(context.arr());
            }
            else
                throw new NotImplementedException();
        }

        public Expression VisitObj([NotNull] ObjContext context)
        {
            var ctor = typeof(JNode).GetConstructors()[0];
            var ctorTuple = typeof(JNodeKV).GetConstructors()[0];

            var initializers = new List<Expression>();
            for (var i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child is JamesonParser.PairContext pair)
                {
                    var name = Expression.Constant(pair.GetChild(0).GetText().Trim('"'));
                    var value = Visit(pair.GetChild(2).Payload as JamesonParser.ExpressionContext);

                    var vvalue = Expression.New(typeof(JValue).GetConstructor(new Type[] { value.Type }), value);

                    initializers.Add(Expression.New(ctorTuple, name, vvalue));
                }
            }
            return Expression.New(ctor, Expression.NewArrayInit(typeof(JNodeKV), initializers.ToArray()));
        }

        public Expression VisitPair([NotNull] PairContext context)
        {
            throw new NotImplementedException();
        }

        public Expression VisitJmespath([NotNull] JmespathContext context)
        {
            var text = context.STRING().GetText().Trim('\"');

            return Expression.New(
                typeof(JMSPathQuery).GetConstructor(new Type[] { typeof(string) })
                , Expression.Constant(text));
        }
    }
}
