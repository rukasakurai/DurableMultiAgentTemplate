namespace DurableMultiAgentTemplate.Model;

public class SynthesizerRequest
{
    public List<string> AgentCallResult { get; set; } = new List<string>();
    public AgentRequestDto AgentReques { get; set; } = new AgentRequestDto();
}