﻿using System.ComponentModel;

namespace DurableMultiAgentTemplate.Agent.GetSightseeingSpotAgent;

public record GetSightseeingSpotRequest(
    [property: Description("場所の名前。例: ボストン, 東京、フランス")]
    string Location);
