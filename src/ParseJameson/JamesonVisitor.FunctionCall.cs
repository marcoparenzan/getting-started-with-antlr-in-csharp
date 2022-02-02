using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Linq.Expressions;

namespace ParseJameson
{
    public partial class JamesonVisitor<TTarget>
    {
        public Expression VisitAlpha([NotNull] JamesonParser.AlphaContext context)
        {
            var name = context.GetChild(0).GetText();
            var mi = typeof(TTarget).GetMethod(name);
            var arg1 = Visit(context.GetChild(2));
            var arg2 = Visit(context.GetChild(4));
            return Expression.Call(contextExpression, mi, arg1,arg2);
        }
        
        public Expression VisitBeta([NotNull] JamesonParser.BetaContext context)
        {
            var name = context.GetChild(0).GetText();
            var mi = typeof(TTarget).GetMethod(name);
            var arg1 = Visit(context.GetChild(2));
            return Expression.Call(contextExpression, mi, arg1);
        }

        public Expression VisitGamma([NotNull] JamesonParser.GammaContext context)
        {
            var name = context.GetChild(0).GetText();
            var mi = typeof(TTarget).GetMethod(name);
            return Expression.Call(contextExpression, mi);
        }
    }
}