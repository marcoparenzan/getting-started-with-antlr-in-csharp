using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ExpressionsParser;

namespace ParseExpressions
{
    public partial class ExpressionsVisitor<TTarget> : IExpressionsVisitor<Expression>
    {
        TTarget contextInstance;
        ParameterExpression contextExpression;

        public ExpressionsVisitor(TTarget instance)
        {
            this.contextInstance = instance;
            this.contextExpression = Expression.Variable(typeof(TTarget), "context");
        }

        public Expression Visit(IParseTree tree)
        {
            if (tree.Payload is ExpressionsParser.LiteralContext literal)
            {
                return VisitLiteral(literal);
            }
            else if (tree.Payload is ExpressionsParser.FunctionCallContext functionCall)
            {
                // alpha, beta, gamma
                throw new NotImplementedException();
            }
            else if (tree.Payload is ExpressionsParser.AlphaContext alpha)
            {
                return VisitAlpha(alpha);
            }
            else if (tree.Payload is ExpressionsParser.BetaContext beta)
            {
                return VisitBeta(beta);
            }
            else if (tree.Payload is ExpressionsParser.GammaContext gamma)
            {
                return VisitGamma(gamma);
            }

            else if (tree.Payload is ExpressionsParser.ArgListContext argList)
            {
                return VisitArgList(argList);
            }
            else if (tree.Payload is ExpressionsParser.AttributeContext attribute)
            {
                return VisitAttribute(attribute);
            }
            else if (tree.Payload is ExpressionsParser.BitXorContext bitXor)
            {
                return VisitBitXor(bitXor);
            }
            else if (tree.Payload is ExpressionsParser.BooleanContext boolean)
            {
                return VisitBoolean(boolean);
            }
            else if (tree.Payload is ExpressionsParser.CallContext call)
            {
                return VisitCall(call);
            }
            else if (tree.Payload is ExpressionsParser.ComparisonContext comparison)
            {
                return VisitComparison(comparison);
            }
            else if (tree.Payload is ExpressionsParser.FactorContext factor)
            {
                return VisitFactor(factor);
            }
            else if (tree.Payload is ExpressionsParser.GetNodeContext getNode)
            {
                return VisitGetNode(getNode);
            }
            else if (tree.Payload is ExpressionsParser.JumpLiteralContext jumpLiteral)
            {
                return VisitJumpLiteral(jumpLiteral);
            }
            else if (tree.Payload is ExpressionsParser.LogicAndContext logicAnd)
            {
                return VisitLogicAnd(logicAnd);
            }
            else if (tree.Payload is ExpressionsParser.LogicNotContext logicNot)
            {
                return VisitLogicNot(logicNot);
            }
            else if (tree.Payload is ExpressionsParser.LogicOrContext logicOr)
            {
                return VisitLogicOr(logicOr);
            }
            else if (tree.Payload is ExpressionsParser.MinusContext minus)
            {
                return VisitMinus(minus);
            }
            else if (tree.Payload is ExpressionsParser.ParentesesContext parenteses)
            {
                return VisitParenteses(parenteses);
            }
            else if (tree.Payload is ExpressionsParser.PlusContext plus)
            {
                return VisitPlus(plus);
            }
            else if (tree.Payload is ExpressionsParser.SignContext sign)
            {
                return VisitSign(sign);
            }
            else if (tree.Payload is ExpressionsParser.SubscriptionContext subscription)
            {
                return VisitSubscription(subscription);
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

        public Expression VisitArgList([NotNull] ExpressionsParser.ArgListContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitAttribute([NotNull] ExpressionsParser.AttributeContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitBitXor([NotNull] ExpressionsParser.BitXorContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitBoolean([NotNull] ExpressionsParser.BooleanContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitCall([NotNull] ExpressionsParser.CallContext context)
        {
            var target = context.GetChild(0);
            if (target.Payload is ExpressionsParser.AlphaContext alpha)
            {
                return VisitAlpha(alpha);
            }
            else if (target.Payload is ExpressionsParser.BetaContext beta)
            {
                return VisitBeta(beta);
            }
            else if (target.Payload is ExpressionsParser.GammaContext gamma)
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

        public Expression VisitComparison([NotNull] ExpressionsParser.ComparisonContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitFactor([NotNull] ExpressionsParser.FactorContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitGetNode([NotNull] ExpressionsParser.GetNodeContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitJumpLiteral([NotNull] ExpressionsParser.JumpLiteralContext context)
        {
            var target = context.GetChild(0) as LiteralContext;
            if (target != null)
                return VisitLiteral(target);
            else
                throw new NotImplementedException();
        }

        public Expression VisitLiteral([NotNull] ExpressionsParser.LiteralContext context)
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

        public Expression VisitLogicAnd([NotNull] ExpressionsParser.LogicAndContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitLogicNot([NotNull] ExpressionsParser.LogicNotContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitLogicOr([NotNull] ExpressionsParser.LogicOrContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitMinus([NotNull] ExpressionsParser.MinusContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitParenteses([NotNull] ExpressionsParser.ParentesesContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitPlus([NotNull] ExpressionsParser.PlusContext context)
        {
            var a = Visit(context.GetChild(0));
            var b = Visit(context.GetChild(2));
            return Expression.Add(a, b);
        }

        public Expression VisitSign([NotNull] ExpressionsParser.SignContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitSubscription([NotNull] ExpressionsParser.SubscriptionContext context)
        {
            throw new NotImplementedException("");
        }

        public Expression VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException("");
        }
    }
}
