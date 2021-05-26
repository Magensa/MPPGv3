using Magensa.MPPGv3.ServiceClient;
using Microsoft.Extensions.Configuration;
using MPPGv3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace MPPGv3.ServiceFactory
{
    public class ProcessCardSwipeClient : IProcessCardSwipeClient
    {
        private IConfiguration _config;
        public Uri Host { get; private set; }
        public ProcessCardSwipeClient(IConfiguration config)
        {
            _config = config;
            Host = new Uri(_config.GetValue<string>(Constants.MPPGV3SERVICEURL));
        }
        public (ProcessCardSwipeResponseDto Response, RawSoapDetails SoapDetails) ProcessCardSwipe(ProcessCardSwipeRequestDto dto)
        {
            (ProcessCardSwipeResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
            result.Response = new ProcessCardSwipeResponseDto();
            result.SoapDetails = new RawSoapDetails();
            try
            {
                var requests = new List<ProcessCardSwipeRequest>();
                var request = new ProcessCardSwipeRequest
                {
                    AdditionalRequestData = new List<KeyValuePair<string, string>>().ToArray(),
                    Authentication = new Authentication
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    CustomerTransactionID = dto.CustomerTransactionID,
                    CardSwipeInput = new CardSwipeInput
                    {
                        CVV = dto.Cvv,
                        EncryptedCardSwipe = new EncryptedCardSwipe
                        {
                            DeviceSN = dto.DeviceSN,
                            KSN = dto.KSN,
                            MagnePrint = dto.MagnePrint,
                            MagnePrintStatus = dto.MagnePrintStatus,
                            Track1 = dto.Track1,
                            Track2 = dto.Track2,
                            Track3 = dto.Track3
                        },
                        ZIP = ""
                    },
                    TransactionInput = new TransactionInput
                    {
                        Amount = dto.Amount,
                        ProcessorName = dto.ProcessorName,
                        TransactionInputDetails = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("Payload",dto.Payload)
                        }.ToArray(),
                        TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), dto.TransactionType, true)
                    }
                };
                requests.Add(request);

                var svcEndPointAddress = new EndpointAddress(Host);
                var svcEncPointConfig = MPPGv3ServiceClient.EndpointConfiguration.BasicHttpsBinding_IMPPGv3Service;
                var svcClient = new MPPGv3ServiceClient(svcEncPointConfig, svcEndPointAddress);
                var requestInterceptorBehavior = new MppgInspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = svcClient.ProcessCardSwipeAsync(requests.ToArray()).Result;
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;

                var svcResponse_0 = svcResponse.FirstOrDefault();
                if (svcResponse_0 != null)
                {
                    result.Response.CardSwipeOutput = new Dtos.CardSwipeOutput
                    {
                        AdditionalOutputData = svcResponse_0.CardSwipeOutput?.AdditionalOutputData,
                        CardID = svcResponse_0.CardSwipeOutput?.CardID,
                        IsReplay = svcResponse_0.CardSwipeOutput?.IsReplay,
                        MagnePrintScore = svcResponse_0.CardSwipeOutput?.MagnePrintScore
                    };
                    result.Response.CustomerTransactionID = svcResponse_0.CustomerTransactionID;
                    result.Response.MagTranID = svcResponse_0.MagTranID;
                    result.Response.TransactionOutput = new Dtos.TransactionOutput
                    {
                        AuthCode = svcResponse_0.TransactionOutput?.AuthCode,
                        AVSResult = svcResponse_0.TransactionOutput?.AVSResult,
                        AuthorizedAmount = svcResponse_0.TransactionOutput?.AuthorizedAmount,
                        CVVResult = svcResponse_0.TransactionOutput?.CVVResult,
                        IsTransactionApproved = svcResponse_0.TransactionOutput?.IsTransactionApproved,
                        IssuerAuthenticationData = svcResponse_0.TransactionOutput?.IssuerAuthenticationData,
                        IssuerScriptTemplate1 = svcResponse_0.TransactionOutput?.IssuerScriptTemplate1,
                        IssuerScriptTemplate2 = svcResponse_0.TransactionOutput?.IssuerScriptTemplate2,
                        Token = svcResponse_0.TransactionOutput?.Token,
                        TransactionID = svcResponse_0.TransactionOutput?.TransactionID,
                        TransactionMessage = svcResponse_0.TransactionOutput?.TransactionMessage,
                        TransactionOutputDetails = new Dtos.TransactionOutputDetails
                        {
                            ProcessorResponse = svcResponse_0.TransactionOutput?.TransactionOutputDetails?[0].Value
                        },
                        TransactionStatus = svcResponse_0.TransactionOutput?.TransactionStatus
                    };
                    result.Response.TransactionUTCTimestamp = svcResponse_0.TransactionUTCTimestamp;
                }

            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
    }
}
