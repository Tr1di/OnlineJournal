namespace MakeTopGreatAgain.Controllers;

public class TestEndpoint(RequestDelegate? requestDelegate, EndpointMetadataCollection? metadata, string? displayName)
    : Endpoint(requestDelegate, metadata, displayName);