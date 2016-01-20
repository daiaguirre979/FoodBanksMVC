using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using FoodBanksMVC.Contracts;
using FoodBanksMVC.Models;
using RestSharp;

namespace FoodBanksMVC.Repository
{
    public class VolunteersRepository:IVolunteersRepository
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

        public VolunteersRepository()
        {

        }

        #endregion

        #region Private Methods



        #endregion

        public VolunteersModel GetVolunteers( int start = 0, int total = 5 )
        {
            var retVal = new VolunteersModel();

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Volunteers/", Method.GET );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddParameter( "offset", start );
                request.AddParameter( "limit", total );
                var response = client.Execute<JsonReturn>( request );

                if ( response != null && response.Data != null )
                {
                    JsonReturn jReturn = response.Data;
                    var data = ( RestSharp.JsonArray )jReturn.Result;

                    //Main data.
                    var vols = new List<Volunteer>();
                    foreach ( var item in data )
                    {
                        var result = ( System.Collections.Generic.Dictionary<string, object> )item;
                        var vol = new Volunteer();

                        if ( result[ "dateOfBirth" ] != null )
                            vol.DateOfBirth = DateTime.Parse( result[ "dateOfBirth" ].ToString() );

                        if ( result[ "created" ] != null )
                            vol.Created = DateTime.Parse( result[ "created" ].ToString() );

                        if ( result[ "id" ] != null )
                            vol.Id = int.Parse( result[ "id" ].ToString() );

                        if ( result[ "name" ] != null )
                            vol.Name = result[ "name" ].ToString();

                        if ( result[ "foodBankId" ] != null )
                            vol.FoodBankId = int.Parse( result[ "foodBankId" ].ToString() );

                        if ( result[ "foodBankName" ] != null )
                            vol.FoodBankName = result[ "foodBankName" ].ToString();

                        vols.Add( vol );
                    }

                    retVal.Links = ( List<Link> )jReturn.Links;//Links.

                    //Get header(s).
                    foreach ( var header in response.Headers )
                    {
                        if ( header.Name != "X-Total-Count" ) continue;
                        retVal.TotalVolunteers = int.Parse( header.Value.ToString() );
                        break;
                    }

                    retVal.Volunteers = vols;
                }
            }
            catch ( Exception ex )
            {
                retVal = new VolunteersModel();
            }

            return retVal;
        }

        public bool CreateVolunteer( Volunteer volunteer )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Volunteers/", Method.POST );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddJsonBody( volunteer );

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

        public VolunteersModel GetVolunteer( int id )
        {
            var retVal = new VolunteersModel();

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Volunteers/" + id, Method.GET );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                var response = client.Execute<JsonReturn>( request );
                
                if ( response != null && response.Data != null )
                {
                    JsonReturn jReturn = response.Data;
                    var result = ( System.Collections.Generic.Dictionary<string, object> )jReturn.Result;
                    retVal.Volunteer = new Volunteer();

                    if ( result[ "name" ] != null )
                        retVal.Volunteer.Name = result[ "name" ].ToString();

                    if ( result[ "foodBankName" ] != null )
                        retVal.Volunteer.FoodBankName = result[ "foodBankName" ].ToString();

                    if ( result[ "dateOfBirth" ] != null )
                        retVal.Volunteer.DateOfBirth = DateTime.Parse( result[ "dateOfBirth" ].ToString() );

                    if ( result[ "created" ] != null )
                        retVal.Volunteer.Created = DateTime.Parse( result[ "created" ].ToString() );

                    if ( result[ "foodBankId" ] != null )
                        retVal.Volunteer.FoodBankId = int.Parse( result[ "foodBankId" ].ToString() );

                    if ( result[ "id" ] != null )
                        retVal.Volunteer.Id = int.Parse( result[ "id" ].ToString() );                    
                }
            }
            catch ( Exception ex )
            {
                retVal = new VolunteersModel();
            }

            return retVal;
        }

        public bool UpdateVolunteer( Volunteer volunteer )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Volunteers/", Method.PUT );
                request.AddParameter( "Authorization", AuthorizationInformation, ParameterType.HttpHeader );
                request.AddJsonBody( volunteer );

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

        public bool DeleteVolunteer( int id )
        {
            var retVal = false;

            try
            {
                var client = new RestClient( ConfigurationManager.AppSettings[ "WebApiBaseUrlV1" ] );
                var request = new RestRequest( "api/v1/Volunteers/" + id + "/", Method.DELETE );
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