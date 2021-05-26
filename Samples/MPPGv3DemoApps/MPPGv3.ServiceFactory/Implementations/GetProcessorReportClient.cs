using Magensa.MPPGv3.ServiceClient;
using Microsoft.Extensions.Configuration;
using MPPGv3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace MPPGv3.ServiceFactory
{
    public class GetProcessorReportClient : IGetProcessorReportClient
    {
        private IConfiguration _config;
        public Uri Host { get; private set; }
        public GetProcessorReportClient(IConfiguration config)
        {
            _config = config;
            Host = new Uri(_config.GetValue<string>(Constants.MPPGV3SERVICEURL));
        }
        public (GetProcessorReportResponseDto Response, RawSoapDetails SoapDetails) GetProcessorReport(GetProcessorReportRequestDto dto)
        {
            (GetProcessorReportResponseDto Response, RawSoapDetails SoapDetails) result = (null, null);

            try
            {
                var requests = new List<GetProcessorReportRequest>();
                var request = new GetProcessorReportRequest()
                {
                    AdditionalRequestData = new List<KeyValuePair<string, string>> { }.ToArray(),
                    Authentication = new Authentication
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    CustomerTransactionID = dto.CustomerTransactionID,
                    TransactionInput = new TransactionInput
                    {
                        Amount = dto.Amount,
                        ProcessorName = dto.ProcessorName,
                        TransactionInputDetails = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("TransactionID",dto.TransactionID)
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
                var svcResponse = svcClient.GetProcessorReportAsync(requests.ToArray()).Result;

                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;

                var svcResponse_0 = svcResponse.FirstOrDefault();
                if (svcResponse_0 != null)
                {
                    result.Response = new GetProcessorReportResponseDto
                    {
                        CustomerTransactionID = svcResponse_0.CustomerTransactionID,
                        MagTranID = svcResponse_0.MagTranID,
                        TransactionOutput = new Dtos.TransactionOutput
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
                            TransactionOutputDetails = new TransactionOutputDetails
                            {
                                ProcessorResponse = svcResponse_0.TransactionOutput?.TransactionOutputDetails?.FirstOrDefault().Value
                            },
                            TransactionStatus = svcResponse_0.TransactionOutput?.TransactionStatus
                        },
                        TransactionUTCTimestamp = svcResponse_0.TransactionUTCTimestamp
                    };
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
