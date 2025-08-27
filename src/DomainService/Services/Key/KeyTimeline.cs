using DomainService.Shared.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace DomainService.Services
{
    [BsonIgnoreExtraElements]
    public class KeyTimeline : BlocksBaseTimelineEntity<Key, Key>
    {
    }
}
