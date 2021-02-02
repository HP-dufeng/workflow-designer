using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutomationDesigner.Store.StencilSetsUserCase.Models
{
    public class StencilSets
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("propertyPackages")]
        public PropertyPackage[] PropertyPackages { get; set; }

        [JsonProperty("stencils")]
        public Stencil[] Stencils { get; set; }

        [JsonProperty("rules")]
        public Rules Rules { get; set; }

    }

    public class CardinalityRule
    {
        [JsonProperty("role")]
        public string Role { get; set; }


        public Dictionary<string, Edge> Edges { get; set; }
    }

    public class ConnectionRule
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("connects")]
        public Connect[] Connects { get; set; }
    }

    public class Connect
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string[] to { get; set; }
    }

    public class ContainmentRule
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("contains")]
        public string[] Contains { get; set; }
    }

    public class Edge
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("maximum")]
        public int Maximum { get; set; }
    }

    public class Layout
    {
        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class MorphingRule
    {
        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("baseMorphs")]
        public string[] BaseMorphs { get; set; }

        [JsonProperty("preserveBounds")]
        public bool PreserveBounds { get; set; }
    }



    public class Property
    {
        public Property()
        {
            RefToView = new List<string>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("popular")]
        public bool Popular { get; set; }

        [JsonProperty("refToView")]
        public List<string> RefToView { get; set; }
    }

    public class PropertyPackage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
    }



    public class Rules
    {
        [JsonProperty("cardinalityRules")]
        public CardinalityRule[] CardinalityRules { get; set; }

        [JsonProperty("connectionRules")]
        public ConnectionRule[] ConnectionRules { get; set; }

        [JsonProperty("containmentRules")]
        public ContainmentRule[] ContainmentRules { get; set; }

        [JsonProperty("morphingRules")]
        public MorphingRule[] MorphingRules { get; set; }
    }

    public class Stencil
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("view")]
        public string View { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("groups")]
        public string[] Groups { get; set; }

        [JsonProperty("mayBeRoot")]
        public bool MayBeRoot { get; set; }

        [JsonProperty("hide")]
        public bool Hide { get; set; }

        [JsonProperty("propertyPackages")]
        public string[] PropertyPackages { get; set; }

        [JsonProperty("hiddenPropertyPackages")]
        public string[] HiddenPropertyPackages { get; set; } //assumed data type to be string

        [JsonProperty("roles")]
        public string[] Roles { get; set; }
    }
}