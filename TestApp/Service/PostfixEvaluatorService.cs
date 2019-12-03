using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp.Enums;
using TestApp.Model;

namespace TestApp.Service
{
    public class PostfixEvaluatorService
    {
        Stack<Token> Stack;

        public PostfixEvaluatorService()
        {
            Stack = new Stack<Token>();
        }

        /// <summary>
        /// Evaluates Postfix collection
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public float Evaluate(IList<Token> tokens)
        {
            if (tokens == null || !tokens.Any()) return 0;

            foreach (var token in tokens)
            {
                if(token.TokenType == TokenType.Value)
                {
                    Stack.Push(token);
                }
                else
                {
                    var tmp1 = ((ValueToken)Stack.Pop()).Value;
                    var tmp2 = ((ValueToken)Stack.Pop()).Value;

                    var result = ((OperatorToken)token).Evaluate(tmp2, tmp1);

                    Stack.Push(new ValueToken() { Value = result });
                }
            }
            return ((ValueToken)Stack.Pop()).Value;
        }
    }
}
