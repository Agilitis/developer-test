﻿namespace Taxually.Ports.Inbound;

public class VatRegistrationRequest
{
    public string CompanyName { get; set; }
    
    public string CompanyId { get; set; }
    
    public string Country { get; set; }
}