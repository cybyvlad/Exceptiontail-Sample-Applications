using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

using ExceptionTail;

namespace WcfServerSample
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ErrorHandlerServiceBehaviourAttribute : Attribute, IErrorHandler, IServiceBehavior
    {
        #region IErrorHandler Members
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            ET.Publish(error);
        }

        public bool HandleError(Exception error)
        {
            return false;
        }
        #endregion

        #region IServiceBehavior Members
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            ET.Initialize("YOUR_API_KEY");
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                channelDispatcher.ErrorHandlers.Add(this);
            }
        }
        #endregion
    }
}