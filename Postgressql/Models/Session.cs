using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgressql.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; internal set; } = DateTime.UtcNow;

        public string ReturnUrl { get; set; } = "url";
        public string Nonce { get; set; } = "nonce";
        public string Code { get; set; } = "Code";
        public string State { get; internal set; } = "State";

        [NotMapped]
        public Dictionary<string, string> Claims
        {
            get
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(ClaimsJson);
            }
            set
            {
                ClaimsJson = JsonConvert.SerializeObject(value);
            }
        }

        public string ClaimsJson { get; set; } = "{}";

        public string Locale { get;  set; } = "lt";
        public string Token { get;  set; } = "321";
        public string EGovertmentGatewayTicket { get; internal set; } = "EGovertmentGatewayTicket";
        public string ClientCertificateId { get; internal set; } = "clientCertitfied";
    }
}
