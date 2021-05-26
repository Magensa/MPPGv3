using Microsoft.Extensions.DependencyInjection;
using MPPGv3.Dtos;
using MPPGv3.ServiceFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MPPGv3.UIFactory
{
    public class Mppgv3UIfactory : IMppgv3UIFactory
    {
        IServiceProvider _serviceProvider;
        public Mppgv3UIfactory(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }
        public void ShowUI(MPPGv3UI mPPGv3UI)
        {
            switch (mPPGv3UI)
            {
                case MPPGv3UI.PROCESSCARDSWIPE:
                    ShowProcessCardSwipeUI();
                    break;
                case MPPGv3UI.PROCESSMANUALENTRY:
                    ShowProcessManualEntryUI();
                    break;
                case MPPGv3UI.PROCESSKEYPADENTRY:
                    ShowProcessKeyPadEntryUI();
                    break;
                case MPPGv3UI.PROCESSTOKEN:
                    ShowProcessTokenUI();
                    break;
                case MPPGv3UI.PROCESSREFERENCEID:
                    ShowProcessReferenceIDUI();
                    break;
                case MPPGv3UI.GETPROCESSORREPORT:
                    ShowGetProcessorReport();
                    break;
                case MPPGv3UI.PROCESSEMVSRED:
                    ShowProcessEMVSRED();
                    break;
                case MPPGv3UI.PROCESSENCRYPTEDMANUALENTRY:
                    ShowProcessEncryptedManualEntry();
                    break;
                default:
                    break;
            }
        }
        private void ShowProcessCardSwipeUI()
        {
            var requestDto = new ProcessCardSwipeRequestDto();
            try
            {
                requestDto.CustomerCode = Read_Mandatory_String_Input("CustomerCode");
                requestDto.Username = Read_Mandatory_String_Input("Username");
                requestDto.Password = Read_Mandatory_String_Input("PassWord");
                requestDto.Cvv = Read_Intuser_Input("Cvv").ToString();
                requestDto.DeviceSN = Read_Mandatory_String_Input("DeviceSN");
                requestDto.KSN = Read_Mandatory_String_Input("KSN");
                requestDto.MagnePrint = Read_Mandatory_String_Input("MagnePrint");
                requestDto.MagnePrintStatus = Read_Mandatory_String_Input("MagnePrintStatus");
                requestDto.Track1 = Read_Mandatory_String_Input("Track1");
                requestDto.Track2 = Read_Mandatory_String_Input("Track2");
                requestDto.Track3 = Read_Optional_String_Input("Track3");
                requestDto.CustomerTransactionID = Read_Optional_String_Input("CustomerTransactionID");
                requestDto.Amount = Read_Decimal_Input("Amount");
                requestDto.ProcessorName = Read_Mandatory_String_Input("ProcessorName");
                requestDto.Payload = Read_Mandatory_String_Input("Payload");
                requestDto.TransactionType = Read_TransactionType_Input("TransactionType");
                var svc = _serviceProvider.GetService<IProcessCardSwipeClient>();
                var result = svc.ProcessCardSwipe(requestDto);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred while Processing ProcessCardSwipe" + ex.Message.ToString());
            }
        }
        private void ShowProcessKeyPadEntryUI()
        {
            var requestDto = new ProcessKeyPadEntryRequestDto();
            try
            {
                requestDto.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                requestDto.CustomerCode = Read_Mandatory_String_Input("Customer Code");
                requestDto.Username = Read_Mandatory_String_Input("Username");
                requestDto.Password = Read_Mandatory_String_Input("PassWord");
                requestDto.CVV = Read_Mandatory_String_Input("CVV");
                requestDto.DeviceSN = Read_Mandatory_String_Input("DeviceSN");
                requestDto.KSN = Read_Mandatory_String_Input("KSN");
                requestDto.MagnePrint = Read_Mandatory_String_Input("MagnePrint");
                requestDto.MagnePrintStatus = Read_Mandatory_String_Input("MagnePrintStatus");
                requestDto.Track1 = Read_Optional_String_Input("Track1");
                requestDto.Track2 = Read_Mandatory_String_Input("Track2");
                requestDto.Track3 = Read_Optional_String_Input("Track3");
                requestDto.ZIP = Read_Optional_String_Input("Zip");
                requestDto.CustomerTransactionID = Read_Optional_String_Input("CustomerTransactionId");
                requestDto.Amount = Read_Decimal_Input("Amount");
                requestDto.ProcessorName = Read_Mandatory_String_Input("ProcessorName");
                requestDto.TransactionInputDetails = Read_MultipleKeysInput("TransactionInputDetails");
                requestDto.TransactionType = Read_TransactionType_Input("TransactionType");
                var svc = _serviceProvider.GetService<IProcessKeyPadEntryClient>();
                var result = svc.ProcessKeyPadEntry(requestDto);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Occurred while Processing ProcessKeyPadEntry" + ex.Message.ToString());
            }
        }
        private void ShowProcessTokenUI()
        {
            var requestDto = new ProcessTokenRequestDto();
            try
            {
                requestDto.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                requestDto.CustomerCode = Read_Mandatory_String_Input("Customer Code");
                requestDto.Username = Read_Mandatory_String_Input("Username");
                requestDto.Password = Read_Mandatory_String_Input("PassWord");
                requestDto.CustomerTransactionID = Read_Optional_String_Input("CustomerTransactionId");
                requestDto.Token = Read_Mandatory_String_Input("Token");
                requestDto.Amount = Read_Decimal_Input("Amount");
                requestDto.ProcessorName = Read_Mandatory_String_Input("ProcessorName");
                requestDto.TransactionInputDetails = Read_MultipleKeysInput("TransactionInputDetails");
                requestDto.TransactionType = Read_TransactionType_Input("TransactionType");
                var svc = _serviceProvider.GetService<IProcessTokenClient>();
                var result = svc.ProcessToken(requestDto);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Occurred while Processing ProcessToken" + ex.Message.ToString());
            }
        }
        private void ShowProcessManualEntryUI()
        {
            var requestDto = new ProcessManualEntryRequestDto();
            try
            {
                requestDto.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                requestDto.CustomerCode = Read_Mandatory_String_Input("Customer Code");
                requestDto.Username = Read_Mandatory_String_Input("Username");
                requestDto.Password = Read_Mandatory_String_Input("PassWord");
                requestDto.CustomerTransactionID = Read_Optional_String_Input("CustomerTransactionId");
                requestDto.AddressLine1 = Read_Optional_String_Input("AddressLine1");
                requestDto.AddressLine2 = Read_Optional_String_Input("AddressLine2");
                requestDto.City = Read_Optional_String_Input("City");
                requestDto.Country = Read_Optional_String_Input("Country");
                requestDto.ExpirationDate = Read_ExpirationDateuser_Input("Expiration Date:", "Year(Ex:For Year 2025 Enter 25):", "Month:(Int Between 1-12 Ex: For 3 Enter 03 )");
                requestDto.NameOnCard = Read_Optional_String_Input("NameOnCard");
                requestDto.PAN = Read_Mandatory_String_Input("PAN");
                requestDto.State = Read_Optional_String_Input("State");
                requestDto.Zip = Read_Optional_String_Input("Zip");
                requestDto.Amount = Read_Decimal_Input("Amount");
                requestDto.ProcessorName = Read_Mandatory_String_Input("ProcessorName");
                requestDto.TransactionType = Read_TransactionType_Input("TransactionType");
                requestDto.TransactionInputDetails = Read_MultipleKeysInput("TransactionInputDetails");
                var svc = _serviceProvider.GetService<IProcessManualEntryClient>();
                var result = svc.ProcessManualEntry(requestDto);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Occurred while Processing ProcessManualEntry" + ex.Message.ToString());
            }
        }
        private void ShowGetProcessorReport()
        {
            var requestDto = new GetProcessorReportRequestDto();
            try
            {
                requestDto.CustomerCode = Read_Mandatory_String_Input("CustomerCode");
                requestDto.Username = Read_Mandatory_String_Input("Username");
                requestDto.Password = Read_Mandatory_String_Input("Password");
                requestDto.CustomerTransactionID = Read_Optional_String_Input("CustomerTransactionID");
                requestDto.Amount = Read_Decimal_Input("Amount");
                requestDto.ProcessorName = Read_Mandatory_String_Input("ProcessorName");
                requestDto.TransactionID = Read_Mandatory_String_Input("TransactionID");
                requestDto.TransactionType = Read_TransactionType_Input("TransactionType:");
                var svc = _serviceProvider.GetService<IGetProcessorReportClient>();
                var result = svc.GetProcessorReport(requestDto);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred while Processing GetProcessorReport" + ex.Message.ToString());
            }
        }
        private void ShowProcessReferenceIDUI()
        {
            var requestDto = new ProcessReferenceIDRequestDto();
            try
            {
                requestDto.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                requestDto.CustomerCode = Read_Mandatory_String_Input("CustomerCode");
                requestDto.Username = Read_Mandatory_String_Input("Username");
                requestDto.Password = Read_Mandatory_String_Input("Password");
                requestDto.CustomerTransactionID = Read_Optional_String_Input("CustomerTransactionID");
                requestDto.Amount = Read_Decimal_Input("Amount");
                requestDto.ProcessorName = Read_Mandatory_String_Input("ProcessorName");
                requestDto.ReferenceAuthCode = Read_Mandatory_String_Input("ReferenceAuthCode");
                requestDto.ReferenceTransactionID = Read_Mandatory_String_Input("ReferenceTransactionID");
                requestDto.TransactionInputDetails = Read_MultipleKeysInput("TransactionInputDetails");
                requestDto.TransactionType = Read_TransactionType_Input("TransactionType");
                var svc = _serviceProvider.GetService<IProcessReferenceIDClient>();
                var result = svc.ProcessReferenceID(requestDto);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred while Processing ProcessReferenceID" + ex.Message.ToString());
            }

        }
        private void ShowProcessEMVSRED()
        {
            var requestDto = new ProcessEMVSREDRequestDto();
            try
            {
                requestDto.NonremovableTags = Read_Mandatory_String_Input("NonremovableTags");
                requestDto.PayloadResponseFieldsToMask = Read_Mandatory_String_Input("PayloadResponseFieldsToMask");
                requestDto.CustomerCode = Read_Mandatory_String_Input("CustomerCode");
                requestDto.Username = Read_Mandatory_String_Input("Username");
                requestDto.Password = Read_Mandatory_String_Input("Password");
                requestDto.CustomerTransactionID = Read_Mandatory_String_Input("CustomerTransactionID");
                requestDto.EMVSREDData = Read_Optional_String_Input("EMVSREDData");
                requestDto.EncryptionType = Read_Optional_String_Input("EncryptionType");
                requestDto.KSN = Read_Optional_String_Input("KSN");
                requestDto.NumberOfPaddedBytes = Read_Intuser_Input("NumberOfPaddedBytes");
                requestDto.PaymentMode = Read_PaymentMode_Input("PaymentMode");
                requestDto.Amount = Read_Decimal_Input("Amount");
                requestDto.ProcessorName = Read_Optional_String_Input("ProcessorName");
                requestDto.TransactionType = Read_TransactionType_Input("TransactionType");
                var svc = _serviceProvider.GetService<IProcessEMVSREDClient>();
                var result = svc.ProcessEMVSRED(requestDto);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Occurred while Processing ProcessManualEntry" + ex.Message.ToString());
            }
        }
        private void ShowProcessEncryptedManualEntry()
        {
            var requestDto = new ProcessEncryptedManualEntryRequestDto();


            try
            {
                requestDto.CustomerCode = Read_Mandatory_String_Input("CustomerCode");
                requestDto.Username = Read_Mandatory_String_Input("Username");
                requestDto.Password = Read_Mandatory_String_Input("Password");
                requestDto.CustomerTransactionID = Read_Mandatory_String_Input("CustomerTransactionID");
                requestDto.EncryptedData = Read_Mandatory_String_Input("EncryptedData");
                requestDto.KSN = Read_Optional_String_Input("KSN");
                requestDto.KeyVariant = Read_KeyVariant_Input("KeyVariant");
                requestDto.NumberOfPaddedBytes = Read_Intuser_Input("NumberOfPaddedBytes");
                requestDto.Amount = Read_Decimal_Input("Amount");
                requestDto.ProcessorName = Read_Mandatory_String_Input("ProcessorName");
                requestDto.ExpirationDate = Read_ExpirationDateuser_Input("Expiration Date:", "Year(Ex:For Year 2025 Enter 25):", "Month:(Int Between 1-12 Ex: For 3 Enter 03 )");
                requestDto.TransactionType = Read_TransactionType_Input("TransactionType");
                var svc = _serviceProvider.GetService<IProcessEncryptedManualEntryClient>();
                var result = svc.ProcessEncryptedManualEntry(requestDto);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Occurred while Processing ProcessManualEntry" + ex.Message.ToString());
            }
        }
        private static string Read_LongString_Input(string question, bool isOptional)
        {
            Console.WriteLine($"{question}:");
            byte[] inputBuffer = new byte[262144];
            Stream inputStream = Console.OpenStandardInput(262144);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string strInput = Console.ReadLine();
            if ((!isOptional) && string.IsNullOrWhiteSpace(strInput))
            {
                return Read_LongString_Input(question, isOptional);
            }
            return strInput;
        }
        private static string Read_ExpirationDate_Yearuser_Input(string question)
        {
            Console.WriteLine($"{question}:");
            string answer = Console.ReadLine();
            if ((!string.IsNullOrWhiteSpace(answer)) && (answer.Length == 2) && answer.All(char.IsDigit))
            {
                return answer;
            }
            Console.WriteLine("Invalid Input.");
            return Read_ExpirationDate_Yearuser_Input(question);
        }
        public static bool Between(int num, int lower, int upper, bool inclusive = true)
        {
            return inclusive ? lower <= num && num <= upper : lower < num && num < upper;
        }
        private static string Read_ExpirationDate_Monthuser_Input(string question)
        {
            Console.WriteLine($"{question}:");
            var answer = Console.ReadLine();
            if ((!string.IsNullOrWhiteSpace(answer)) && (answer.Length == 2) && answer.All(char.IsDigit) && Between(int.Parse(answer), 1, 12))
            {
                return answer;
            }
            Console.WriteLine("Invalid Input.");
            return Read_ExpirationDate_Monthuser_Input(question);
        }
        private static string Read_ExpirationDateuser_Input(string question, string yearlabel, string monthlabel)
        {
            Console.WriteLine($"{question}:");
            string year = Read_ExpirationDate_Yearuser_Input(yearlabel);
            string month = Read_ExpirationDate_Monthuser_Input(monthlabel);
            string answer = year + month;
            return answer;
        }
        private static string Read_TransactionType_Input(string question)
        {
            var transactiontypes = new List<string> { "SALE", "AUTHORIZE", "CAPTURE", "VOID", "REFUND", "FORCE", "REJECT", "TOKEN", "REPORT" };
            Console.WriteLine($"{question}:");
            var ans = Console.ReadLine();
            if (transactiontypes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid TransactionType.");
                return Read_TransactionType_Input(question);
            }
        }
        private static string Read_KeyVariant_Input(string question)
        {
            var transactiontypes = new List<string> { "Pin", "Data" };
            Console.WriteLine($"{question}:");
            var ans = Console.ReadLine();
            if (transactiontypes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid Input.");
                return Read_KeyVariant_Input(question);
            }
        }
        private static string Read_PaymentMode_Input(string question)
        {
            var paymentmodes = new List<string> { "EMV", "MagStripe", "ManualEntry" };
            Console.WriteLine($"{question}:");
            var ans = Console.ReadLine();
            if (paymentmodes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid PaymentMode.");
                return Read_PaymentMode_Input(question);
            }
        }
        private static string Read_DataFormatType_Input(string question)
        {
            Console.WriteLine($"{question}:");
            var ans = Console.ReadLine();
            var dataformattypes = new List<string> { "TLV" };
            if (dataformattypes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid DataFormatType.");
                return Read_DataFormatType_Input(question);
            }
        }
        private static Decimal Read_Decimal_Input(string question)
        {
            Console.WriteLine($"{question}:");
            try
            {
                var ans = Console.ReadLine();
                var temp = Decimal.Parse(ans);
                return temp;
            }
            catch
            {
                Console.WriteLine("Invalid Input.");
                return Read_Decimal_Input(question);
            }
        }
        private static int Read_Intuser_Input(string question)
        {
            Console.WriteLine($"{question}:");
            var ans = Console.ReadLine();
            try
            {
                var temp = int.Parse(ans);
                return temp;
            }
            catch
            {
                Console.WriteLine("Invalid Input.");
                return Read_Intuser_Input(question);
            }
        }
        private static string Read_Isencrypted_Input(string question)
        {
            List<string> isencrypts = new List<string> { "true", "false" };
            Console.WriteLine($"{question}:");
            var ans = Console.ReadLine();
            if (isencrypts.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid Isencrypted value.");
                return Read_Isencrypted_Input(question);
            }
        }
        private static List<KeyValuePair<string, string>> Read_MultipleKeysInput(string question)
        {
            var noOfKeys = Read_Intuser_Input($"Please Enter No of Keys for {question}:");
            var result = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < noOfKeys; i++)
            {
                var key = Read_Optional_String_Input("Key");
                var val = Read_Optional_String_Input("Value");
                result.Add(new KeyValuePair<string, string>(key, val));
            }
            return result;
        }
        private static string Read_Optional_String_Input(string question)
        {
            Console.WriteLine($"{question}:");
            var ans = Console.ReadLine();
            return ans;
        }
        private static string Read_Mandatory_String_Input(string question)
        {
            Console.WriteLine($"{question}:");
            var ans = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ans))
            {
                return Read_Mandatory_String_Input(question);
            }
            return ans;
        }
        public static bool IsValidXml(string xml)
        {
            try
            {
                XDocument.Parse(xml);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string PrettyXml(string xml)
        {
            if (IsValidXml(xml)) //print xml in beautiful format
            {
                var stringBuilder = new StringBuilder();
                var element = XElement.Parse(xml);
                var settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;
                settings.NewLineOnAttributes = true;
                using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
                {
                    element.Save(xmlWriter);
                }
                return stringBuilder.ToString();
            }
            else
            {
                return xml;
            }
        }
    }
}
