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

        public IActionResult RequestSparql()
        {

            //Define a remote endpoint
            //Use the DBPedia SPARQL endpoint with the default Graph set to DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");

            

            //Make a SELECT query against the Endpoint
            SparqlResultSet results = endpoint.QueryWithResultSet("SELECT * WHERE {?iri a schema:Movie . ?iri foaf:name ?name .}");
            var data=new List<String>();

            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
                data.Add(result.ToString());

            }

            
            
            Console.WriteLine("------------------------------------------------------------------");

            /* 
            //Make a DESCRIBE query against the Endpoint
            IGraph g = endpoint.QueryWithResultGraph("DESCRIBE");
            //g.NamespaceMap.AddNamespace("schema", new Uri("http://schema.org/"));
            foreach (Triple t in g.Triples)
            {
                Console.WriteLine(t.ToString());
            }
            */

            return View(data);
        }


    }

}