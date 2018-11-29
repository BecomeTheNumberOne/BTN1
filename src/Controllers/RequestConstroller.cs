using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BTN1.Models;
using VDS.RDF;
using VDS.RDF.Writing;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace BTN1.Controllers
{
    public class RequestController : Controller{


        // 
        public IActionResult RequestSparql()
        {

            //Define a remote endpoint
            //Use the DBPedia SPARQL endpoint with the default Graph set to DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");

            

            //Make a SELECT query against the Endpoint
            SparqlResultSet results = endpoint.QueryWithResultSet("SELECT * WHERE {?iri a schema:Movie . ?iri foaf:name ?name .} Limit 20");
            
            
            var data=new List<String>();
            
            foreach (SparqlResult result in results)
            {
                //Console.WriteLine(result.ToString());

                //IEnumerator<KeyValuePair<String, INode>> result2=result.GetEnumerator();

                foreach (KeyValuePair<string, INode> kvp in result)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
                
                data.Add(result.ToString());

            }
            

            /* 
            List <SparqlResult> SRList = results.GetEnumerator();

            foreach( SparqlResult result in SRList){

                IList<KeyValuePair<string, INode>> result2=result.GetEnumerator();
                
                foreach(var element in result2) {

                    Console.WriteLine(element);

                }
                
                
                data.Add(result.ToString());
            }
            */
            


            Console.WriteLine("------------------------------------------------------------------");

            /* 
            //Make a DESCRIBE query against the Endpoint
            IGraph g = endpoint.QueryWithResultGraph("DESCRIBE");
            foreach (Triple t in g.Triples)
            {
                Console.WriteLine(t.ToString());
            }
            */

            return View(data);
        }


    }

}