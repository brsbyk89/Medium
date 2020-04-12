using Medium.Client.Entities;
using System;

namespace Medium.Business.Contracts
{
    public interface IMediumEngine
    {
        public bool AddStory(AddStoryRequest request);
    }
}
