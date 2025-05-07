using System.Text.Json;

namespace RecipeAppUI.Core.Helpers
{
	public static class JsonHelper
	{
		private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};

		public static async Task<T?> DeserializeResponseAsync<T>(HttpResponseMessage response)
		{
			var json = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<T>(json, _options);
		}
	}
}
