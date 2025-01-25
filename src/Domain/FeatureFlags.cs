using System;

namespace src.Domain
{
    public class FeatureFlags
    {
        public Guid Id { get; set; }
        public string FeatureName { get; set; }
        public bool IsEnabled { get; set; }
    }
}