﻿using System.ComponentModel;

namespace DurableMultiAgentTemplate.Agent.SubmitReservationAgent;

public record SubmitReservationRequest(
    [property: Description("行き先のホテルの名前。")]
    string Destination,
    [property: Description("チェックイン日。YYYY/MM/DD形式。")]
    string CheckIn,
    [property: Description("チェックアウト日。YYYY/MM/DD形式。")]
    string CheckOut,
    [property: Description("宿泊人数。")]
    int GuestsCount);
