using System;
using System.Collections.Generic;
using VDS.RDF;
using VDS.RDF.Writing;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

public class HelloWorld
{
    public static void Main(String[] args)
    {

        /* 
        IGraph g = new Graph();
        IUriNode dotNetRDF = g.CreateUriNode(UriFactory.Create("http://www.dotnetrdf.org"));
        IUriNode says = g.CreateUriNode(UriFactory.Create("http://example.org/says"));
        ILiteralNode helloWorld = g.CreateLiteralNode("Hello World");
        ILiteralNode bonjourMonde = g.CreateLiteralNode("Bonjour tout le Monde", "fr");

        g.Assert(new Triple(dotNetRDF, says, helloWorld));
        g.Assert(new Triple(dotNetRDF, says, bonjourMonde));

        */



        
        //Create a Parameterized String
        SparqlParameterizedString queryString = new SparqlParameterizedString();

        //Add a namespace declaration
        queryString.Namespaces.AddNamespace("ex", new Uri("http://example.org/ns#"));

        //Set the SPARQL command
        //For more complex queries we can do this in multiple lines by using += on the
        //CommandText property
        //Note we can use @name style parameters here
        queryString.CommandText = "SELECT * WHERE { ?s ex:property @value }";

        //Inject a Value for the parameter
        queryString.SetUri("value", new Uri("http://example.org/value"));

        //When we call ToString() we get the full command text with namespaces appended as PREFIX
        //declarations and any parameters replaced with their declared values
        Console.WriteLine(queryString.ToString());

        //We can turn this into a query by parsing it as in our previous example
        SparqlQueryParser parser = new SparqlQueryParser();
        SparqlQuery query = parser.ParseFromString(queryString);
    
    }
}