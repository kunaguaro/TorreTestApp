using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    public class Flags
    {
        public bool benefits { get; set; }
        public bool canary { get; set; }
        public bool enlauSource { get; set; }
        public bool fake { get; set; }
        public bool featureDiscovery { get; set; }
        public bool getSignaledBenefitsViewed { get; set; }
        public bool firstSignalSent { get; set; }
        public bool promoteYourselfBenefitsViewed { get; set; }
        public bool promoteYourselfCompleted { get; set; }
        public bool importingLinkedin { get; set; }
        public bool onBoarded { get; set; }
        public bool remoter { get; set; }
        public bool signalsFeatureDiscovery { get; set; }
        public bool signedInToOpportunities { get; set; }
        public bool importingLinkedinRecommendations { get; set; }
        public bool contactsImported { get; set; }
        public bool appContactsImported { get; set; }
        public bool genomeCompletionAcknowledged { get; set; }
    }
}
