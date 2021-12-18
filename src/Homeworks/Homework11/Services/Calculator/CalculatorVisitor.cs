using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication.Services.Calculator
{
    internal class CalculatorVisitor
    {
        public double VisitDynamic(Expression expression)
        {
            var t = Visit((dynamic) expression);
            return (double) ((ConstantExpression) t).Value!;
        }
        
        private Expression Visit(BinaryExpression node)
        {
            var leftNodeTask = Task.Run(() =>VisitDynamic(node.Left));
            var rightNodeTask = Task.Run(() => VisitDynamic(node.Right));
            Thread.Sleep(1000);
            Task.WhenAll(leftNodeTask, rightNodeTask);
            var leftNode = leftNodeTask.Result;
            var rightNode = rightNodeTask.Result;
            
            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Constant(leftNode + rightNode, typeof(double)),
                ExpressionType.Subtract => Expression.Constant(leftNode - rightNode, typeof(double)),
                ExpressionType.Multiply => Expression.Constant(leftNode * rightNode, typeof(double)),
                ExpressionType.Divide => Expression.Constant(leftNode / rightNode, typeof(double))
            };
        }

        private Expression Visit(ConstantExpression node)
        {
            return node;
        }
    }
}