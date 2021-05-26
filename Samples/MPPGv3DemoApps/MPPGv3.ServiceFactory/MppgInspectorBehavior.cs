using System.Collections.Generic;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace MPPGv3.ServiceFactory
{
    public class MppgInspectorBehavior : IEndpointBehavior
    {
        private readonly MppgMessageInspector myMessageInspector = new MppgMessageInspector();
        public List<KeyValuePair<string, string>> ModifyTags { get; set; }

        public string LastRequestXML => myMessageInspector.LastRequestXML;

        public string LastResponseXML => myMessageInspector.LastResponseXML;


        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }


        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            myMessageInspector.ModifyTags = ModifyTags;
            clientRuntime.ClientMessageInspectors.Add(myMessageInspector);
        }
    }
}
