using Microsoft.AspNetCore.Mvc;
using Newshore.Entities.Entities.Flight;
using Newshore.Entities.Entities.Journey;
using Newshore.Entities.Entities.Transport;
using Newshore.UseCase;
using Newshore.UseCase.SearchFlights;
using Newtonsoft.Json;
using System.Linq;

namespace NewshoreTest.Controllers
{
    [ApiController]
    [Route("Api")]
    public class SearchFlightsController : ControllerBase
    {
        private readonly ILogger<SearchFlightsController> _logger;
        private readonly Services Services;
        private List<SearchFlightsResponse> Flights;
        public List<Flight> flights;
        private List<Flight> NewOrigin;
        private string RouteOrigin;
        public SearchFlightsController(ILogger<SearchFlightsController> logger)
        {
            _logger = logger;
            this.Flights = new List<SearchFlightsResponse>();
            this.flights = new List<Flight>();
            this.NewOrigin = new List<Flight>();
            Services = new Services();
        }

        [HttpGet]
        [Route("SearchList")]
        public async Task<List<SearchFlightsResponse>> Get()
        {
            var FlightsRaw = await Services.GetSearchFlight();
            if (FlightsRaw != null)
            {
                Flights = new List<SearchFlightsResponse>(FlightsRaw);
                Ok();
                return Flights;
            }
            else
            {
                return Flights;
            }
        }

        [HttpGet]
        [Route("SearchRoute")]
        public async Task<Journey> Get(string origin, string destination)
        {

            var FlightsRaw = await Services.GetSearchFlight();
            if (FlightsRaw != null)
            {
                Flights = new List<SearchFlightsResponse>(FlightsRaw);
                List<SearchFlightsResponse> route = Flights.Where(f => f.DepartureStation == origin).ToList();

                var SumPrice = 0.0;

                for (int i = 0; i < route.Count; i++)
                {
                    NewOrigin.Add(new Flight
                    {
                        Origin = Flights[i].DepartureStation,
                        Destination = Flights[i].ArrivalStation,
                        Price = Flights[i].Price,
                        Transport = new Transport()
                        {
                            FlightCarrier = Flights[i].FlightCarrier,
                            FlightNumber = Flights[i].FlightNumber
                        }
                    });
                }


                for (int i = 0; i < Flights.Count; i++)
                {
                    if (Flights[i].ArrivalStation == destination)
                    {
                        RouteOrigin = Flights[i].DepartureStation;

                        for (int J = 0; J < NewOrigin.Count; J++)
                        {
                            if (NewOrigin[J].Destination == RouteOrigin)
                            {
                                flights.Add(new Flight
                                {
                                    Origin = Flights[J].DepartureStation,
                                    Destination = Flights[J].ArrivalStation,
                                    Price = Flights[J].Price,
                                    Transport = new Transport()
                                    {
                                        FlightCarrier = Flights[J].FlightCarrier,
                                        FlightNumber = Flights[J].FlightNumber
                                    }
                                });
                                SumPrice += Flights[J].Price;

                            }
                        }
                        flights.Add(new Flight
                        {
                            Origin = Flights[i].DepartureStation,
                            Destination = Flights[i].ArrivalStation,
                            Price = Flights[i].Price,
                            Transport = new Transport()
                            {
                                FlightCarrier = Flights[i].FlightCarrier,
                                FlightNumber = Flights[i].FlightNumber
                            }
                        });
                        SumPrice += Flights[i].Price;

                    }
                }

                var response = new Journey()
                {
                    Origin = origin,
                    Destination = destination,
                    Price = SumPrice,
                    Flights = flights

                };
                Ok();
                return response;
            }
            else
            {
                var response = new Journey();
                return response;
            }

        }

    }
}