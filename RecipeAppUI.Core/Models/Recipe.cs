using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppUI.Core.Models
{
	public class Recipe
	{
		public required string Name { get; set; }
		public required Ingredient Ingredient { get; set; }
	}
}
