using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;
using Web.Domain.Entities.ListElement;
using Web.Domain.Interfaces.RootServices;
using Web.Domain.Pagination;
using Web.Domain.Views.ListElement;

namespace Web.Service.Services.RootElement
{
    public class RootElementService : IRootElementService

    {

        public async System.Threading.Tasks.Task<Root> FindUserAsync(string userName)
        {
            Root obj = new Root();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://bio.torre.co/api/bios/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync(userName);
                    if (response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();

                        using (StreamReader sr = new StreamReader(stream))
                        using (JsonReader reader = new JsonTextReader(sr))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            obj = serializer.Deserialize<Root>(reader);
                        }
                        return obj;
                    }
                    else
                    {
                        return obj;

                    }


                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<ListElement.Root> ListadoResult(ListElementCriteria criteria, int page  )
        {
            ListElement.Root obj = new ListElement.Root();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://search.torre.co/people/_search/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new FormUrlEncodedContent(
                        new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("Currency", criteria.currency),
                            new KeyValuePair<string, string>("page", page.ToString()),
                            new KeyValuePair<string, string>("periodicity", criteria.periodicity),
                            new KeyValuePair<string, string>("size", "10")
                         }
                    );
                    HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();

                        using (StreamReader sr = new StreamReader(stream))
                        using (JsonReader reader = new JsonTextReader(sr))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            obj = serializer.Deserialize<ListElement.Root>(reader);
                        }
                        return obj;
                    }
                    else
                    {
                        return obj;

                    }


                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        //Paginacion
        public PagingList<ListElement.Result> GetPaginateResultOrdersListView(ListElementCriteria criteria, int pageNo, bool firstLoad)
        {
            List<ListElement.Result> list = new List<ListElement.Result>();
            ListElement.Root obj = new ListElement.Root();
            string Uri = string.Format("https://search.torre.co/people/_search/?page={0}&periodicity={1}&currency={2}&size=10", pageNo.ToString(), criteria.periodicity, criteria.currency);
            var client = new RestClient(Uri);
            client.Timeout = 5000;
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            obj = JsonConvert.DeserializeObject<ListElement.Root>(response.Content);
            int total = obj.total;
            
            if (obj.results != null)
            {
                list = obj.results;
            }
            return PagingList<ListElement.Result>.Create(list.AsQueryable(), pageNo, total);

        }
    }
}
