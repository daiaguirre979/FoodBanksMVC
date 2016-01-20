using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using FoodBanksMVC.Contracts;
using FoodBanksMVC.Models;
using RestSharp;

namespace FoodBanksMVC.Repository
{
    public class DonationsRepository : IDonationssRepository
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

        public DonationsRepository()
        {

        }

        #endregion

        #region Private Methods



        #endregion
        
        public DonationsModel GetDonations( int start = 0, int total = 5 )
        {
            var retVal = new DonationsModel();

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Donations/", Method.GET );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddParameter( "offset", start );
                request.AddParameter( "limit", total );
                var response = client.Execute<JsonReturn>( request );

                if ( response != null && response.Data != null )
                {
                    JsonReturn jReturn = response.Data;
                    var data = ( RestSharp.JsonArray )jReturn.Result;

                    //Main data.
                    var donations = new List<Donation>();
                    foreach ( var item in data )
                    {
                        var result = ( System.Collections.Generic.Dictionary<string, object> )item;
                        var donation = new Donation();

                        if ( result[ "foodBankName" ] != null )
                            donation.FoodBankName = result[ "foodBankName" ].ToString();

                        if ( result[ "foodBankId" ] != null )
                            donation.FoodBankId = int.Parse( result[ "foodBankId" ].ToString());

                        if ( result[ "item" ] != null )
                            donation.Item = result[ "item" ].ToString();

                        if ( result[ "created" ] != null )
                            donation.Created = DateTime.Parse( result[ "created" ].ToString() );

                        if ( result[ "quality" ] != null )
                            donation.Quality = int.Parse( result[ "quality" ].ToString() );

                        if ( result[ "id" ] != null )
                            donation.Id = int.Parse( result[ "id" ].ToString() );

                        if ( result[ "quantity" ] != null )
                            donation.Quantity = int.Parse( result[ "quantity" ].ToString());

                        if ( result[ "volunteerId" ] != null )
                            donation.VolunteerId = int.Parse( result[ "volunteerId" ].ToString());

                        if ( result[ "volunteerName" ] != null )
                            donation.VolunteerName = result[ "volunteerName" ].ToString();
                        
                        donations.Add( donation );
                    }

                    retVal.Links = ( List<Link> )jReturn.Links;//Links.

                    //Get header(s).
                    foreach ( var header in response.Headers )
                    {
                        if ( header.Name != "X-Total-Count" ) continue;
                        retVal.TotalDonations = int.Parse( header.Value.ToString() );
                        break;
                    }

                    retVal.Donations = donations;
                }
            }
            catch ( Exception ex )
            {
                retVal = new DonationsModel();
            }

            return retVal;
        }

        public bool CreateDonation( Donation donation )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Donations/", Method.POST );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddJsonBody( donation );

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

        public DonationsModel GetDonation( int id )
        {
            var retVal = new DonationsModel();

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Donations/" + id, Method.GET );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                var response = client.Execute<JsonReturn>( request );

                if ( response != null && response.Data != null )
                {
                    JsonReturn jReturn = response.Data;
                    var result = ( System.Collections.Generic.Dictionary<string, object> )jReturn.Result;
                    retVal.Donation = new Donation();

                    if ( result[ "foodBankName" ] != null )
                        retVal.Donation.FoodBankName = result[ "foodBankName" ].ToString();

                    if ( result[ "foodBankId" ] != null )
                        retVal.Donation.FoodBankId = int.Parse( result[ "foodBankId" ].ToString() );

                    if ( result[ "item" ] != null )
                        retVal.Donation.Item = result[ "item" ].ToString();

                    if ( result[ "created" ] != null )
                        retVal.Donation.Created = DateTime.Parse( result[ "created" ].ToString() );

                    if ( result[ "quality" ] != null )
                        retVal.Donation.Quality = int.Parse( result[ "quality" ].ToString() );

                    if ( result[ "id" ] != null )
                        retVal.Donation.Id = int.Parse( result[ "id" ].ToString() );

                    if ( result[ "quantity" ] != null )
                        retVal.Donation.Quantity = int.Parse( result[ "quantity" ].ToString() );

                    if ( result[ "volunteerId" ] != null )
                        retVal.Donation.VolunteerId = int.Parse( result[ "volunteerId" ].ToString() );

                    if ( result[ "volunteerName" ] != null )
                        retVal.Donation.VolunteerName = result[ "volunteerName" ].ToString();
                }
            }
            catch ( Exception ex )
            {
                retVal = new DonationsModel();
            }

            return retVal;
        }

        public bool UpdateDonation( Donation Donation )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Donations/", Method.PUT );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddJsonBody( Donation );

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

        public bool DeleteDonation( int id )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Donations/" + id + "/", Method.DELETE );
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