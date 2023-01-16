// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace ThriveCardValidator; 

internal class BrandInfo
{
    public BrandInfo()
    {
        Rules     = new List<Rule>();
        BrandName = "Unknown";
        SkipLuhn  = false;
    }

    public List<Rule> Rules     { get; set; }
    public string     BrandName { get; set; }
    public bool       SkipLuhn  { get; set; }
}