using System.Net.Http.Headers;

namespace Test_DrinksV4.Lib
{
    public class GeneralSearch
    {
        public HttpClient? Client { get; set; }
        private readonly string BASE_PATH = "https://www.thecocktaildb.com/api/json/v1/1/";


        /// <summary>
        /// The API query is executed
        /// </summary>
        public string ExecuteQuery(string path)
        {
            if (Client != null)
            {
                Client.BaseAddress = new Uri(BASE_PATH);
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = Client.GetAsync(path);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    if (!string.IsNullOrEmpty(readTask.Result))
                    {
                        return readTask.Result;
                    }
                }
                throw new Exception("Error query path");
            }
            throw new Exception("Error client query");
        }
    }
}
