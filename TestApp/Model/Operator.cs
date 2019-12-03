using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Enums;

namespace TestApp.Model
{
    /// <summary>
    /// Define Operator Type 
    /// </summary>
    public abstract class Operator
    {
        /// <summary>
        /// Type of Operation to perform
        /// </summary>
        public abstract OperatorType OperatorType { get; }

        /// <summary>
        /// Evaluation function
        /// </summary>
        public abstract Func<float, float, float> Evaluate { get; }

        /// <summary>
        /// Character symbol
        /// </summary>
        public abstract char Character { get; }

        /// <summary>
        /// Operation priority
        /// </summary>
        public abstract int Precedense { get; }

        /// <summary>
        /// Helper for regex parsing
        /// </summary>
        public virtual string CharacterAsString => Character.ToString();
    }

    public class PlusOperator : Operator
    {
        public override OperatorType OperatorType => OperatorType.Plus;

        public override Func<float, float, float> Evaluate => (x, y) => x + y;

        public override char Character => '+';

        public override int Precedense => 1;
    }

    public class MinusOperator : Operator
    {
        public override OperatorType OperatorType => OperatorType.Minus;

        public override Func<float, float, float> Evaluate => (x, y) => x - y;

        public override char Character => '-';

        public override int Precedense => 1;
    }

    public class MultiplyOperator : Operator
    {
        public override OperatorType OperatorType => OperatorType.Multiply;

        public override Func<float, float, float> Evaluate => (x, y) => x * y;

        public override char Character => '*';

        public override int Precedense => 2;
    }

    public class DivideOperator : Operator
    {
        public override OperatorType OperatorType => OperatorType.Divide;

        public override Func<float, float, float> Evaluate => (x, y) => { if (y == 0) throw new DivideByZeroException(); return x / y; };

        public override char Character => '/';

        public override int Precedense => 2;
    }
}
