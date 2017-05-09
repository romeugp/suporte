using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSuporte.Models
{
    public class State
    {
        public string CountryCode { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }

        public static IQueryable<State> GetState()
        {

            return new List<State>
            {
                new State
                {
                    CountryCode = "CA",
                    StateID=1,
                    StateName = "Ontario"
                },
                new State
                {
                   CountryCode = "CA",
                    StateID=2,
                    StateName = "OQuebec"
                },
                new State
                {
                   CountryCode = "CA",
                    StateID=3,
                    StateName = "Nova Scotia"
                },
                new State
                {
                    CountryCode = "US",
                    StateID=4,
                    StateName = "New-York"
                },
                new State
                {
                   CountryCode = "US",
                    StateID=5,
                    StateName = "California"
                },
            }.AsQueryable();

        }

    }
}