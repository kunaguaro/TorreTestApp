using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities.ListElement
{
    public class ListElement
    {
        public class Aggregators
        {
        }

        public class Context
        {
            public object signaled { get; set; }
        }

        public class Person
        {
            public double weight { get; set; }
            public double? completion { get; set; }
            public double? grammar { get; set; }
        }

        public class Input
        {
            public object criteria { get; set; }
            public Person person { get; set; }
        }

        public class And
        {
            [JsonProperty("@type")]
            public string Type { get; set; }
            public double rank { get; set; }
            public string scorer { get; set; }
            public object score { get; set; }
            public Input input { get; set; }
        }

        public class Ranker
        {
            [JsonProperty("@type")]
            public string Type { get; set; }
            public double rank { get; set; }
            public object score { get; set; }
            public List<And> and { get; set; }
        }

        public class Meta
        {
            public Ranker ranker { get; set; }
            public object filter { get; set; }
        }

        public class Freelancer
        {
            public double amount { get; set; }
            public string currency { get; set; }
            public string periodicity { get; set; }
        }

        public class Employee
        {
            public double amount { get; set; }
            public string currency { get; set; }
            public string periodicity { get; set; }
        }

        public class Intern
        {
            public double amount { get; set; }
            public string currency { get; set; }
            public string periodicity { get; set; }
        }

        public class Compensations
        {
            public Freelancer freelancer { get; set; }
            public Employee employee { get; set; }
            public Intern intern { get; set; }
        }

        public class Skill
        {
            public string name { get; set; }
            public double weight { get; set; }
        }

        public class Result
        {
            public Context context { get; set; }
            public Meta _meta { get; set; }
            public Compensations compensations { get; set; }
            public string locationName { get; set; }
            public string name { get; set; }
            public List<string> openTo { get; set; }
            public string picture { get; set; }
            public string professionalHeadline { get; set; }
            public bool remoter { get; set; }
            public List<Skill> skills { get; set; }
            public string subjectId { get; set; }
            public string username { get; set; }
            public bool verified { get; set; }
            public double weight { get; set; }
        }

        public class Root
        {
            public Aggregators aggregators { get; set; }
            public int offset { get; set; }
            public List<Result> results { get; set; }
            public int size { get; set; }
            public int total { get; set; }
        }

    }
}
