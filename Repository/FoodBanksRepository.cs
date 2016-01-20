using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using FoodBanksMVC.Contracts;
using FoodBanksMVC.Models;
using RestSharp;

namespace FoodBanksMVC.Repository
{
    public class FoodBanksRepository : IFoodBanksRepository
    {
        #region Properties

        private Exception LastError { get; set; }

        private static string AuthorizationInformation
        {
            get
            {
                return ConfigurationManager.AppSettings[ "Authorization" ];
            }
        }

        #endregion

        #region Constructor(s)

        public FoodBanksRepository()
        {

        }

        #endregion

        #region Private Methods



        #endregion

        public HomeModel GetStatistics()
        {
            var retVal = new HomeModel();

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Statistics/", Method.GET );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                var response = client.Execute<JsonReturn>( request );

                if ( response != null && response.Data != null )
                {
                    var result = ( System.Collections.Generic.Dictionary<string, object> )response.Data.Result;

                    retVal.TotalDonations = int.Parse( result[ "totalDonations" ].ToString() );
                    retVal.TotalFoodBanks = int.Parse( result[ "totalFoodBanks" ].ToString() );
                    retVal.TotalVolunteers = int.Parse( result[ "totalVolunteers" ].ToString() );
                }
            }
            catch ( Exception ex )
            {
                retVal = new HomeModel();
            }

            return retVal;
        }

        public FoodBanksModel GetFoodBanks( int start = 0, int total = 5 )
        {
            var retVal = new FoodBanksModel();

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/FoodBanks/", Method.GET );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddParameter( "offset", start );
                request.AddParameter( "limit", total );
                var response = client.Execute<JsonReturn>( request );

                if ( response != null && response.Data != null )
                {
                    JsonReturn jReturn = response.Data;
                    var data = ( RestSharp.JsonArray )jReturn.Result;

                    //Main data.
                    var banks = new List<FoodBank>();
                    foreach ( var item in data )
                    {
                        var result = ( System.Collections.Generic.Dictionary<string, object> )item;
                        var bank = new FoodBank();

                        if ( result[ "addr1" ] != null )
                            bank.Addr1 = result[ "addr1" ].ToString();

                        if ( result[ "addr2" ] != null )
                            bank.Addr2 = result[ "addr2" ].ToString();

                        if ( result[ "city" ] != null )
                            bank.City = result[ "city" ].ToString();

                        if ( result[ "created" ] != null )
                            bank.Created = DateTime.Parse( result[ "created" ].ToString() );

                        if ( result[ "donationCount" ] != null )
                            bank.DonationCount = int.Parse( result[ "donationCount" ].ToString() );

                        if ( result[ "id" ] != null )
                            bank.Id = int.Parse( result[ "id" ].ToString() );

                        if ( result[ "name" ] != null )
                            bank.Name = result[ "name" ].ToString();

                        if ( result[ "postal" ] != null )
                            bank.Postal = result[ "postal" ].ToString();

                        if ( result[ "state" ] != null )
                            bank.State = result[ "state" ].ToString();

                        if ( result[ "volunteerCount" ] != null )
                            bank.VolunteerCount = int.Parse( result[ "volunteerCount" ].ToString() );

                        banks.Add( bank );
                    }

                    retVal.Links = ( List<Link> )jReturn.Links;//Links.

                    //Get header(s).
                    foreach(var header in response.Headers)
                    {
                        if (header.Name != "X-Total-Count") continue;
                        retVal.TotalFoodBanks = int.Parse( header.Value.ToString() );
                        break;
                    }

                    retVal.FoodBanks = banks;
                }
            }
            catch ( Exception ex )
            {
                retVal = new FoodBanksModel();
            }

            return retVal;
        }

        public bool CreateFoodBank( FoodBank foodBank )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/FoodBanks/", Method.POST );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddJsonBody( foodBank );

                var response = client.Execute<JsonReturn>( request );

                if ( response != null && response.Data != null )
                    retVal = true;
            }
            catch ( Exception ex )
            {
                LastError = ex;
            }

            return retVal;
        }

        public FoodBanksModel GetFoodBank( int id )
        {
            var retVal = new FoodBanksModel();

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/FoodBanks/" + id, Method.GET );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                var response = client.Execute<JsonReturn>( request );

                if ( response != null && response.Data != null )
                {
                    JsonReturn jReturn = response.Data;
                    var result = ( System.Collections.Generic.Dictionary<string, object> )jReturn.Result;
                    retVal.FoodBank = new FoodBank();

                    if ( result[ "addr1" ] != null )
                        retVal.FoodBank.Addr1 = string.IsNullOrEmpty( result[ "addr1" ].ToString() ) ? "" : result[ "addr1" ].ToString();

                    if ( result[ "addr2" ] != null )
                        retVal.FoodBank.Addr2 = result[ "addr2" ].ToString();

                    if ( result[ "city" ] != null )
                        retVal.FoodBank.City = result[ "city" ].ToString();

                    if ( result[ "created" ] != null )
                        retVal.FoodBank.Created = DateTime.Parse( result[ "created" ].ToString() );

                    if ( result[ "donationCount" ] != null )
                        retVal.FoodBank.DonationCount = int.Parse( result[ "donationCount" ].ToString() );

                    if ( result[ "id" ] != null )
                        retVal.FoodBank.Id = int.Parse( result[ "id" ].ToString() );

                    if ( result[ "name" ] != null )
                        retVal.FoodBank.Name = result[ "name" ].ToString();

                    if ( result[ "postal" ] != null )
                        retVal.FoodBank.Postal = result[ "postal" ].ToString();

                    if ( result[ "state" ] != null )
                        retVal.FoodBank.State = result[ "state" ].ToString();

                    if ( result[ "volunteerCount" ] != null )
                        retVal.FoodBank.VolunteerCount = int.Parse( result[ "volunteerCount" ].ToString() );
                }
            }
            catch ( Exception ex )
            {
                retVal = new FoodBanksModel();
            }

            return retVal;
        }

        public bool UpdateFoodBank( FoodBank foodBank )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/FoodBanks/", Method.PUT );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddJsonBody( foodBank );

                var response = client.Execute( request );
                if ( response != null && response.StatusCode == HttpStatusCode.OK )
                    retVal = true;
                else
                    retVal = false;
            }
            catch ( Exception ex )
            {
                LastError = ex;
            }

            return retVal;
        }

        public bool DeleteFoodBank( int id )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/FoodBanks/" + id + "/", Method.DELETE );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );

                var response = client.Execute<JsonReturn>( request );

                if ( response != null && response.Data != null )
                {
                    JsonReturn jReturn = response.Data;
                    retVal = ( bool )jReturn.Result;
                }
            }
            catch ( Exception ex )
            {
                //TODO: Log error.
            }

            return retVal;
        }


    }
}