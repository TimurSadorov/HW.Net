using System.ComponentModel.DataAnnotations;

namespace Homework10.DbModels
{
	public class SolvingExpression
	{
		public int SolvingExpressionId { get; set; }
		[Required] public string Expression { get; set; }

		[Required] public string Result { get; set; }
	}
}