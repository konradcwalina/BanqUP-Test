using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Abstract;
using TestApp.Enums;
using TestApp.Model;

namespace TestApp.Extensions
{
    public static class OperatorToTokenExtension
    {
        public static OperatorToken ToToken(this Operator token)
        {
            switch (token.OperatorType)
            {
                case OperatorType.Plus: return new OperatorToken<PlusOperator>((PlusOperator)token);
                case OperatorType.Minus: return new OperatorToken<MinusOperator>((MinusOperator)token);
                case OperatorType.Divide: return new OperatorToken<DivideOperator>((DivideOperator)token);
                case OperatorType.Multiply: return new OperatorToken<MultiplyOperator>((MultiplyOperator)token);
                default: return null;
            }
        }
    }
}
