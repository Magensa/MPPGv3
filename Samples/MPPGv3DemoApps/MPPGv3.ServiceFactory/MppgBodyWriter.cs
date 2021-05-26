using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Xml;

namespace MPPGv3.ServiceFactory
{
    public class MppgBodyWriter : BodyWriter
    {
        private readonly string body;
        public List<KeyValuePair<string, string>> ModifyTags { get; set; }
        public MppgBodyWriter(string strData) : base(true) => body = strData;
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            var modifiedBody = body;
            foreach (var item in ModifyTags)
            {
                if ((item.Key.Trim() == "") && (item.Value.Trim() == ""))
                {
                    //no need to modify
                }
                else
                {
                    modifiedBody = modifiedBody.Replace(item.Key, item.Value);
                }
            }
            writer.WriteRaw(modifiedBody);
        }
    }
}
