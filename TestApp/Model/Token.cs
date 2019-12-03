using System;
using TestApp.Abstract;
using TestApp.Enums;

namespace TestApp.Model
{
    /// <summary>
    /// Abstract token class
    /// </summary>
    public abstract class Token
    {
        public abstract TokenType TokenType { get;}
    }

    /// <summary>
    /// Token type for numeric values
    /// </summary>
    public class ValueToken : Token
    {
        public override TokenType TokenType => TokenType.Value;
        public float Value { get; set; }
    }

    /// <summary>
    /// Basic Operator Token
    /// </summary>
    public abstract class OperatorToken : Token
    {
        public override TokenType TokenType => TokenType.Operator;
        public abstract Func<float, float, float> Evaluate { get; }
    }

    /// <summary>
    /// Generic  Operator Token
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperatorToken<T> : OperatorToken where T : Operator
    {
        private Operator @operator;
        public OperatorToken(T @operator)
        {
            this.@operator = @operator;
        }
        public override Func<float, float, float> Evaluate => @operator.Evaluate;
    }


}
