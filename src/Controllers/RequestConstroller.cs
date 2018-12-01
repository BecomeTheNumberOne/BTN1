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
            
            

            //store result in var data. 
            var data=new List<Data>();
            
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
                        _d.Name= kvp.Value.ToString();
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

            return View(data);
        }


        public IActionResult LoadFileG(){

            try
            {
                IGraph g = new Graph();
                NTriplesParser ntparser = new NTriplesParser();

                //Load using Filename
                ntparser.Load(g, "Data/animelist_dataset.nt");
            }
            catch (RdfParseException parseEx)
            {
                //This indicates a parser error e.g unexpected character, premature end of input, invalid syntax etc.
                Console.WriteLine("Parser Error");
                Console.WriteLine(parseEx.Message);
            }
            catch (RdfException rdfEx)
            {
                //This represents a RDF error e.g. illegal triple for the given syntax, undefined namespace
                Console.WriteLine("RDF Error");
                Console.WriteLine(rdfEx.Message);
            }

            return View();

            }




    }

}