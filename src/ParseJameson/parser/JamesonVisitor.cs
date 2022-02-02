//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from d:\repos-clones\getting-started-with-antlr-in-csharp\src\ParseJameson\Jameson.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="JamesonParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IJamesonVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>minus</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMinus([NotNull] JamesonParser.MinusContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>jumpLiteral</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJumpLiteral([NotNull] JamesonParser.JumpLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>comparison</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparison([NotNull] JamesonParser.ComparisonContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicOr</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicOr([NotNull] JamesonParser.LogicOrContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>sign</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSign([NotNull] JamesonParser.SignContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>subscription</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubscription([NotNull] JamesonParser.SubscriptionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>plus</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlus([NotNull] JamesonParser.PlusContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>jmespath</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJmespath([NotNull] JamesonParser.JmespathContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>call</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCall([NotNull] JamesonParser.CallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicAnd</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicAnd([NotNull] JamesonParser.LogicAndContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>boolean</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolean([NotNull] JamesonParser.BooleanContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenteses</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenteses([NotNull] JamesonParser.ParentesesContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bitXor</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitXor([NotNull] JamesonParser.BitXorContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>json</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJson([NotNull] JamesonParser.JsonContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>getNode</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGetNode([NotNull] JamesonParser.GetNodeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>attribute</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute([NotNull] JamesonParser.AttributeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>factor</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFactor([NotNull] JamesonParser.FactorContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicNot</c>
	/// labeled alternative in <see cref="JamesonParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicNot([NotNull] JamesonParser.LogicNotContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JamesonParser.obj"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObj([NotNull] JamesonParser.ObjContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JamesonParser.pair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPair([NotNull] JamesonParser.PairContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JamesonParser.arr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArr([NotNull] JamesonParser.ArrContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JamesonParser.argList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgList([NotNull] JamesonParser.ArgListContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>alpha</c>
	/// labeled alternative in <see cref="JamesonParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAlpha([NotNull] JamesonParser.AlphaContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>beta</c>
	/// labeled alternative in <see cref="JamesonParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBeta([NotNull] JamesonParser.BetaContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>gamma</c>
	/// labeled alternative in <see cref="JamesonParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGamma([NotNull] JamesonParser.GammaContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JamesonParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] JamesonParser.LiteralContext context);
}
