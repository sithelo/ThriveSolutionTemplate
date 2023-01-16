// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace ThriveCardValidator; 

internal class Rule
{
    public Rule()
    {
        Lengths  = new List<int>();
        Prefixes = new List<string>();
    }

    public List<int>    Lengths  { get; set; }
    public List<string> Prefixes { get; set; }
}