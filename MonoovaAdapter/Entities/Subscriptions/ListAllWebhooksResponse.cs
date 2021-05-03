using System.Collections.Generic;
using MonoovaAdapter.Entities.Subscriptions.Dto;

namespace MonoovaAdapter.Entities.Subscriptions
{
    public class ListAllWebhooksResponse : ResponseBase
    {
        public List<SubscriptionsListItems> Eventname { get; set; }
    }
}