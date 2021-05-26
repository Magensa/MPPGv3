using Magensa.MPPGv3.ServiceClient;
using Microsoft.Extensions.Configuration;
using MPPGv3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace MPPGv3.ServiceFactory
{
    public class ProcessEMVSREDClient : IProcessEMVSREDClient
    {
        private readonly IConfiguration _config;
        public Uri Host { get; private set; }
        public ProcessEMVSREDClient(IConfiguration config)
        {
            _config = config;
            Host = new Uri(_config.GetValue<string>(Constants.MPPGV3SERVICEURL));
        }
        public (ProcessEMVSREDResponseDto Response, RawSoapDetails SoapDetails) ProcessEMVSRED(ProcessEMVSREDRequestDto dto)
        {
            (ProcessEMVSREDResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);

            try
            {
                var requests = new List<ProcessEMVSREDRequest>();
                var request = new ProcessEMVSREDRequest
                {
                    AdditionalRequestData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("NonremovableTags",dto.NonremovableTags),
                        new KeyValuePair<string, string>("PayloadResponseFieldsToMask",dto.PayloadResponseFieldsToMask),
                    }.ToArray(),
                    Authentication = new Authentication
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    CustomerTransactionID = dto.CustomerTransactionID,
                    EMVSREDInput = new EMVSREDInput
                    {
                        EMVSREDData = dto.EMVSREDData,
                        EncryptionType = dto.EncryptionType,
                        KSN = dto.KSN,
                        NumberOfPaddedBytes = dto.NumberOfPaddedBytes,
                        PaymentMode = (PaymentMode)Enum.Parse(typeof(PaymentMode), dto.PaymentMode, true)
                    },
                    TransactionInput = new TransactionInput
                    {
                        Amount = dto.Amount,
                        ProcessorName = dto.ProcessorName,
                        TransactionInputDetails = new List<KeyValuePair<string, string>> { }.ToArray(),
                        TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), dto.TransactionType, true)
                    }
                };
                requests.Add(request);

                var svcEndPointAddress = new EndpointAddress(Host);
                var svcEncPointConfig = MPPGv3ServiceClient.EndpointConfiguration.BasicHttpsBinding_IMPPGv3Service;
                var svcClient = new MPPGv3ServiceClient(svcEncPointConfig, svcEndPointAddress);
                var requestInterceptorBehavior = new MppgInspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = svcClient.ProcessEMVSREDAsync(requests.ToArray()).Result;

                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptorBehavior.LastRequestXML,
                    ResponseXml = requestInterceptorBehavior.LastResponseXML
                };

                var svcResponse_0 = svcResponse.FirstOrDefault();
                if (svcResponse_0 != null)
                {
                    result.Response = new ProcessEMVSREDResponseDto
                    {
                        CustomerTransactionID = svcResponse_0.CustomerTransactionID,
                        EMVSREDOutput = new Dtos.EMVSREDOutput
                        {
                            AdditionalOutputData = svcResponse_0.EMVSREDOutput?.AdditionalOutputData,
                            CardID = svcResponse_0.EMVSREDOutput?.CardID,
                            IsReplay = svcResponse_0.EMVSREDOutput?.IsReplay
                        },
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
                            TransactionOutputDetails = new Dtos.TransactionOutputDetails()
                            {
                                ProcessorResponse = svcResponse_0.TransactionOutput?.TransactionOutputDetails?[0].Value
                            },
                            TransactionStatus = svcResponse_0.TransactionOutput?.TransactionStatus,
                        }
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
