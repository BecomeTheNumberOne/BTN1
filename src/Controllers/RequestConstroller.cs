using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BTN1.Models;
using VDS.RDF;
using VDS.RDF.Writing;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using System.IO;
using Newtonsoft.Json.Linq;
using static BTN1.Models.RequestAPI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using VDS.RDF.Writing.Formatting;

namespace BTN1.Controllers
{
    public class RequestController : Controller{


        public IActionResult Index()
        {

            return View();
        }

        public ActionResult Game()
        {
            //store result in var data. 
            var data=new List<Data>();
            RequestSparql(data);
            var Ndata=new List<Data>();
            Random rnd = new Random();
            for(int i=0;i<10;i++){
                int r=rnd.Next(data.Count);
                Ndata.Add(data[r]);
            }

            foreach (Data element in Ndata){
                
                BingAPI(element.Name);
                
            }

            return null;
        }
        public IActionResult RequestSparql(List<Data> data)
        {

            //Define a remote endpoint
            //Use the DBPedia SPARQL endpoint with the default Graph set to DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");

            

            //Make a SELECT query against the Endpoint
            SparqlResultSet results = endpoint.QueryWithResultSet("SELECT * WHERE {?iri a schema:Movie . ?iri foaf:name ?name .} Limit 100");
            
            

            
            
            foreach (SparqlResult result in results)
            {
                //Console.WriteLine(result.ToString());

                //IEnumerator<KeyValuePair<String, INode>> result2=result.GetEnumerator();
                Data _d=new Data();
                foreach (KeyValuePair<string, INode> kvp in result)
                {
                    
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                     
                    if(kvp.Key=="iri"){
                        _d.URL= kvp.Value.ToString();
                    }else if(kvp.Key == "name"){
                        string chaineModif = kvp.Value.ToString();
                        string toRemove = "@";
                        int i = chaineModif.IndexOf(toRemove);
                        if (i >= 0)
                        {
                            _d.Name= chaineModif.Remove(i, chaineModif.Length-i);
                        }
                    }
                    
                }
                data.Add(_d);
                
            }
            
            Console.WriteLine("------------------------------------------------------------------");

            /* 
            //Make a DESCRIBE query against the Endpoint
            IGraph g = endpoint.QueryWithResultGraph("DESCRIBE");
            foreach (Triple t in g.Triples)
            {
                Console.WriteLine(t.ToString());
            }
            */

            //BingAPI("Gilet jaune");
            return View(data);
        }


        public IActionResult LoadFileG(){

            TripleStore store = new TripleStore();

            
            IGraph g = new Graph();
            
            NTriplesParser ntparser = new NTriplesParser();

                //Load using Filename
                ntparser.Load(g, new StreamReader ("Data/anime_dataset.nt"));
                g.NamespaceMap.AddNamespace("schema", new Uri("http://schema.org/"));
                store.Add(g);

                /* 
                ITripleFormatter formatter = new TurtleFormatter(g);
                Console.WriteLine("------------------------");
                //Print triples with this formatter
                foreach (Triple t in g.Triples)
                {
                    Console.WriteLine(t.ToString());
                }
                */


                //Execute a raw SPARQL Query
		        //Should get a SparqlResultSet back from a SELECT query
                
		        Object results = store.ExecuteQuery("PREFIX schema: <http://schema.org/> SELECT * WHERE {?iri a schema:TVSeries .?iri schema:image ?image.}LIMIT 10");

                
                if (results is SparqlResultSet)
                {
                    //Print out the Results
                    SparqlResultSet rset = (SparqlResultSet)results;
                    foreach (SparqlResult result in rset)
                    {
                        
                        Console.WriteLine(result.ToString());
                    }
		        }
                

            return View();

            }

        public IActionResult BingAPI(String search) 
        {

            
            string searchTerm = search;


            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Searching images for: " + searchTerm + "\n");
            //send a search request using the search term
            SearchResult result = BingImageSearch(searchTerm);
            //deserialize the JSON response from the Bing Image Search API
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(result.jsonResult);

            var firstJsonObj = jsonObj["value"][0];
            Console.WriteLine("Title for the first image result: " + firstJsonObj["name"] + "\n");
            //After running the application, copy the output URL into a browser to see the image. 
            //Console.WriteLine("URL for the first image result: " + firstJsonObj["contentUrl"] + "\n");

            String url=firstJsonObj["contentUrl"]+"";
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), Directory.GetCurrentDirectory()+@"\wwwroot\images\"+searchTerm+".jpeg");
            }

            ViewBag.url = searchTerm +".jpeg";
            return View();
        }

        

        }

}